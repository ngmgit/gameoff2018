﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtSMB : DefaultBaseFSM {

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		MonoScriptRef.HaltNPC();
		MonoScriptRef.TurnTowardPlayer();
	}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		if(MonoScriptRef.isDead)
			animator.SetTrigger(DefaultAnimParameters.Dead);
	}

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		MonoScriptRef.isHurt = false;
	}
}