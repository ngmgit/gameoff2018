using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeGrab : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/Light Player/Ledge Grab")]
    public class LedgeGrab : StateActions
    {
		private bool ledgeGrabOnceFlag = true;
		public float wallJumpForce;

        public override void Execute(StateManager states)
        {
            if (states.playerLight.isLedgeDetected && states.movementValues.vertical >= 0)
			{
				if (states.movementValues.vertical > 0 && ledgeGrabOnceFlag && states.rigid.constraints ==  RigidbodyConstraints2D.FreezePosition)
				{
					states.rigid.AddForce(Vector2.up * wallJumpForce, ForceMode2D.Impulse);
					states.rigid.constraints = RigidbodyConstraints2D.FreezeRotation;
					states.playerLight.canSwitchtoDoubleJumpState = true;
					ledgeGrabOnceFlag = false;
				}
				else if (ledgeGrabOnceFlag)
				{
					states.rigid.velocity = Vector2.zero;
					states.rigid.constraints = RigidbodyConstraints2D.FreezePosition;
				}
				return;
			}

			if (states.rigid.constraints ==  RigidbodyConstraints2D.FreezePosition)
			{
				states.rigid.constraints = RigidbodyConstraints2D.FreezeRotation;
			}

			ledgeGrabOnceFlag = true;
        }
    }
}