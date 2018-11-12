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
			states.value.canSkipAttackAnim = true;
		else
			states.value.canSkipAttackAnim = false;
		}
	}

	private void PlaySound()
	{
		states.value.currentAudio.Stop();
		states.value.currentAudio.Play();
	}

	private void SetGroundSlamChargeSound()
	{
		states.value.currentAudio.clip = SlamGround;
		PlaySound();
	}
}
