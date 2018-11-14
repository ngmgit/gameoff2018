using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanishFSM : NinjaPixelShortFSMBase
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!MonoScriptRef.isPlayerDetected)
        {
            MonoScriptRef.isRespawnPositionSet = true;
        }
        MonoScriptRef.respawnPosition = MonoScriptRef.transform.position;
	}
}
