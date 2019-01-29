using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/Light Player/Corner Jump")]
    public class CornerJump : StateActions
    {
        public override void Execute(StateManager states)
        {
			if (states.playerLight.wallJumpConfig.canJump &&
				states.inputs.isJumpHold &&
				states.playerLight.wallJumpConfig.delay <= 0.4f)
			{
				states.playerLight.wallJumpConfig.delay +=  Time.deltaTime;

				if (states.playerLight.wallJumpConfig.delay <= 0.37f)
				{
					states.rigid.velocity = new Vector2(0.5f * states.playerLight.wallJumpConfig.direction.x, 1) * 15;
				}
				else
				{
					states.rigid.velocity = new Vector2(0, 1) * 15;
				}

				states.rigid.AddForce(-Physics2D.gravity);
			}
			else
			{
				states.playerLight.wallJumpConfig.canJump = false;
				states.playerLight.wallJumpConfig.delay = 0;
			}
        }
    }
}
