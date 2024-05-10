using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearFloorTrigger : MonoBehaviour
{
    private SpearFloor spearFloor;

    private void Awake() => spearFloor = FindObjectOfType<SpearFloor>();


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == GameObject.FindGameObjectWithTag("Player"))
        { spearFloor.swapSecondSet = true; }
    }
}
