using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DarkBlobNPCScript : SimpleNPCBase {

	[Header("NPC specific config")]
	public float attackDistance;
	public float jumpDuration;
	public float jumpPower;
	public float delayDuration;

	[HideInInspector]
	public float delayTime;
	[HideInInspector]
	public bool prevGrounded;

	private Vector2 jumpPosition;

	// Use this for initialization
	protected override void Start ()
	{
		base.Start();

		delayTime = delayDuration;

		// initialize the behavior scripts
		anim.GetBehaviour<IdleSMB>().MonoScriptRef = this;
		anim.GetBehaviour<WalkSMB>().MonoScriptRef = this;
		anim.GetBehaviour<DarkBlobAttackSMB>().MonoScriptRef = this;
		anim.GetBehaviour<HurtSMB>().MonoScriptRef = this;

	}

	private void Update()
	{
		delayTime += Time.deltaTime;

		float currentDistance = Vector2.Distance(transform.position, PlayerTransform.value.position);

		if (currentDistance < attackDistance && canInitiateAttack()) {
			StopIdleCR();
			TurnTowardPlayer();

			ResetDelayTime();
			canAttack = true;
			jumpPosition = PlayerTransform.value.position;
			rigid.DOJump(jumpPosition, jumpPower, 1, jumpDuration);
		}

		if (!isGrounded && canAttack)
			prevGrounded = true;
	}

	protected override void FixedUpdate()
	{
		base.FixedUpdate();

		if (isGrounded && canMove && !canAttack)
			rigid.velocity = transform.right * mDirection.x * speed;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		switch(other.gameObject.tag)
		{
			case "PlayerWeapon":
				{
					isHurt = true;
					canAttack = false;
					anim.SetTrigger(DefaultAnimParameters.Hurt);
				}
				break;
		}
	}

	private bool canInitiateAttack()
	{
		if (!canAttack && delayTime > delayDuration && isGrounded)
			return true;

		return false;
	}

	public void ResetDelayTime()
	{
		delayTime = 0;
	}
}
