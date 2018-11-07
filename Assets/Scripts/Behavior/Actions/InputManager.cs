using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName ="Inputs/Input Manager")]
    public class InputManager : Action
    {
        public InputAxis horizontal;
        public InputAxis vertical;

        public SO.BoolVariable jump;
        public SO.BoolVariable jumpKeyDown;
        public SO.BoolVariable jumpKeyUp;
        public InputButton dash;
        public InputButton attack;
        public InputButton vanish;

        public Vector3 moveDirection;

        public StatesVariable playerState;

        public override void Execute()
        {
            if (horizontal.value < 0)
                moveDirection = Vector2.left;
            else
                moveDirection = Vector2.right;

            if (playerState != null)
            {
                playerState.value.movementValues.horizontal = horizontal.value;
                //playerState.value.movementValues.vertical = vertical.value;
                playerState.value.movementValues.moveDirection = moveDirection;

                playerState.value.isJumpHold = jump.value;
                playerState.value.isJumpDown = jumpKeyDown.value;
                playerState.value.isJumpUp = jumpKeyUp.value;
                //playerState.value.isAttacking = attack.isPressed;
                //playerState.value.isVanish = vanish.isPressed;
            }
        }
    }
}
