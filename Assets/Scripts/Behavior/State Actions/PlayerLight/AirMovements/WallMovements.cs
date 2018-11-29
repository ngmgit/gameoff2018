using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/Light Player/Wall Movements")]
    public class WallMovements : StateActions
    {
		private bool changeToDoubleJumpState;
		public float wallRunSpeed;

        public override void Execute(StateManager states)
        {
			if (states.playerLight.isLedgeDetected)
				return;

			// wall run and wall jump
			if (states.inputs.isJumpHold)
			{
				if (states.playerLight.wallDetected && !states.isFacingOppToWall())
				{
					states.rigid.velocity = new Vector2(0, wallRunSpeed);
					states.anim.SetTrigger(DefaultAnimParameters.WallRun);
				}
				else if (states.isFacingOppToWall() && !states.playerLight.canSwitchtoDoubleJumpState)
				{
					states.mTransform.localScale = new Vector3(-1 * states.mTransform.localScale.x,
						states.mTransform.localScale.y,
						states.mTransform.localScale.z);
					states.playerLight.canSwitchtoDoubleJumpState = true;
				}
			}
        }
    }
}
