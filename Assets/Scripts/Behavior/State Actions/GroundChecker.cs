using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
	[CreateAssetMenu(menuName="Actions/State Actions/Ground Checker")]
	public class GroundChecker : StateActions {

        public override void Execute(StateManager states)
        {
            Vector2 circleCollCenter = states.circleGroundCollider.bounds.center;

			RaycastHit2D downRayLeft = Physics2D.Raycast (circleCollCenter + new Vector2(-states.circleRadiusOffset, 0), Vector2.down, states.downRaySize);
			RaycastHit2D downRayRight = Physics2D.Raycast (circleCollCenter + new Vector2(states.circleRadiusOffset, 0), Vector2.down, states.downRaySize);
			RaycastHit2D downRay = Physics2D.Raycast (circleCollCenter, Vector2.down, states.downRaySize);

			if (downRayRight.collider != null || downRayLeft.collider != null || downRay.collider != null) {
				bool leftCollider = downRayLeft.collider != null && downRayLeft.collider.tag == states.platformTag;
				bool rightCollider = downRayRight.collider !=null && downRayRight.collider.tag == states.platformTag;
				bool centerCollider = downRay.collider !=null && downRay.collider.tag == states.platformTag;

				if (leftCollider || rightCollider || centerCollider) {
					states.isGrounded = true;
				}
			}
			else {
				states.isGrounded = false;
			}
        }
	}
}
