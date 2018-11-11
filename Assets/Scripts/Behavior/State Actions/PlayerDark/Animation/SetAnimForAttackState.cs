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
            if (states.inputs.isAttackingDown)
                states.anim.SetBool("attackPrimary", states.inputs.isAttackingDown);

			states.anim.SetInteger("AttackPrimaryType", states.AttackPrimaryType);
        }
    }
}
