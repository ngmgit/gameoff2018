using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndeadAttackState : UndeadGreenFSMBase
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.SetBool(DefaultAnimParameters.Walk, false);
		MonoScriptRef.HaltNPC();
	}

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		if (MonoScriptRef.CheckIfHasToTurn())
			MonoScriptRef.ChangeDirection();
	}
}
