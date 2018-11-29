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
			if (states.value.anim.GetCurrentAnimatorStateInfo(0).IsName("Acrobatics.Sommersault") &&
				!states.value.playerLight.wallDetected)
				states.value.anim.SetBool(DefaultAnimParameters.isFall, false);
			else
				states.value.anim.SetBool(DefaultAnimParameters.isFall, states.value.isFalling);

			states.value.anim.SetBool(DefaultAnimParameters.IsGrounded, states.value.isGrounded);
		}
	}
}
