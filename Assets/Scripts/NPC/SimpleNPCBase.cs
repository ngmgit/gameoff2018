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
	public bool isPlayerDetected;
	public bool isObstructed;
	[HideInInspector]
	public bool isRespawnPositionSet;
	[HideInInspector]
	public Vector2 mDirection;
	[HideInInspector]
	public Vector3 respawnPosition;

	[Tooltip("Set the Ground colliders for the linecast mask")]
	public LayerMask layerMask;
	[Tooltip("Y offset from the bottom of the collider, x is upwards and y is for downward")]
	public Vector2 lengthOffset;
	[Tooltip("To set the origin for ray using the x value and to get the end position for the ray cast using the y value for Obstacle detection ray")]
	public Vector2 ObstacleRayOffset;

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
		// Draw vertical lineCast to checking if grounded
		// Top position for lineCast
		Vector2 lineCastOffsetTop = mDirection.normalized * col.bounds.extents.x;
		Vector2 lineCastPos = transform.position.toVecto2() + lineCastOffsetTop;
		lineCastPos.y = col.bounds.min.y + lengthOffset.x;

		// Bottom position for lineCast
		Vector2 lineCastEndPos = new Vector2(lineCastPos.x, col.bounds.min.y - lengthOffset.y);
		Debug.DrawLine(lineCastPos, lineCastEndPos);

		isGrounded = Physics2D.Linecast(lineCastPos, lineCastEndPos, layerMask);
	}

	private void SetObstacleStatus()
	{
		// Draw vertical lineCast to checking if grounded
		// Top position for lineCast
		Vector2 lineCastOffsetTop = mDirection.normalized * col.bounds.extents.x;
		Vector2 lineCastPos = transform.position.toVecto2() + lineCastOffsetTop;
		lineCastPos.y = col.bounds.min.y + ObstacleRayOffset.x;

		// Bottom position for lineCast
		Vector2 lineCastEndPos = new Vector2(lineCastPos.x + (mDirection.x * ObstacleRayOffset.y),  lineCastPos.y);
		Debug.DrawLine(lineCastPos, lineCastEndPos);

		isObstructed = Physics2D.Linecast(lineCastPos, lineCastEndPos, layerMask);
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
}
