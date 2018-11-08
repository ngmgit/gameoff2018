using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName="Actions/State Actions/Attack")]
	public class Attack : StateActions {
        public float midHoldTime = 1f;
        public float longHoldTime = 1.5f;

        public float delayCounter = 0;

		public override void Execute(StateManager states)
		{
            states.AttackPrimaryType = -1;
            states.anim.SetInteger("AttackPrimaryType", states.AttackPrimaryType);

            if (states.isAttackingDown)
                delayCounter = 0;

            delayCounter += Time.deltaTime;

            if (states.isAttackingUp)
            {
                float currentDelayCounter = delayCounter;

                if (currentDelayCounter < midHoldTime)
                    states.AttackPrimaryType = AttackTypes.PrimaryAttack.Normal;
                else if (currentDelayCounter < longHoldTime)
                    states.AttackPrimaryType = AttackTypes.PrimaryAttack.SlashInFront;
                else
                    states.AttackPrimaryType = AttackTypes.PrimaryAttack.GroundCrushAttack;

                delayCounter = 0;
            }
		}
	}
}
