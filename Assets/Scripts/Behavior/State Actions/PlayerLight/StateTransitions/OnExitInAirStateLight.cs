using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SA
{
	[CreateAssetMenu(menuName = "Actions/State Transitions/Light Player/OnExitInAirStateLight")]
	public class OnExitInAirStateLight : StateActions
    {
        public override void Execute(StateManager states)
        {
			states.playerLight.canSwitchtoDoubleJumpState = false;
		}
	}
}