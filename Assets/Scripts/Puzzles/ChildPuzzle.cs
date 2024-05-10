using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildPuzzle : MonoBehaviour, IHandleCursor
{
    public GameObject[] allPieces;
    public GameObject key;
    public GameObject puzzleCam;


    private void Start()
    {
        ToggleColliders();
        key.SetActive(false);
    }


    public void CheckIfSolved()
    {
        foreach (var piece in allPieces)
        {
            if (piece.transform.localPosition == Vector3.zero)
            { continue; }
            else return;
        }
        SolvePuzzle();
    }


    private void SolvePuzzle()
    {
        StartCoroutine(FindObjectOfType<UIManager>().PopupTextCoroutine("Puzzle Solved!"));
        CameraManager.instance.SwitchCamera(puzzleCam);
        key.SetActive(true);
    }


    private void ToggleColliders()
    {
        foreach (var piece in allPieces)
        {
            var collider = piece.GetComponent<Collider>();
            collider.enabled = !collider.enabled;
        }
    }

    public void OnCursorDown()
    {
        ToggleColliders();
        CameraManager.instance.SwitchCamera(puzzleCam);
    }

    public void OnCursorDrag() { }
    public void OnCursorUp() { }
    public void OnCursorClickAndHold() { }

}
