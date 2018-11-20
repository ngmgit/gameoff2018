using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaPixelShortScript : SimpleNPCBase
{
	// Use this for initialization
	protected override void Start ()
	{
		base.Start();

		anim.GetBehaviour<IdleFSM>().MonoScriptRef = this;
		anim.GetBehaviour<WalkFSM>().MonoScriptRef = this;
		anim.GetBehaviour<AttackFSM>().MonoScriptRef = this;
		anim.GetBehaviour<VanishFSM>().MonoScriptRef = this;
	}

	protected override void FixedUpdate()
	{
		base.FixedUpdate();

		if (isGrounded && canMove)
			rigid.velocity = new Vector2(mDirection.x * speed, rigid.velocity.y);
	}
}
