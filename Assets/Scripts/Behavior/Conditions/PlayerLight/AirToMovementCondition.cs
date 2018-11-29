using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
	[CreateAssetMenu(menuName="State Conditions/Light Player/Air To Movement Condition")]
	public class AirToMovementCondition : Condition
	{
		public override bool CheckCondition(StateManager state)
		{
			if (state.isGrounded)
				return true;

			if (!state.playerLight.isLedgeDetected && !state.playerLight.wallDetected && state.isFalling)
				return true;

			return false;
		}
	}
}