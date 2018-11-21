using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditNPCScript : SimpleNPCBase
{

	// Use this for initialization
	protected override void Start ()
	{
		base.Start();

		// initialize the behavior scripts

		anim.GetBehaviour<BanditIdleBehaviour>().MonoScriptRef = this;
		anim.GetBehaviour<BanditWanderBehaviour>().MonoScriptRef = this;
		anim.GetBehaviour<BanditAtkIdleBehaviour>().MonoScriptRef = this;
		anim.GetBehaviour<BanditAttackBehaviour>().MonoScriptRef = this;
		anim.GetBehaviour<BanditHurtBehaviour>().MonoScriptRef = this;
	}


	protected override void FixedUpdate()
	{
		base.FixedUpdate();

		if (isGrounded && canMove)
			rigid.velocity = new Vector2(mDirection.x * speed, rigid.velocity.y);
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		switch(other.gameObject.tag)
		{
			case "Player":
				{
					canAttack = true;
					isPlayerDetected = true;
				}
				break;

			case "PlayerWeapon":
				{
					isHurt = true;
					anim.SetTrigger(DefaultAnimParameters.Hurt);
				}
				break;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
			canAttack = false;
	}
}
