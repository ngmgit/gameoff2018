using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
	[CreateAssetMenu(menuName="Actions/Animation/Air State Anim Light")]
	public class SetAnimAir : StateActions
	{
		public override void Execute(StateManager states)
		{
			if (states.playerLight.isLedgeDetected && states.movementValues.vertical >= 0)
				states.anim.SetTrigger(DefaultAnimParameters.LedgeGrab);

			states.anim.SetBool(DefaultAnimParameters.isFall, states.isFalling);
		}
	}
}
