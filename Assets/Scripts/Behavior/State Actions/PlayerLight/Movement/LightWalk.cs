using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
	[CreateAssetMenu(menuName = "Actions/State Actions/Light Player/Walk")]
	public class LightWalk : StateActions
	{
        public AudioClip walkAudio;
		public override void Execute(StateManager states)
		{
            float finalSpeed = states.movementValues.speed * states.movementValues.dashSpeedMultiplier;
            states.rigid.velocity = new Vector2(states.movementValues.horizontal * finalSpeed,
                states.rigid.velocity.y);

            Vector3 currentlocalScale = states.mTransform.localScale;
            if (states.movementValues.horizontal > 0)
            {
                currentlocalScale.x = 1 * Mathf.Abs(currentlocalScale.x);
                states.mTransform.localScale = currentlocalScale;
            }
            else if (states.movementValues.horizontal < 0)
            {
                currentlocalScale.x = -1 * Mathf.Abs(currentlocalScale.x);
                states.mTransform.localScale = currentlocalScale;
            }

            // Make sure walk sound is played only when in walk state and audio clip is also set to walk audio clip
            if (states.isGrounded && !states.inputs.isDashHold && Mathf.Abs(states.movementValues.horizontal) > 0) {
                states.currentAudio.loop = true;
                states.currentAudio.clip = walkAudio;
                states.currentAudio.volume = Mathf.Abs(states.movementValues.horizontal);
                states.currentAudio.pitch = 1 + (Mathf.Abs(states.movementValues.horizontal) * 0.5f);
                if (!states.currentAudio.isPlaying)
                    states.currentAudio.Play();
            } else if (states.currentAudio.clip && states.currentAudio.clip.name.Equals(walkAudio.name)) {
                states.currentAudio.Stop();
            }   
		}
	}
}
