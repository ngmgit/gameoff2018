using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/Movement")]
    public class Movement : StateActions
    {
		public float speed = 8;

        public override void Execute(StateManager states)
        {
            states.rigid.velocity = new Vector2(states.movementValues.horizontal * speed, states.rigid.velocity.y);
            states.mTransform.GetChild(0).localScale = new Vector2(states.movementValues.moveDirection.x, 1);
        }
    }
}
