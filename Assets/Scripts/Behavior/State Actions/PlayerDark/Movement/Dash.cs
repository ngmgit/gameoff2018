using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
	[CreateAssetMenu(menuName = "Actions/State Actions/Dash")]
	public class Dash : StateActions {
		public float dashSpeed = 1;

		public override void Execute(StateManager states)
        {
			if (states.anim.GetCurrentAnimatorStateInfo(0).IsName("Dash"))
				states.movementValues.dashSpeedMultiplier = dashSpeed;
			else
				states.movementValues.dashSpeedMultiplier = 1;
		}
	}
}
