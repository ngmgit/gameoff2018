using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  SA
{
	public class FixCrouchColliderBug : MonoBehaviour
	{
		public StatesVariable state;

		void OnTriggerStay2D(Collider2D other)
		{
			if ( other.gameObject.tag == "Platform")
				state.value.playerLight.isCrouchWallDetected = true;
		}

		void OnTriggerExit2D(Collider2D other)
		{
			if ( other.gameObject.tag == "Platform" )
				state.value.playerLight.isCrouchWallDetected = false;
		}
	}
}