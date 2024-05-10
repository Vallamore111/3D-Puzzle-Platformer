using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExternalStructure : MonoBehaviour
{
    private void Start()
    {
        Transform[] children = GetComponentsInChildren<Transform>(true);

        foreach (var child in children)
        { child.gameObject.SetActive(true); }
    }
}
