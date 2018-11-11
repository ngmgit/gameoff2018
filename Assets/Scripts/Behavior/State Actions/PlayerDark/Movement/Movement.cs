using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/Movement")]
    public class Movement : StateActions
    {
        public override void Execute(StateManager states)
        {
            float finalSpeed = states.movementValues.speed * states.movementValues.dashSpeedMultiplier;
            states.rigid.velocity = new Vector2(states.movementValues.horizontal * finalSpeed,
                states.rigid.velocity.y);

            if (states.movementValues.horizontal > 0)
                states.mTransform.localScale = new Vector3(1, 1, 1);
            else if (states.movementValues.horizontal < 0)
                states.mTransform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
