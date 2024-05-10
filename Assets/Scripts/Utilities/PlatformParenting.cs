using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformParenting : MonoBehaviour
{
    public static void HandlePlatformParenting(Transform objectToParent, Transform platform)
    {
        if (objectToParent.parent == platform)
        { objectToParent.SetParent(null); }
        else { objectToParent.SetParent(platform); }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != GameObject.FindGameObjectWithTag("Player")) return;

        HandlePlatformParenting(other.transform, this.transform);
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject != GameObject.FindGameObjectWithTag("Player")) return;
        if (other.transform.parent != this.transform) return;

        Vector3 positionOffset = other.transform.position - transform.position;
        other.transform.position = transform.position + positionOffset;
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject != GameObject.FindGameObjectWithTag("Player")) return;
        if (other.transform.parent != this.transform) return;

        HandlePlatformParenting(other.transform, this.transform);
    }
}

