using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCineMachineSetFollow : MonoBehaviour
{

	public SA.PlayerModeSwitcher playerModeSwitcher;

	Cinemachine.CinemachineVirtualCamera vCam;

	// Use this for initialization
	void Start ()
	{
		vCam = GetComponent<Cinemachine.CinemachineVirtualCamera>();
	}

	public void TargetChanged()
	{
		vCam.m_Follow = playerModeSwitcher.GetActiveModeCharacter();
	}
}
