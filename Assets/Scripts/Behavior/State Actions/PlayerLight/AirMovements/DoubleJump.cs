using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/Light Player/Double Jump")]
    public class DoubleJump : StateActions
    {
        public float jumpForce;

        public override void Execute(StateManager states)
        {
            if (CanJump(states))
            {
                states.rigid.velocity = new Vector2(states.rigid.velocity.x, jumpForce);
                states.playerLight.canDoubleJump = false;
                states.playerLight.canSwitchtoDoubleJumpState = true;
            }
            states.anim.SetTrigger(DefaultAnimParameters.DoubleJump);
        }

        private bool CanJump(StateManager states)
        {
            if (!states.playerLight.wallDetected && states.inputs.isJumpHold && states.playerLight.canDoubleJump)
                return true;

            return false;
        }
    }
}
