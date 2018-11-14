using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFSM : NinjaPixelShortFSMBase
{

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
        base.OnStateEnter(animator, stateInfo, layerIndex);

		animator.SetBool("vanish", false);
		MonoScriptRef.GetComponent<Collider2D>().isTrigger = true;
		MonoScriptRef.transform.position = MonoScriptRef.PlayerTransform.value.transform.position;
	}

	//OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		if (MonoScriptRef.isRespawnPositionSet)
		{
			MonoScriptRef.transform.position = MonoScriptRef.respawnPosition;
			MonoScriptRef.isRespawnPositionSet = false;
		}
		else
		{
			Vector3 tempPos = MonoScriptRef.transform.position;
			tempPos.y = MonoScriptRef.respawnPosition.y;
			MonoScriptRef.transform.position = tempPos;
		}

		MonoScriptRef.GetComponent<Collider2D>().isTrigger = false;
	}
}
