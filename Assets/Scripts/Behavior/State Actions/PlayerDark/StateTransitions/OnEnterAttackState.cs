using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
	[CreateAssetMenu(menuName = "Actions/State Transitions/OnEnterAttackState")]
	public class OnEnterAttackState : StateActions
    {
        public override void Execute(StateManager states)
        {
			states.rigid.velocity = new Vector2(states.rigid.velocity.x/4,states.rigid.velocity.y);
		}
	}
}