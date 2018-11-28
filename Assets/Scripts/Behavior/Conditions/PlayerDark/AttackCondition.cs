using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
	[CreateAssetMenu(menuName="State Conditions/Attack Condition")]
	public class AttackCondition : Condition
	{
		public override bool CheckCondition(StateManager state)
		{
			if (state.isGrounded && state.inputs.isAttackingDown)
				return true;

			return false;
		}
	}
}
