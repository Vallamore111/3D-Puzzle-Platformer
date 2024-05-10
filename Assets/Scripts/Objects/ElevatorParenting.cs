using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorParenting : MonoBehaviour
{
    public GameObject elevatorCam;
    private GameObject elevator;


    private void Awake() => elevator = GetComponentInParent<Elevator>().gameObject;


    private void OnTriggerEnter(Collider other)
    {
        CameraManager.instance.SwitchCamera(elevatorCam);
        PlatformParenting.HandlePlatformParenting(other.transform, elevator.transform);
    }


    private void OnTriggerExit(Collider other)
    {
        CameraManager.instance.SwitchCamera(elevatorCam);
        PlatformParenting.HandlePlatformParenting(other.transform, elevator.transform);
    }

}
