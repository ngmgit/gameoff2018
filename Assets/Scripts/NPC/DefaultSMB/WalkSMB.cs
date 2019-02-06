using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkSMB : DefaultBaseFSM {

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		if (!MonoScriptRef.isGrounded || MonoScriptRef.isObstructed)
		{
			MonoScriptRef.canMove = false;
			animator.SetBool(DefaultAnimParameters.Walk, false);
			MonoScriptRef.ChangeDirection();
			MonoScriptRef.isPlayerDetected = false;
		}

		if (MonoScriptRef.isPlayerDetected)
		{
			MonoScriptRef.TurnTowardPlayer();
		}

		if (MonoScriptRef.canAttack)
			animator.SetTrigger(DefaultAnimParameters.Attack);
	}
}
