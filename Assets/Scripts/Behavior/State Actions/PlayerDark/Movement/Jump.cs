﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/Jump")]
    public class Jump : StateActions
    {
		public float jumpForce = 0.6f;
		public float jumpTime = 0.3f;
		public float initJumpMultiplier = 15;
		public AudioClip jumpAudio;

		private bool isJumping = false;
		private float jumpTimeCounter;

        public override void Execute(StateManager states)
        {
            if (states.inputs.isJumpDown && states.isGrounded)
			{
				states.rigid.velocity = Vector2.zero;
				isJumping = true;
				jumpTimeCounter = jumpTime;
				states.rigid.AddForce(Vector2.up * jumpForce * initJumpMultiplier, ForceMode2D.Impulse);

				PlayJumpSound(states);
			}

			if (states.inputs.isJumpHold && isJumping)
			{
				if (jumpTimeCounter > 0)
				{
					states.rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
					jumpTimeCounter -= Time.fixedDeltaTime;
				}
				else
					isJumping = false;
			}

			if (states.inputs.isJumpUp)
			{
				isJumping = false;
			}
        }

		private void PlayJumpSound(StateManager states)
		{
			states.currentAudio.Stop();
			states.currentAudio.clip = jumpAudio;
			states.currentAudio.Play();
		}
    }
}
