using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.U2D;

namespace SA
{
	[CreateAssetMenu(menuName = "Actions/State Actions/Light Player/Set VCam On Wall")]
	public class SetVCamOnWall : StateActions
	{
		public float lookAheadTime;
		public float lookAheadSmoothness;

		public override void Execute(StateManager states)
		{
			// var vCamFramingT = states.vCamAir.GetCinemachineComponent<CinemachineFramingTransposer>();
			// vCamFramingT.m_LookaheadTime = lookAheadTime;
			// vCamFramingT.m_LookaheadSmoothing = lookAheadSmoothness;
		}
	}
}
