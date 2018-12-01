using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [System.Serializable]
    public struct PlayerDarkState
    {
        [HideInInspector]
        public int AttackPrimaryType;
        [HideInInspector]
        public bool canSkipAttackAnim;
    }

    [System.Serializable]
    public struct PlayerLightState
    {
        [HideInInspector]
        public BoxCollider2D boxCollider;
        public bool canDoubleJump;
        public bool canSwitchtoDoubleJumpState;
        public bool wallDetected;
        public bool isLedgeDetected;
        public bool isCrouchWallDetected;

        [Header("Ray Positions")]
		public Transform topRayPosition;
		public Transform middleRayPosition;
		public Transform bottomRayPosition;
    }

    public class StateManager : MonoBehaviour
    {
        // *** Player Dark ***
        public PlayerDarkState playerDark;

        // *** Player Light ***
        public PlayerLightState playerLight;

        // *** Common ***
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
            public bool isDashHold;
        }

        [HideInInspector]
        public AudioSource currentAudio;

        [Header("State Config")]
        public StateActions initActionsBatch;
        public State currentState;

        // Ground Check State
        [Header("Ground Collider Details")]
        public bool isGrounded;
        public bool isFalling;
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

            circleGroundCollider = GetComponentInChildren<CircleCollider2D>();
		    circleRadiusOffset = circleGroundCollider.radius - colliderHorizontalOffset;
		    downRaySize = circleGroundCollider.radius + colliderVerticalOffset;

            playerLight.boxCollider = GetComponentInChildren<BoxCollider2D>();

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

        public bool isFacingOppToWall()
		{
			if (mTransform.localScale.x > 0)
			{
				if (movementValues.horizontal > 0.1)
					return false;
			}
			else
			{
				if (movementValues.horizontal < 0.1)
					return false;
			}

			return true;
		}
    }
}
