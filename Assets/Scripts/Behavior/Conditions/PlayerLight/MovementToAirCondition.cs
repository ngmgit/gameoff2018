using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
	[CreateAssetMenu(menuName="State Conditions/Light Player/Movement To Air Condition")]
	public class MovementToAirCondition : Condition
	{
		public override bool CheckCondition(StateManager state)
		{
			if (!state.isGrounded && state.playerLight.wallDetected)
				return true;

			if (state.playerLight.wallDetected && state.inputs.isJumpHold)
				return true;

			return false;
		}
	}
}
