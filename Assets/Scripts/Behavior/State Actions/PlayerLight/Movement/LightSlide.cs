using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
	[CreateAssetMenu(menuName = "Actions/State Actions/Light Player/Slide")]
	public class LightSlide : StateActions
	{
		public float slideSpeed;
		public override void Execute(StateManager states)
		{
			if (slideSpeed > 0 && states.inputs.isDashHold)
				states.movementValues.dashSpeedMultiplier = slideSpeed;
			else
				states.movementValues.dashSpeedMultiplier = 1;
		}
	}
}

