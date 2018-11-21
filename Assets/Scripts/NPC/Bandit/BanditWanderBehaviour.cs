﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditWanderBehaviour : BanditsFSMBase {

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
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
			if (MonoScriptRef.CheckIfHasToTurn())
				MonoScriptRef.ChangeDirection();
		}

		if (MonoScriptRef.canAttack)
			animator.SetTrigger(DefaultAnimParameters.Attack);
	}
}
