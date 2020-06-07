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
    [Header("Cam and Player State")]
    public StatesVariable playerState;
    public Cinemachine.CinemachineVirtualCamera vCam1;
    private float fallDelay;


    private void Update()
    {
      Execute();
    }

    public void Execute()
    {
      if (playerState.value.mTransform.gameObject.activeSelf)
      {
        if (CanSwitchToAirCamera())
          vCam1.gameObject.SetActive(false);
        else
          vCam1.gameObject.SetActive(true);
      }
    }

    private bool CanSwitchToAirCamera()
    {
      if (
        (playerState.value.playerLight.wallDetected ||
          playerState.value.anim.GetCurrentAnimatorStateInfo(0).IsName("Acrobatics.Sommersault")
        ) &&
        !playerState.value.isGrounded)
        return true;

      return false;
    }
  }
}