using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName ="Inputs/Input Manager")]
    public class InputManager : Action
    {
        [Header("Player State")]
        public StatesVariable playerState;

        [Header("Axis")]
        public InputAxis horizontal;
        public InputAxis vertical;

        [Header("Inputs")]
        public SO.BoolVariable jump;
        public SO.BoolVariable jumpKeyDown;
        public SO.BoolVariable jumpKeyUp;
        public SO.BoolVariable dash;
        public SO.BoolVariable dashHold;
        public SO.BoolVariable attack;
        public SO.BoolVariable attackDown;
        public SO.BoolVariable attackUp;
        public InputButton vanish;

        [Header("Others")]
        public Vector3 moveDirection;

        public override void Execute()
        {
            if (horizontal.value < 0 && playerState.value.movementValues.moveDirection.x < 0)
                moveDirection = Vector2.left;
            else if (horizontal.value > 0 && playerState.value.movementValues.moveDirection.x > 0)
                moveDirection = Vector2.right;

            if (playerState != null)
            {
                playerState.value.movementValues.horizontal = horizontal.value;
                playerState.value.movementValues.vertical = vertical.value;
                playerState.value.movementValues.moveDirection = moveDirection;

                playerState.value.inputs.isJumpHold = jump.value;
                playerState.value.inputs.isJumpDown = jumpKeyDown.value;
                playerState.value.inputs.isJumpUp = jumpKeyUp.value;

                playerState.value.inputs.isDash = dash.value;
                playerState.value.inputs.isDashHold = dashHold.value;

                playerState.value.inputs.isAttacking = attack.value;
                playerState.value.inputs.isAttackingDown = attackDown.value;
                playerState.value.inputs.isAttackingUp = attackUp.value;

                //playerState.value.isVanish = vanish.isPressed;
            }
        }
    }
}
