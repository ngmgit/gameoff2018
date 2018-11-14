using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaPixelShortScript : MonoBehaviour
{
	public Transform spawnPosition;
	public SO.TransformVariable PlayerTransform;

	public float speed = 3;

	[HideInInspector]
	public bool canAttack = true;
	[HideInInspector]
	public bool canMove;
	[HideInInspector]
	public bool isGrounded;
	public bool isPlayerDetected;
	[HideInInspector]
	public bool isRespawnPositionSet;

	[Tooltip("Set the Ground colliders for the linecast mask")]
	public LayerMask layerMask;
	[Tooltip("Y offset from the bottom of the collider, x is upwards and y is for downward")]
	public Vector2 lengthOffset;
	[HideInInspector]
	public Vector2 mDirection;
	[HideInInspector]
	public Vector3 respawnPosition;

	private BoxCollider2D coll;
	private Rigidbody2D rigid;

	// Use this for initialization
	private void Start ()
	{
		mDirection = new Vector2(transform.localScale.x,1);
		coll = GetComponent<BoxCollider2D>();
		rigid = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		Vector2 lineCastPos = transform.position.toVecto2() + mDirection * coll.bounds.extents.x;
		lineCastPos.y = coll.bounds.min.y + lengthOffset.x;
		Vector2 lineCastEndPos = new Vector2(lineCastPos.x, coll.bounds.min.y - lengthOffset.y);
		Debug.DrawLine(lineCastPos, lineCastEndPos);
		isGrounded = Physics2D.Linecast(lineCastPos, lineCastEndPos, layerMask);

		if (isGrounded && canMove)
			rigid.velocity = new Vector2(mDirection.x * speed, rigid.velocity.y);
	}

	public void AttackPlayer()
	{
		isPlayerDetected = true;
	}

	public void DontChasePlayer()
	{
		isPlayerDetected = false;
	}

	public void HaltPlayer()
	{
		rigid.velocity = Vector2.zero;
		canMove = false;
	}

	public void ChangeDirection()
	{
		mDirection.x = transform.localScale.x * -1;
		transform.localScale = new Vector3(mDirection.x, 1, 1);
	}
}
