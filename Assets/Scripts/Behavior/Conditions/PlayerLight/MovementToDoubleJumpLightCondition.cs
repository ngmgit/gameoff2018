using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
	[CreateAssetMenu(menuName="State Conditions/Light Player/Movement To DoubleJump Light")]
	public class MovementToDoubleJumpLightCondition : Condition
	{
		public override bool CheckCondition(StateManager state)
		{
			if (!state.isGrounded && !state.playerLight.wallDetected && state.inputs.isJumpDown)
				return true;

			return false;
		}
	}
}
