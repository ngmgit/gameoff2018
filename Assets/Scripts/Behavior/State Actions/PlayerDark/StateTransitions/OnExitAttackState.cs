﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Transitions/OnExitAttackState")]
    public class OnExitAttackState : StateActions
    {
        public override void Execute(StateManager states)
        {
            states.playerDark.AttackPrimaryType = -1;
			states.anim.SetInteger("AttackPrimaryType", states.playerDark.AttackPrimaryType);
            states.anim.SetBool("attackPrimary", false);
        }
    }
}
