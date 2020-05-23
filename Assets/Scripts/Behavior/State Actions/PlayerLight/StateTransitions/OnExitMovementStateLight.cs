using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
	[CreateAssetMenu(menuName = "Actions/State Transitions/Light Player/OnExitMovementStateLight")]
	public class OnExitMovementStateLight : StateActions
	{
		public override void Execute(StateManager states)
		{
			states.movementValues.dashSpeedMultiplier = 1;
			states.anim.SetBool(DefaultAnimParameters.isFall, false);
		}
	}
}