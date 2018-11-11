using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName="Actions/State Actions/Attack")]
	public class Attack : StateActions {
        public float midHoldTime = 0.5f;
        public float longHoldTime = 1.5f;

        private float delayCounter = 0;
        private bool inAttackMode = false;

		public override void Execute(StateManager states)
		{
            states.AttackPrimaryType = -1;

            if (states.inputs.isAttackingDown)
            {
                delayCounter = 0;
                inAttackMode = true;
            }


            delayCounter += Time.deltaTime;

            if (states.inputs.isAttacking)
            {
                if (inAttackMode)
                {
                    if (delayCounter > midHoldTime && states.movementValues.vertical < -0.1f)
                    {
                        states.AttackPrimaryType = AttackTypes.PrimaryAttack.GroundCrushAttack;
                        SetDefaults();
                    }
                    else if (delayCounter > midHoldTime && (states.movementValues.vertical > -0.1f && states.movementValues.vertical < 0.1f))
                    {
                        states.AttackPrimaryType = AttackTypes.PrimaryAttack.SlashInFront;
                        SetDefaults();
                    }
                }
            }

            if (states.inputs.isAttackingUp)
            {
                if (states.AttackPrimaryType == -1 && inAttackMode)
                {
                    if (delayCounter < midHoldTime)
                        states.AttackPrimaryType = AttackTypes.PrimaryAttack.Normal;
                    else if (delayCounter < longHoldTime)
                        states.AttackPrimaryType = AttackTypes.PrimaryAttack.SlashInFront;
                    else
                        states.AttackPrimaryType = AttackTypes.PrimaryAttack.GroundCrushAttack;
                }

                SetDefaults();
            }
		}

        private void SetDefaults()
        {
            delayCounter = 0;
            inAttackMode = false;
        }
	}
}
