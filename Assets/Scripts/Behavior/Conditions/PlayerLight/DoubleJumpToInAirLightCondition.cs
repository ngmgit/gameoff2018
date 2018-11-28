﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
	[CreateAssetMenu(menuName="State Conditions/Light Player/DoubleJump To InAir Light")]
	public class DoubleJumpToInAirLightCondition : Condition
	{
		bool prevWallDetect;

		public override bool CheckCondition(StateManager state)
		{
			if (state.isFalling && state.playerLight.wallDetected)
				return true;

			return false;
		}
	}
}