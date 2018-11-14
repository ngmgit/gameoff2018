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
            public Vector3 moveDirection;
            public float speed = 8;
            [HideInInspector]
            public float dashSpeedMultiplier = 1;
        }

        [HideInInspector]
        public InputsHolder inputs;

        [System.Serializable]
        public class InputsHolder
        {
            public bool isJumpHold;
            public bool isJumpDown;
            public bool isJumpUp;
            public bool isAttacking;
            public bool isAttackingDown;
            public bool isAttackingUp;
            public bool isVanish;
            public bool isDash;
        }

        [HideInInspector]
        public int AttackPrimaryType;
        [HideInInspector]
        public bool canSkipAttackAnim = false;
        [HideInInspector]
        public AudioSource currentAudio;

        [Header("State Config")]
        public StateActions initActionsBatch;
        public State currentState;

        // Ground Check State
        [Header("Ground Collider Details")]
        public bool isGrounded = false;
        public string platformTag = "Platform";
        public float colliderHorizontalOffset = 0.05f;
        public float colliderVerticalOffset = 0.05f;

        [HideInInspector]
        public CircleCollider2D circleGroundCollider;
        [HideInInspector]
        public float circleRadiusOffset;
        [HideInInspector]
        public float downRaySize;

        [HideInInspector]
        public Animator anim;
        [HideInInspector]
        public float delta;
        [HideInInspector]
        public Transform mTransform;
        [HideInInspector]
        public Rigidbody2D rigid;
        [HideInInspector]
        public LayerMask ignoreLayers;
        [HideInInspector]

        private void Start()
        {
            Cursor.visible = false;

            mTransform = this.transform;
            rigid = GetComponent<Rigidbody2D>();

            anim = GetComponentInChildren<Animator>();

            circleGroundCollider = GetComponent<CircleCollider2D>();
		    circleRadiusOffset = circleGroundCollider.radius - colliderHorizontalOffset;
		    downRaySize = circleGroundCollider.radius + colliderVerticalOffset;
            currentAudio = GetComponent<AudioSource>();
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

        public void PlayAudio(float vol = 1)
        {
            currentAudio.Stop();
            currentAudio.volume = vol;
            currentAudio.Play();
        }
    }
}
