using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SA;


public class AttackEvents : MonoBehaviour
{
	public StatesVariable states;
	public AudioClip SlamGround;

	public void SetAttackAnimCancelFlag(int i)
	{
		if (states != null)
		{
		if (i == 1)
			states.value.playerDark.canSkipAttackAnim = true;
		else
			states.value.playerDark.canSkipAttackAnim = false;
		}
	}

	private void PlaySound()
	{
		states.value.PlayAudio();
	}

	private void SetGroundSlamChargeSound()
	{
		states.value.currentAudio.clip = SlamGround;
		PlaySound();
	}
}
