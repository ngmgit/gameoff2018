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
		public float wallJumpForce;

        public override void Execute(StateManager states)
        {
            if (states.playerLight.isLedgeDetected && states.movementValues.vertical >= 0)
			{
				if (states.movementValues.vertical > 0.1 && states.isFacingOppToWall() && states.movementValues.horizontal < 0)
				{
					states.rigid.constraints = RigidbodyConstraints2D.FreezeRotation;
					states.rigid.AddForce(Vector2.up * wallJumpForce, ForceMode2D.Impulse);
					states.playerLight.canSwitchtoDoubleJumpState = true;
				}
				else
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
        }
    }
}