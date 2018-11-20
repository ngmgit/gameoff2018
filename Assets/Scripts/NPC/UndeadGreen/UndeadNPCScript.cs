using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class UndeadNPCScript : SimpleNPCBase
{
	public int idleDelayTime = 1;

	// Use this for initialization
	protected override void Start ()
	{
		base.Start();

		anim.GetBehaviour<UndeadIdleState>().MonoScriptRef = this;
		anim.GetBehaviour<UndeadWalkState>().MonoScriptRef = this;
		anim.GetBehaviour<UndeadAttackState>().MonoScriptRef = this;
		anim.GetBehaviour<UndeadHurtState>().MonoScriptRef = this;
	}

	protected override void FixedUpdate()
	{
		base.FixedUpdate();

		if (isGrounded && canMove)
			rigid.velocity = new Vector2(mDirection.x * speed, rigid.velocity.y);
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

	protected IEnumerator IdleDelayCR()
	{
		 yield return new WaitForSeconds(idleDelayTime);
		 canMove = true;
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
