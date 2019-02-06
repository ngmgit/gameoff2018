using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/Light Player/Wall Slide")]
    public class WallSlide : StateActions
    {
		public float idleSlideSpeed;
		public float activeSlideSpeed;
		public float fallSpeed;

        public override void Execute(StateManager states)
        {
			if (states.playerLight.isLedgeDetected && states.movementValues.vertical >= 0)
				return;

			if (!states.inputs.isJumpHold && states.playerLight.wallDetected)
			{
				states.rigid.AddForce(-Physics2D.gravity);

				// pressing down movement
				if (states.movementValues.vertical < 0)
				{
					states.rigid.velocity = new Vector2(0, activeSlideSpeed);
				} // Pressing towards the wall
				else if (!states.isFacingOppToWall() && Mathf.Abs(states.movementValues.horizontal) > 0.1f)
				{
					states.rigid.velocity = new Vector2(0, idleSlideSpeed);
				} // Free fall
				else
				{
					states.rigid.velocity = new Vector2(0, fallSpeed);
				}
			}
        }
    }
}
