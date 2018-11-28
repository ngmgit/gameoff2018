using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/Light Player/Wall Movements")]
    public class WallMovements : StateActions
    {
		private bool changeToDoubleJumpState;
		public float idleSlideSpeed;
		public float activeSlideSpeed;
		public float wallRunSpeed;
		public float wallJumpForce;

        public override void Execute(StateManager states)
        {
			// wall run and wall jump
			if (states.inputs.isJumpHold)
			{
				if (states.playerLight.wallDetected && !isFacingOppToWall(states))
				{
					states.rigid.velocity = new Vector2(0, wallRunSpeed);
					states.anim.SetTrigger(DefaultAnimParameters.WallRun);
				}
				else if (isFacingOppToWall(states) && !states.playerLight.canSwitchtoDoubleJumpState)
				{
					states.mTransform.localScale = new Vector3(-1 * states.mTransform.localScale.x,
						states.mTransform.localScale.y,
						states.mTransform.localScale.z);
					states.playerLight.canSwitchtoDoubleJumpState = true;
				}
			}
			else
			{
				if (states.movementValues.vertical < 0)
				{
					states.rigid.velocity = new Vector2(0, activeSlideSpeed);
				}
				else
				{
					if (!isFacingOppToWall(states))
						states.rigid.velocity = new Vector2(0, idleSlideSpeed);
				}
			}
        }

		private bool isFacingOppToWall(StateManager state)
		{
			if (state.mTransform.localScale.x > 0)
			{
				if (state.movementValues.horizontal < 0.1)
					return true;
			}
			else
			{
				if (state.movementValues.horizontal > 0.1)
					return true;
			}

			return false;
		}
    }
}
