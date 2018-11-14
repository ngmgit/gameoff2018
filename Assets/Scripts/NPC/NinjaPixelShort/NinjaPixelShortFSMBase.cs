using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaPixelShortFSMBase : DefaultBaseFSM
{
	protected NinjaPixelShortScript MonoScriptRef;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		MonoScriptRef = animator.gameObject.GetComponent<NinjaPixelShortScript>();
	}
}
