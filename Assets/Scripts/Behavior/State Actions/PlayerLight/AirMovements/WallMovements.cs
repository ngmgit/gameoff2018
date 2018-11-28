using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/Light Player/Wall Movements")]
    public class WallMovements : StateActions
    {
		private bool changeToDoubleJumpState;

        public override void Execute(StateManager states)
        {
			// Make sure double jump is done only once while in air
			if (!states.playerLight.wallDetected && states.playerLight.canDoubleJump && states.inputs.isJumpHold)
			{
				states.rigid.velocity = new Vector2(states.rigid.velocity.x, 5);
				states.anim.SetTrigger(DefaultAnimParameters.DoubleJump);
			}

			// wall run and wall slide
			if (states.playerLight.wallDetected && states.inputs.isJumpHold && !isFacingOppToWall(states))
			{
				states.playerLight.WallRunBoxCollider.enabled = true;
				states.rigid.velocity = new Vector2(0, 5);
				states.anim.SetTrigger(DefaultAnimParameters.WallRun);
			}

			if (states.inputs.isJumpHold && isFacingOppToWall(states) && !changeToDoubleJumpState)
			{
				states.mTransform.localScale = new Vector3(-1 * states.mTransform.localScale.x,
					states.mTransform.localScale.y,
					states.mTransform.localScale.z);
				states.rigid.AddForce(new Vector2(5,5), ForceMode2D.Impulse);

				states.anim.SetTrigger(DefaultAnimParameters.WallJump);
				changeToDoubleJumpState = true;
			}

			// reset wall run collider if not near wall
			if (!states.playerLight.wallDetected)
				states.playerLight.WallRunBoxCollider.enabled = false;

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
