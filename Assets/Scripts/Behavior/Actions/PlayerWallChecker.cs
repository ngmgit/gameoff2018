using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
	[CreateAssetMenu(menuName="Actions/Actions/WallChecker")]
	public class PlayerWallChecker : Action
	{

		public StatesVariable states;

		public LayerMask wallLayers;
		public LayerMask ledgeLayer;
		public float rayLength;

		[SerializeField]
		private bool isTopDetected;
		[SerializeField]
		private bool isBottomDetected;
		[SerializeField]
		private bool isMiddleDetected;
		[SerializeField]
		private bool isLedgeDetected;

		public override void Execute()
        {
			float direction = states.value.mTransform.localScale.x;

			Vector2 topRayEnd = new Vector2(states.value.playerLight.topRayPosition.position.x + rayLength * direction,
				states.value.playerLight.topRayPosition.position.y);
			Debug.DrawLine(states.value.playerLight.topRayPosition.position, topRayEnd);
			isTopDetected = Physics2D.Linecast(states.value.playerLight.topRayPosition.position, topRayEnd, wallLayers);

			Vector2 middleRayEnd = new Vector2(states.value.playerLight.middleRayPosition.position.x + rayLength * direction,
				states.value.playerLight.middleRayPosition.position.y);
			Debug.DrawLine(states.value.playerLight.middleRayPosition.position, middleRayEnd);
			isBottomDetected = Physics2D.Linecast(states.value.playerLight.middleRayPosition.position, middleRayEnd, wallLayers);

			Vector2 bottomRayEnd = new Vector2(states.value.playerLight.bottomRayPosition.position.x + rayLength * direction,
				states.value.playerLight.bottomRayPosition.position.y);
			Debug.DrawLine(states.value.playerLight.bottomRayPosition.position, bottomRayEnd);
			isMiddleDetected = Physics2D.Linecast(states.value.playerLight.bottomRayPosition.position, bottomRayEnd, wallLayers);


			if (isTopDetected && isBottomDetected && isMiddleDetected)
				states.value.playerLight.wallDetected = true;
			else
				states.value.playerLight.wallDetected = false;


			isLedgeDetected = Physics2D.Linecast(states.value.playerLight.topRayPosition.position, topRayEnd, ledgeLayer);
			states.value.playerLight.isLedgeDetected = isLedgeDetected;
		}
	}
}
