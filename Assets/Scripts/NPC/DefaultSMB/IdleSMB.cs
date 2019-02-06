using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleSMB : DefaultBaseFSM
{
	private bool onceFlag = true;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		MonoScriptRef.HaltNPC();
	}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		if (!MonoScriptRef.canMove && onceFlag)
		{
			onceFlag = false;
			MonoScriptRef.RunIdleCR();
		}

		if (!MonoScriptRef.canAttack && !MonoScriptRef.isGrounded && !MonoScriptRef.isInAir)
			MonoScriptRef.ChangeDirection();

		if (MonoScriptRef.canMove && MonoScriptRef.isGrounded)
			animator.SetBool(DefaultAnimParameters.Walk, true);

		if (MonoScriptRef.canAttack && MonoScriptRef.isGrounded)
			animator.SetTrigger(DefaultAnimParameters.Attack);
	}

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		MonoScriptRef.StopIdleCR();
		onceFlag = true;
	}
}

