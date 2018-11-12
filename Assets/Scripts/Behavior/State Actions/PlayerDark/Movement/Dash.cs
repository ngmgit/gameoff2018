using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
	[CreateAssetMenu(menuName = "Actions/State Actions/Dash")]
	public class Dash : StateActions {
		public float dashSpeed = 1;
		public AudioClip dashAudio;

		public override void Execute(StateManager states)
        {
			if (states.inputs.isDash)
				states.currentAudio.clip = dashAudio;

			if (states.anim.GetCurrentAnimatorStateInfo(0).IsName("Dash"))
				states.movementValues.dashSpeedMultiplier = dashSpeed;
			else
				states.movementValues.dashSpeedMultiplier = 1;
		}
	}
}
