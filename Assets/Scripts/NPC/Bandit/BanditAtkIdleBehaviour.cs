using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditAtkIdleBehaviour : BanditsFSMBase
{
	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		MonoScriptRef.HaltNPC();
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		if (MonoScriptRef.canAttack)
		{
			animator.SetBool (DefaultAnimParameters.Attack, true);
		}
		else if (MonoScriptRef.isPlayerDetected &&
			Vector2.Distance(animator.transform.position, MonoScriptRef.PlayerTransform.value.position) > 5)
		{
			animator.SetBool (DefaultAnimParameters.Walk, true);
		}
	}
}
