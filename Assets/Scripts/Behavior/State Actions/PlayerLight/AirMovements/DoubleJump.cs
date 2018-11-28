using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/Light Player/Double Jump")]
    public class DoubleJump : StateActions
    {
		bool prevFrameWallDetect;

        public override void Execute(StateManager states)
        {
			if (states.playerLight.wallDetected && !prevFrameWallDetect)
				states.playerLight.canDoubleJump = true;

            if (!states.playerLight.wallDetected && states.inputs.isJumpHold && states.playerLight.canDoubleJump)
				states.playerLight.canDoubleJump = false;

			prevFrameWallDetect = states.playerLight.wallDetected;
        }
    }
}
