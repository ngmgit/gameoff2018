using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleFSM : NinjaPixelShortFSMBase
{
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
	}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		MonoScriptRef.HaltNPC();

		if (MonoScriptRef.isPlayerDetected)
			animator.SetBool("vanish", true);

		animator.SetBool("move", true);
	}
}
