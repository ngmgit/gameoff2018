using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
	[CreateAssetMenu(menuName="State Conditions/AttackToMovement")]
	public class AttackToMovement : Condition
	{
		public override bool CheckCondition(StateManager state)
		{
			if (Mathf.Abs(state.movementValues.horizontal) > 0.01f || state.isDash || state.isJumpDown)
				if (state.anim.GetCurrentAnimatorStateInfo(0).IsName("Dummy"))
					return true;

			return false;
		}
	}
}
