using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    public class StateManager : MonoBehaviour
    {
        public MovementValues movementValues;

        [System.Serializable]
        public class MovementValues
        {
            public float horizontal;
            public float vertical;
            public float moveAmount;
            public Vector3 moveDirection;
            public Vector3 lookDirection;
            public Vector3 aimPosition;
        }

        public bool isAiming;
        public bool isInteracting;
        public bool isShooting;

        public State currentState;

        [HideInInspector]
        public Animator anim;

        [HideInInspector]
        public float delta;
        [HideInInspector]
        public Transform mTransform;
        [HideInInspector]
        public Rigidbody rigid;
        [HideInInspector]
        public LayerMask ignoreLayers;
        [HideInInspector]

        public StateActions initActionsBatch;

        private void Start()
        {
            Cursor.visible = false;

            mTransform = this.transform;
            rigid = GetComponent<Rigidbody>();
            rigid.drag = 4;
            rigid.angularDrag = 999;
            rigid.constraints = RigidbodyConstraints.FreezeRotation;

            int controllerLayer = LayerMask.NameToLayer("Controller");
            int ignoreRayCastLayer = LayerMask.NameToLayer("Ignore Raycast");

            ignoreLayers = ~(1 << controllerLayer | 1 << ignoreRayCastLayer);

            anim = GetComponentInChildren<Animator>();

            initActionsBatch.Execute(this);
        }

        private void FixedUpdate()
        {
            delta = Time.deltaTime;

            if (currentState != null)
                currentState.FixedTick(this);
        }

        private void Update()
        {
            delta = Time.deltaTime;

            if(currentState != null)
                currentState.Tick(this);
        }
    }
}
