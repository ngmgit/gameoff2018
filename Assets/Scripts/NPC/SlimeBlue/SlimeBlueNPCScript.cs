using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))]
public class SlimeBlueNPCScript : SimpleNPCBase
{
	// Use this for initialization
	protected override void Start ()
	{
		base.Start();

		// initialize the behavior scripts
		anim.GetBehaviour<IdleSMB>().MonoScriptRef = this;
		anim.GetBehaviour<WalkSMB>().MonoScriptRef = this;
		anim.GetBehaviour<AttackSMB>().MonoScriptRef = this;
		anim.GetBehaviour<HurtSMB>().MonoScriptRef = this;
	}


	protected override void FixedUpdate()
	{
		base.FixedUpdate();

		if (isGrounded && canMove)
			rigid.velocity = new Vector2(mDirection.x * speed, rigid.velocity.y);
	}
}
