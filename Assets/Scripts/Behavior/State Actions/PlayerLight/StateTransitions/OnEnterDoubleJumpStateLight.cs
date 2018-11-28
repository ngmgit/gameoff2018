using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Transitions/Light Player/OnEnterDoubleJumpStateLight")]
    public class OnEnterDoubleJumpStateLight : StateActions
    {
        public override void Execute(StateManager states)
        {
			states.playerLight.canDoubleJump = true;
        }
    }
}
