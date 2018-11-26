using System.Collections;
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
		[Range(0,1)]
		public float audioVolume = 1;
		public float delayJumpTime = 0.3f;

		private bool isJumping = false;
		private float jumpTimeCounter;
		private float fallDelayJumpTime = 0;

        public override void Execute(StateManager states)
        {
			if (!states.isGrounded)
			{
				fallDelayJumpTime += Time.deltaTime;
			}
			else
			{
				fallDelayJumpTime = 0;
				isJumping = false;
			}

            if (states.inputs.isJumpHold && states.isGrounded && !isJumping)
			{
				isJumping = true;
				jumpTimeCounter = jumpTime;
				states.rigid.velocity = new Vector2 (states.rigid.velocity.x,  initJumpMultiplier);

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
			if (jumpAudio)
			{
				states.currentAudio.clip = jumpAudio;
				states.PlayAudio(audioVolume);
			}
		}
    }
}
