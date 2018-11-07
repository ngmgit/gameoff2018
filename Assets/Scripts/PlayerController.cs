using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	Rigidbody2D rb;
	SpriteRenderer spriteRend;
	public float jumpForce;
	public float speed;
	public float jumpTime;
	public float initJumpMultiplier = 1;

	private bool isJumping = false;
	private float jumpTimeCounter;

	// Use this for initialization
	void Start () {
		rb = GetComponentInChildren<Rigidbody2D>();
		spriteRend = GetComponentInChildren<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update ()
	{
		rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);

		if (Input.GetAxis("Horizontal") < 0.0f) {
			Vector2 tempScale = new Vector2 (-1, 1);
			spriteRend.flipX = true;
		} else {
			Vector2 tempScale = new Vector2 (1, 1);
			spriteRend.flipX = false;
		}


		if (Input.GetButtonDown("Jump") && GetComponentInChildren<GroundCheck>().isGrounded)
		{
			isJumping = true;
			jumpTimeCounter = jumpTime;
			rb.AddForce(Vector2.up * jumpForce * initJumpMultiplier, ForceMode2D.Impulse);
		}

		if (Input.GetButton("Jump") && isJumping)
		{
			if (jumpTimeCounter > 0)
			{
				rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
				jumpTimeCounter -= Time.deltaTime;
			}
			else
				isJumping = false;
		}

		if (Input.GetButtonUp("Jump"))
		{
			isJumping = false;
		}

	}
}
