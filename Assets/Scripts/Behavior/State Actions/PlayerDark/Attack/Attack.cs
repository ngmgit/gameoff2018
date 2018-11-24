using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName="Actions/State Actions/Attack")]
	public class Attack : StateActions {
        public float midHoldTime = 0.5f;
        public float longHoldTime = 1.5f;

        [Header("Attack Audio")]
        public AudioClip NormalAttack;
        public AudioClip Slash;
        public AudioClip InitChargeSlam;

        private float delayCounter = 0;
        private bool inAttackMode = true;

		public override void Execute(StateManager states)
		{
            states.playerDark.AttackPrimaryType = -1;

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
                        states.currentAudio.clip = InitChargeSlam;
                        states.playerDark.AttackPrimaryType = AttackTypes.PrimaryAttack.GroundCrushAttack;
                        SetDefaults();
                    }
                    else if (delayCounter > midHoldTime && (states.movementValues.vertical > -0.1f && states.movementValues.vertical < 0.1f))
                    {
                        states.currentAudio.clip = Slash;
                        states.playerDark.AttackPrimaryType = AttackTypes.PrimaryAttack.SlashInFront;
                        SetDefaults();
                    }
                }
            }

            if (states.inputs.isAttackingUp)
            {
                if (states.playerDark.AttackPrimaryType == -1 && inAttackMode)
                {
                    if (delayCounter < midHoldTime)
                    {
                        states.currentAudio.clip = NormalAttack;
                        states.playerDark.AttackPrimaryType = AttackTypes.PrimaryAttack.Normal;
                    }
                    else if (delayCounter < longHoldTime)
                    {
                        states.currentAudio.clip = Slash;
                        states.playerDark.AttackPrimaryType = AttackTypes.PrimaryAttack.SlashInFront;
                    }
                    else
                    {
                        states.currentAudio.clip = InitChargeSlam;
                        states.playerDark.AttackPrimaryType = AttackTypes.PrimaryAttack.GroundCrushAttack;
                    }
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
