using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
	[CreateAssetMenu(menuName="Actions/Actions/Fall Velocity Limiter")]
	public class FallVelocityLimiter : Action
	{
		public float maxFallVelocity = 15;
		public SA.StatesVariable playerState;

        public override void Execute()
        {
			playerState.value.rigid.velocity = new Vector2 (
				playerState.value.rigid.velocity.x,
                Mathf.Clamp(playerState.value.rigid.velocity.y, -maxFallVelocity, Mathf.Infinity)
				);
		}
	}
}