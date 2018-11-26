﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
	[CreateAssetMenu(menuName = "Actions/State Actions/Light Player/Walk")]
	public class LightWalk : StateActions
	{
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
		}
	}
}
