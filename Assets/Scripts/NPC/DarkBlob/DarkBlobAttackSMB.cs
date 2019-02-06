using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkBlobAttackSMB : DefaultBaseFSM {

	private DarkBlobNPCScript darkBlobNPCScriptRef;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		darkBlobNPCScriptRef = MonoScriptRef as DarkBlobNPCScript;
		darkBlobNPCScriptRef.prevGrounded = false;
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		if ((MonoScriptRef.isGrounded || MonoScriptRef.isObstructed) && darkBlobNPCScriptRef.prevGrounded)
		{
			darkBlobNPCScriptRef.prevGrounded = false;
			animator.SetBool(DefaultAnimParameters.Walk, false);
		}
	}

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		MonoScriptRef.canAttack = false;
		MonoScriptRef.TurnTowardPlayer();
		darkBlobNPCScriptRef.ResetDelayTime();
	}
}
