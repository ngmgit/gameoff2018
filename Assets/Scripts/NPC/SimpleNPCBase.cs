using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Note: Consider scale into calculations as some of the assets might be sclaed in size
// Base class where the common state and functionality for a simple NPC.
public class SimpleNPCBase : MonoBehaviour
{
	public Transform spawnPosition;
	public SO.TransformVariable PlayerTransform;
	public float speed = 3;
	public float idleDelayTime = 1;

	[HideInInspector]
	public bool isDead;
	[HideInInspector]
	public bool isHurt;
	[HideInInspector]
	public bool canAttack;
	[HideInInspector]
	public bool canMove;
	public bool isGrounded;
	public bool isInAir;
	public bool isPlayerDetected;
	public bool isObstructed;
	[HideInInspector]
	public bool isRespawnPositionSet;
	[HideInInspector]
	public Vector2 mDirection;
	[HideInInspector]
	public Vector3 respawnPosition;

	[Header("Ground Collider Config")]
	[Tooltip("Set the Ground colliders for the linecast mask")]
	public LayerMask layerMask;
	[Tooltip("To set the origin for Ground ray")]
	public Transform groundColliderOrigin;
	public Transform airCheckOrigin;
	public float groundColliderLength;
	public float obstacleColliderLength;

	protected BoxCollider2D col;
	protected Rigidbody2D rigid;
	protected Animator anim;

	// Use this for initialization
	protected virtual void Start ()
	{
		anim = GetComponent<Animator>();
		mDirection = new Vector2(transform.localScale.x, transform.localScale.y);
		col = GetComponent<BoxCollider2D>();
		rigid = GetComponent<Rigidbody2D>();
	}

	protected virtual void FixedUpdate()
	{
		SetGroundStatus();
		SetObstacleStatus();
	}

	private void SetGroundStatus()
	{
		if (!groundColliderOrigin)
		{
			Debug.LogError("Make sure ground collider origin is set!");
			return;
		}

		Vector2 lineCastEndPos = groundColliderOrigin.position + (transform.up * -1 * groundColliderLength);
		Debug.DrawLine(groundColliderOrigin.position, lineCastEndPos);
		isGrounded = Physics2D.Linecast(groundColliderOrigin.position, lineCastEndPos, layerMask);


		if (!airCheckOrigin)
		{
			return;
		}

		lineCastEndPos = airCheckOrigin.position + (transform.up * -1 * groundColliderLength);
		Debug.DrawLine(airCheckOrigin.position, lineCastEndPos);

		isInAir = !Physics2D.Linecast(airCheckOrigin.position, lineCastEndPos, layerMask);
		isGrounded = isGrounded && !isInAir;
	}

	private void SetObstacleStatus()
	{
		if (!groundColliderOrigin)
		{
			Debug.LogError("Make sure obstacle collider origin is set!");
			return;
		}

		Vector2 lineCastEndPos = groundColliderOrigin.position + (transform.right.normalized * (mDirection.x)* obstacleColliderLength);

		Debug.DrawLine(groundColliderOrigin.position, lineCastEndPos);

		isObstructed = Physics2D.Linecast(groundColliderOrigin.position, lineCastEndPos, layerMask);
	}

	public void AttackPlayer()
	{
		isPlayerDetected = true;
	}

	public void DontChasePlayer()
	{
		isPlayerDetected = false;
	}

	public void HaltNPC()
	{
		rigid.velocity = Vector2.zero;
		canMove = false;
	}

	public void ChangeDirection()
	{
		mDirection.x = transform.localScale.x * -1;
		transform.localScale = new Vector3(mDirection.x, mDirection.y, transform.localScale.z);
	}

	public bool CheckIfHasToTurn()
	 {
		Vector3 playerPosition = PlayerTransform.value.position;

		if (playerPosition.x > transform.position.x && transform.localScale.x == -1 * Mathf.Abs(mDirection.x))
			return true;

		if (playerPosition.x < transform.position.x && transform.localScale.x == 1  * Mathf.Abs(mDirection.x))
			return true;

		return false;
	}

	public void RunIdleCR()
	{
		StartCoroutine("IdleDelayCR");
	}

	public void StopIdleCR()
	{
		StopCoroutine("IdleDelayCR");
		canMove = true;
	}

	public virtual IEnumerator IdleDelayCR()
	{
		 yield return new WaitForSeconds(idleDelayTime);
		 canMove = true;
	}

	public void TurnTowardPlayer()
	{
		if (CheckIfHasToTurn())
			ChangeDirection();
	}
}
