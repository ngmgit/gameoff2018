using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
	[CreateAssetMenu(menuName="State Conditions/Light Player/DoubleJump To Movement Light")]
	public class DoubleJumpToMovementLightCondition : Condition
	{
		public override bool CheckCondition(StateManager state)
		{
			if (state.isGrounded)
				return true;

			return false;
		}
	}
}
