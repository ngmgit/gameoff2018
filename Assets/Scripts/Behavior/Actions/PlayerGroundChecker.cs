using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
	[CreateAssetMenu(menuName="Actions/Actions/Ground Checker")]
	public class PlayerGroundChecker : Action {

		public StatesVariable states;
		Vector2 circleCollCenter;
		Vector2 LeftRayPos;
		Vector2 RightRayPos;

		float prevY;

        public override void Execute()
        {
            circleCollCenter = states.value.circleGroundCollider.bounds.center;

			LeftRayPos = circleCollCenter + new Vector2(-states.value.circleRadiusOffset, 0);
			RightRayPos = circleCollCenter + new Vector2(states.value.circleRadiusOffset, 0);

			RaycastHit2D downRayLeft = Physics2D.Raycast (LeftRayPos, Vector2.down, states.value.downRaySize);
			RaycastHit2D downRayRight = Physics2D.Raycast (RightRayPos, Vector2.down, states.value.downRaySize);
			RaycastHit2D downRay = Physics2D.Raycast (circleCollCenter, Vector2.down, states.value.downRaySize);

			if (downRayRight.collider != null || downRayLeft.collider != null || downRay.collider != null)
			{
				bool leftCollider = downRayLeft.collider != null && downRayLeft.collider.tag == states.value.platformTag;
				bool rightCollider = downRayRight.collider !=null && downRayRight.collider.tag == states.value.platformTag;
				bool centerCollider = downRay.collider !=null && downRay.collider.tag == states.value.platformTag;

				if (leftCollider || rightCollider || centerCollider)
				{
					states.value.isGrounded = true;
					states.value.isFalling = false;
				}
			}
			else
			{
				if (states.value.rigid.velocity.y < 0)
					states.value.isFalling = true;
				else
					states.value.isFalling = false;

				states.value.isGrounded = false;
			}

			prevY = states.value.mTransform.position.y;
			DrawColliders(states.value.downRaySize);
        }

		private void DrawColliders(float raysize)
		{
			Debug.DrawLine(LeftRayPos, new Vector2(LeftRayPos.x, LeftRayPos.y - raysize));
			Debug.DrawLine(RightRayPos, new Vector2(RightRayPos.x, RightRayPos.y - raysize));
		}
	}
}
