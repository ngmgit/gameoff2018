using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Transitions/Light Player/OnEnterInAirStateLight")]
    public class OnEnterInAirStateLight : StateActions
    {
        public override void Execute(StateManager states)
        {
            states.playerLight.canSwitchtoDoubleJumpState = false;
            states.playerLight.wallJumpConfig.direction = new Vector2(states.movementValues.moveDirection.x * -1, states.movementValues.vertical);
            states.vCamGround.Priority = 1;
        }
    }
}