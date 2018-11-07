using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {

	public bool isGrounded = false;
	public string platformTag = "Platform";
	public float colliderHorizontalOffset = 0.05f;
	public float colliderVerticalOffset = 0.05f;

	private CircleCollider2D circleGroundCollider;
	private float circleRadiusOffset;
	private float downRaySize;

	private void Awake()
	{
		circleGroundCollider = GetComponent<CircleCollider2D>();
		circleRadiusOffset = circleGroundCollider.radius - colliderHorizontalOffset;
		downRaySize = circleGroundCollider.radius + colliderVerticalOffset;
	}

	private void FixedUpdate()
	{
		PlayerRaycast();
	}

	private void PlayerRaycast() {
		Vector2 circleCollCenter = circleGroundCollider.bounds.center;

		RaycastHit2D downRayLeft = Physics2D.Raycast (circleCollCenter + new Vector2(-circleRadiusOffset, 0), Vector2.down, downRaySize);
		RaycastHit2D downRayRight = Physics2D.Raycast (circleCollCenter + new Vector2(circleRadiusOffset, 0), Vector2.down, downRaySize);
		RaycastHit2D downRay = Physics2D.Raycast (circleCollCenter, Vector2.down, downRaySize);

		if (downRayRight.collider != null || downRayLeft.collider != null || downRay.collider != null) {
			bool leftCollider = downRayLeft.collider != null && downRayLeft.collider.tag == platformTag;
			bool rightCollider = downRayRight.collider !=null && downRayRight.collider.tag == platformTag;
			bool centerCollider = downRay.collider !=null && downRay.collider.tag == platformTag;

			if (leftCollider || rightCollider || centerCollider) {
				isGrounded = true;
			}
		}
		else {
			isGrounded = false;
		}
	}

	void OnDrawGizmos()
    {
		if (circleGroundCollider)
		{
			Vector2 circleCollCenter = circleGroundCollider.bounds.center;

			// Draw a yellow sphere at the transform's position
			Gizmos.color = Color.yellow;
			Gizmos.DrawLine(circleCollCenter,new Vector2(circleCollCenter.x, circleCollCenter.y - downRaySize));
			Gizmos.DrawLine(circleCollCenter + new Vector2(circleRadiusOffset, 0),
				new Vector2(circleCollCenter.x + circleRadiusOffset, circleCollCenter.y - downRaySize));
			Gizmos.DrawLine(circleCollCenter + new Vector2(-circleRadiusOffset, 0),
				new Vector2(circleCollCenter.x - circleRadiusOffset, circleCollCenter.y - downRaySize));
		}
    }
}
