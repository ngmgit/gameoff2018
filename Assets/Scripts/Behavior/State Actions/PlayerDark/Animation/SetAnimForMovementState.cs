using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
	[CreateAssetMenu(menuName="Actions/Animation/Movement State Anim")]
	public class SetAnimForMovementState : StateActions {

		public override void Execute(StateManager states)
        {
			states.anim.SetBool("isGrounded", states.isGrounded);
			states.anim.SetFloat("moving", Mathf.Abs(states.movementValues.horizontal));
			states.anim.SetBool("dash", states.inputs.isDash);

			if(!states.currentAudio.isPlaying && states.inputs.isDash)
            {
                states.currentAudio.Stop();
                states.currentAudio.Play();
            }
		}
	}
}
