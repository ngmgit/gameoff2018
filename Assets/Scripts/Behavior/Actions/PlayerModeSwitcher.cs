using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
	[CreateAssetMenu(menuName="Actions/Actions/PlayerModeSwitcher")]
	public class PlayerModeSwitcher : Action
	{
		public SO.GameEvent ModeChangedEvent;

		[Header("Player Reference GO")]
		public SA.StatesVariable lightPlayer;
		public SA.StatesVariable darkPlayer;
		public Vector2 lightPlayerOffset;

		[Header("Switch Button")]
		public SO.BoolVariable isSwitchHold;
		public SO.BoolVariable isSwitchUp;

		private bool darkActive;
		private bool canSwitch;

		public void OnAwake()
		{
			canSwitch = true;
			darkPlayer.value.gameObject.SetActive(false);
		}

		public override void Execute()
        {
			Vector3 tempPos;

			if (canSwitch && isSwitchHold.value)
			{
				if (darkActive)
				{
					darkPlayer.value.gameObject.SetActive(false);
					lightPlayer.value.gameObject.SetActive(true);

					tempPos = darkPlayer.value.mTransform.position;
					tempPos.y = tempPos.y + lightPlayerOffset.y;
					tempPos.z = 0;
					lightPlayer.value.mTransform.position = tempPos;
					darkActive = false;
				}
				else
				{
					darkPlayer.value.gameObject.SetActive(true);
					lightPlayer.value.gameObject.SetActive(false);

					tempPos = lightPlayer.value.mTransform.position;
					tempPos.z = 0;
					darkPlayer.value.mTransform.position = tempPos;
					darkActive = true;
				}
				ModeChangedEvent.Raise();
				canSwitch = false;
			}

			if (isSwitchUp.value)
				canSwitch = true;
		}

		public Transform GetActiveModeCharacter()
		{
			if (darkActive)
				return darkPlayer.value.anim.transform;

			return lightPlayer.value.anim.transform;
		}
	}
}
