using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkFSM : NinjaPixelShortFSMBase
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        MonoScriptRef.canMove = true;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
        if (!MonoScriptRef.isGrounded)
		{
			MonoScriptRef.ChangeDirection();
		}

        if (MonoScriptRef.isPlayerDetected)
        {
            animator.SetBool("move", false);
            MonoScriptRef.HaltNPC();
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        MonoScriptRef.canMove = false;
    }
}
