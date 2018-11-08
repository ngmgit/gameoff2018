using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
	[CreateAssetMenu(menuName="Actions/Animation/Attack State Anim")]
    public class SetAnimForAttackState : StateActions
    {
        public override void Execute(StateManager states)
        {
            if (states.isAttackingUp)
			    states.anim.SetTrigger("attackPrimary");

			states.anim.SetInteger("AttackPrimaryType", states.AttackPrimaryType);
        }
    }
}
