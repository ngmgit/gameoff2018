using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
	[CreateAssetMenu(menuName="State Conditions/Vanish Condition")]
	public class VanishCondition : Condition
	{
		public override bool CheckCondition(StateManager state)
		{
			if (state.inputs.isVanish)
				return true;

			return false;
		}
	}
}
