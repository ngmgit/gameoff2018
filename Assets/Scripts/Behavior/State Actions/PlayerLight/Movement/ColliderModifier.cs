using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SA
{
	[CreateAssetMenu(menuName = "Actions/State Actions/Light Player/Collider Modifier")]
	public class ColliderModifier : StateActions
	{
		bool isCrouching;
		bool isSliding;

		public override void Execute(StateManager states)
		{
			isCrouching = states.movementValues.vertical < 0 && states.isGrounded;
			isSliding = states.inputs.isDashHold && states.isGrounded;

			if (isCrouching || isSliding || states.playerLight.isCrouchWallDetected)
				states.playerLight.boxCollider.isTrigger = true;
			else
				states.playerLight.boxCollider.isTrigger = false;
		}
	}
}
