using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject mainCameraObject;
    public GameObject thirdPersonCamera;
    private GameObject[] secondaryCameras;
    public static CameraManager instance;
    [System.NonSerialized] public bool secondaryCameraActive;



    private void Awake()
    {
        instance = this;
        mainCamera = Camera.main;
        mainCameraObject = mainCamera.gameObject;
    }


    private void Start()
    {
        secondaryCameras = GameObject.FindGameObjectsWithTag("SecondaryCam");
        DisableSecondaryCams(secondaryCameras);
    }


    public void SwitchCamera(GameObject newCamera)
    {
        if (newCamera == null) return;

        thirdPersonCamera.SetActive(!thirdPersonCamera.activeInHierarchy);
        newCamera.SetActive(!newCamera.activeInHierarchy);

        UIManager.instance.ShowHideCursorImage();
        secondaryCameraActive = !secondaryCameraActive;
    }


    public void DisableSecondaryCams(GameObject[] cams)
    {
        foreach (var cam in cams)
        {
            cam.SetActive(!cam.activeInHierarchy);
        }
    }
}
