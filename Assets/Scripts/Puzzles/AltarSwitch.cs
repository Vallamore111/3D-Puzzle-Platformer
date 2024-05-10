using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarSwitch : MonoBehaviour
{
    public GameObject altarCamera;
    public Collider altarCollider;
    private AltarPuzzle altarPuzzle;
    private InputManager inputManager;
    [System.NonSerialized] public AltarButton[] altarButtons;
    [System.NonSerialized] public GameObject activeButton;


    private void Awake()
    {
        altarButtons = GetComponentsInChildren<AltarButton>();
        altarPuzzle = FindObjectOfType<AltarPuzzle>();
        inputManager = FindObjectOfType<InputManager>();
    }


    private void Update()
    {
        if (!inputManager.rightClick) return;

        ExitAltarView();
    }


    public void AltarClicked()
    {
        CameraManager.instance.SwitchCamera(altarCamera);
        ToggleCollider();
    }


    public void ToggleCollider()
    {
        altarCollider.enabled = !altarCollider.enabled;
    }


    public void ToggleActiveButton()
    {
        foreach (var button in altarButtons)
        {
            if (button.gameObject != activeButton)
            { button.transform.localPosition = Vector3.zero; }
        }
    }


    public void ExitAltarView()
    {
        if (altarCamera.activeInHierarchy)
        { 
            ToggleCollider();
            altarPuzzle.CheckIfSolved();
            CameraManager.instance.SwitchCamera(altarCamera);
        }
    }



}
