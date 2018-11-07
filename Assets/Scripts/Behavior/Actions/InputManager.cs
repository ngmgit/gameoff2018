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
        public InputButton aimInput;
        public InputButton shootInput;

        public float moveAmount;
        public Vector3 moveDirection;

        public SO.TransformVariable cameraTransform;
        public SO.TransformVariable pivotTransform;

        public StatesVariable playerState;

        public override void Execute()
        {
            moveAmount = Mathf.Clamp01(Mathf.Abs(horizontal.value) + Math.Abs(vertical.value));

            if (cameraTransform.value != null)
            {
                moveDirection = cameraTransform.value.forward * vertical.value;
                moveDirection += cameraTransform.value.right * horizontal.value;
                moveDirection.Normalize();
            }

            if (playerState != null)
            {
                playerState.value.movementValues.horizontal = horizontal.value;
                playerState.value.movementValues.vertical = vertical.value;
                playerState.value.movementValues.moveAmount = moveAmount;
                playerState.value.movementValues.moveDirection = moveDirection;
                playerState.value.isAiming = aimInput.isPressed;
                playerState.value.isShooting = shootInput.isPressed;

                playerState.value.movementValues.lookDirection = cameraTransform.value.forward;

                Ray ray = new Ray(pivotTransform.value.position, pivotTransform.value.forward);
                playerState.value.movementValues.aimPosition = ray.GetPoint(100);
            }
        }
    }
}
