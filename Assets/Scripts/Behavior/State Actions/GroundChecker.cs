using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
	[CreateAssetMenu(menuName="Actions/State Actions/Ground Checker")]
	public class GroundChecker : StateActions {
		Vector2 circleCollCenter;
		Vector2 LeftRayPos;
		Vector2 RightRayPos;

        public override void Execute(StateManager states)
        {
            circleCollCenter = states.circleGroundCollider.bounds.center;

			LeftRayPos = circleCollCenter + new Vector2(-states.circleRadiusOffset, 0);
			RightRayPos = circleCollCenter + new Vector2(states.circleRadiusOffset, 0);

			RaycastHit2D downRayLeft = Physics2D.Raycast (LeftRayPos, Vector2.down, states.downRaySize);
			RaycastHit2D downRayRight = Physics2D.Raycast (RightRayPos, Vector2.down, states.downRaySize);
			RaycastHit2D downRay = Physics2D.Raycast (circleCollCenter, Vector2.down, states.downRaySize);

			if (downRayRight.collider != null || downRayLeft.collider != null || downRay.collider != null)
			{
				bool leftCollider = downRayLeft.collider != null && downRayLeft.collider.tag == states.platformTag;
				bool rightCollider = downRayRight.collider !=null && downRayRight.collider.tag == states.platformTag;
				bool centerCollider = downRay.collider !=null && downRay.collider.tag == states.platformTag;

				if (leftCollider || rightCollider || centerCollider)
				{
					states.isGrounded = true;
				}
			}
			else
			{
				states.isGrounded = false;
			}

			DrawColliders(states.downRaySize);
        }

		private void DrawColliders(float raysize)
		{
			Debug.DrawLine(LeftRayPos, new Vector2(LeftRayPos.x, LeftRayPos.y - raysize));
			Debug.DrawLine(RightRayPos, new Vector2(RightRayPos.x, RightRayPos.y - raysize));
		}
	}
}
