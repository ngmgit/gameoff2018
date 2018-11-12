using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Transitions/OnExitMovementState")]
    public class OnExitMovementState : StateActions
    {
        public override void Execute(StateManager state)
        {
            state.anim.SetFloat("moving", 0);
            state.anim.SetBool("dash", false);
            state.anim.SetBool("attackPrimary", true);
        }
    }
}