using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.U2D;

namespace SA
{
    //[CreateAssetMenu(menuName = "Actions/Loaders/Cinemachine Zone Setup")]
    public class CinemachineZoneSetup : MonoBehaviour
    {
				[Header("Pixel Camera PPU Config")]
				public float defaultPixelCamPPU;
				public float inAirPixelCamPPU;
				public float currentPixelCamPPU;
				public float lerpSpeed;

				[Header("Cam and Player State")]
				public StatesVariable playerState;
				public Cinemachine.CinemachineVirtualCamera vCam1;
				public Cinemachine.CinemachineVirtualCamera vCam2;

				private PixelPerfectCamera pixelPerfectCamRef;


				private bool defaulEnabled;
				private float groundDelayCounter;
				private float airDelayCounter;
				private float fallDelay;

				private void Start()
				{
					currentPixelCamPPU = defaultPixelCamPPU;
					pixelPerfectCamRef = GetComponent<PixelPerfectCamera>();
				}

				private void Update()
				{
					Execute();

					if (playerState.value.isGrounded)
						fallDelay = 0;
				}

						public void Execute()
						{
					if (playerState.value.mTransform.gameObject.activeSelf)
					{
						if (CanSwitchToAirCamera())
							SetInAirZoneConfig();
						else
							SetOnGroundZoneConfig();

						SetCameraConfig();
					}
						}

				private bool CanSwitchToAirCamera()
				{
					if (
						( playerState.value.playerLight.wallDetected ||
							CheckIfCanSetForFall() ||
							playerState.value.anim.GetCurrentAnimatorStateInfo(0).IsName("Acrobatics.Sommersault")
						)  &&
						!playerState.value.isGrounded)
						return true;

					return false;
				}

				private bool CheckIfCanSetForFall()
				{
					fallDelay += Time.deltaTime;
					if (fallDelay > 0.5f)
						return true;

					return false;
				}

				private void SetOnGroundZoneConfig()
				{
					airDelayCounter = 0;
					defaulEnabled = true;
					groundDelayCounter += Time.deltaTime;

					if (groundDelayCounter > 1)
						currentPixelCamPPU = Mathf.Lerp(currentPixelCamPPU, defaultPixelCamPPU, Time.deltaTime * lerpSpeed);
				}

				private void SetInAirZoneConfig()
				{
					groundDelayCounter = 0;
					defaulEnabled = false;
					airDelayCounter += Time.deltaTime;

					if (airDelayCounter > 1)
						currentPixelCamPPU = Mathf.Lerp(currentPixelCamPPU, inAirPixelCamPPU, Time.deltaTime * lerpSpeed);
				}

				private void SetCameraConfig()
				{
					vCam1.gameObject.SetActive(defaulEnabled);

					currentPixelCamPPU = Mathf.Clamp(currentPixelCamPPU, inAirPixelCamPPU, defaultPixelCamPPU);

					pixelPerfectCamRef.assetsPPU = (int)currentPixelCamPPU;
				}

				IEnumerator WaitAndDoSomething() {
					yield return new WaitForSeconds(5f);
					// do something
				}
    }
}