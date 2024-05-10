using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDeathRoller : MonoBehaviour
{ 
    public GameObject deathRoller;

    private void Awake() => deathRoller.SetActive(false);

    private void OnTriggerEnter(Collider other) => deathRoller.SetActive(true);
}
