using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
	[CreateAssetMenu(menuName="State Conditions/Light Player/InAir To Double Jump Light")]
	public class InAirToDoubleJumpLight : Condition
	{
		public override bool CheckCondition(StateManager state)
		{
			if (!state.isGrounded && state.playerLight.canSwitchtoDoubleJumpState)
				return true;

			return false;
		}
	}
}
