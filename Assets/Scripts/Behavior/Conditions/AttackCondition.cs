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
			if (state.isGrounded && state.isAttackingDown)
			{
				state.rigid.velocity = Vector2.zero;
				state.anim.SetFloat("moving", 0);
				return true;
			}

			return false;
		}
	}
}
