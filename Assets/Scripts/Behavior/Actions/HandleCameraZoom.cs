using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName ="Actions/Mono Actions/Camera Zoom")]
    public class HandleCameraZoom : Action
    {
        public SO.TransformVariable actualCameraTransform;

        public InputButton aimInput;
        public float defaultZ;
        public float zoomedZ;

        public float speed = 9;
        float actualZ;

        private void OnEnable()
        {
            if (actualCameraTransform.value != null)
                defaultZ = actualCameraTransform.value.localPosition.z;
        }

        public override void Execute()
        {
            if (actualCameraTransform.value == null)
                return;

            float targetZ = defaultZ;

            if (aimInput.isPressed)
            {
                targetZ = zoomedZ;
            }

            actualZ = Mathf.Lerp(actualZ, targetZ, speed * Time.deltaTime);

            Vector3 targetPosition = Vector3.zero;
            targetPosition.z = actualZ;
            actualCameraTransform.value.localPosition = targetPosition;


        }
    }
}
