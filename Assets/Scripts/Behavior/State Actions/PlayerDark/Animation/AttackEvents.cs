using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SA;

public class AttackEvents : MonoBehaviour
{
	public StatesVariable states;

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

	private void PlayAttack()
	{
		states.value.currentAudio.Stop();
		states.value.currentAudio.Play();
	}
}
