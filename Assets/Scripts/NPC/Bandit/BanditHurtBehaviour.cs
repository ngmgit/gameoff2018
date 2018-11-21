using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditHurtBehaviour : BanditsFSMBase {

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		MonoScriptRef.HaltNPC();
		if (MonoScriptRef.CheckIfHasToTurn())
			MonoScriptRef.ChangeDirection();
	}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		if(MonoScriptRef.isDead)
			animator.SetTrigger(DefaultAnimParameters.Dead);
	}
}
