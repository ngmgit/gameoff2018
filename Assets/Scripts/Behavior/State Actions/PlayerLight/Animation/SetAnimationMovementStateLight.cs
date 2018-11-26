using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
	[CreateAssetMenu(menuName="Actions/Animation/Movement State Anim Light")]
	public class SetAnimationMovementStateLight : StateActions {

		public override void Execute(StateManager states)
		{
			states.anim.SetBool(DefaultAnimParameters.IsGrounded, states.isGrounded);
			states.anim.SetFloat(DefaultAnimParameters.Walk, Mathf.Abs(states.movementValues.horizontal));
			states.anim.SetBool(DefaultAnimParameters.Slide, states.inputs.isDashHold);

			if (states.movementValues.vertical < 0)
				states.anim.SetBool(DefaultAnimParameters.Crouch, true);
			else
				states.anim.SetBool(DefaultAnimParameters.Crouch, false);

			if (states.isGrounded && states.inputs.isJumpDown)
				states.anim.SetTrigger(DefaultAnimParameters.Jump);


			states.anim.SetBool("isFalling", states.isFalling);
		}
	}
}
