using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditIdleBehaviour : BanditsFSMBase {
	private bool onceFlag = true;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		MonoScriptRef.HaltNPC ();
	}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		if (!MonoScriptRef.canMove && onceFlag)
		{
			onceFlag = false;
			MonoScriptRef.RunIdleCR();
		}

		if (!MonoScriptRef.canAttack && !MonoScriptRef.isGrounded)
			MonoScriptRef.ChangeDirection();


		if (MonoScriptRef.canMove && MonoScriptRef.isGrounded)
			animator.SetBool(DefaultAnimParameters.Walk, true);

		if (MonoScriptRef.canAttack)
			animator.SetTrigger(DefaultAnimParameters.Attack);
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		MonoScriptRef.StopIdleCR();
		onceFlag = true;
	}
}
