using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaPixelShortFSMBase : DefaultBaseFSM
{
	[HideInInspector]
	public NinjaPixelShortScript MonoScriptRef;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
	}
}
