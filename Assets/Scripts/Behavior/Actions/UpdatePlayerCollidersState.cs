using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/Actions/Update Player Collider State")]
    public class UpdatePlayerCollidersState : Action
    {
		public StatesVariable states;

		public override void Execute()
        {
			states.value.anim.SetBool(DefaultAnimParameters.IsGrounded, states.value.isGrounded);
		}
	}
}
