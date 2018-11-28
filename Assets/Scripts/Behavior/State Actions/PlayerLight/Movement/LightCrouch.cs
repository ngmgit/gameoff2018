using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
	[CreateAssetMenu(menuName = "Actions/State Actions/Light Player/Crouch")]
	public class LightCrouch : StateActions
	{
		public override void Execute(StateManager states)
		{
			if (states.movementValues.vertical < 0 && states.isGrounded)
				states.playerLight.boxCollider.isTrigger = true;
			else
				states.playerLight.boxCollider.isTrigger = false;
		}
	}
}
