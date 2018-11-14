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
			if (Mathf.Abs(state.movementValues.horizontal) > 0f || state.inputs.isDash || state.inputs.isJumpDown)
			{
				if (state.anim.GetCurrentAnimatorStateInfo(0).IsTag("AttackPrimary"))
				{
					if (wantToMoveOppositeDir(state) &&
						state.anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.2 &&
						state.canSkipAttackAnim)
					{
						SetOnEnd(state);
						return true;
					}
				}
			}

			if (state.anim.GetCurrentAnimatorStateInfo(0).IsName("Attack State.Dummy"))
			{
				SetOnEnd(state);
				return true;
			}

			// When in attack animatins and falling down
			if (!state.isGrounded && !state.anim.GetCurrentAnimatorStateInfo(0).IsTag("AttackPrimary"))
				return true;

			return false;
		}

		private bool wantToMoveOppositeDir(StateManager state)
		{
			if (state.movementValues.horizontal < 0 && state.mTransform.localScale.x > 0)
				return true;

			if (state.movementValues.horizontal > 0 && state.mTransform.localScale.x < 0)
				return true;

			return false;
		}

		private void SetOnEnd(StateManager state)
		{
			state.canSkipAttackAnim = false;
			state.AttackPrimaryType = -1;
		}
	}
}
