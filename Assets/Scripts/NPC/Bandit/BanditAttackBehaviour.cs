using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditAttackBehaviour : BanditsFSMBase
{

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.SetBool(DefaultAnimParameters.Walk, false);
		MonoScriptRef.HaltNPC();
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		if (MonoScriptRef.CheckIfHasToTurn())
			MonoScriptRef.ChangeDirection();
	}
}
