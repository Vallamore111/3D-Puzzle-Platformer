using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearFloor : MonoBehaviour
{
    public GameObject[] leftLeverOne;
    public GameObject[] rightLeverOne;

    public GameObject[] leftLeverTwo_A;
    public GameObject[] rightLeverTwo_A;

    public GameObject[] leftLeverTwo_B;
    public GameObject[] rightLeverTwo_B;

    [System.NonSerialized] public bool swapSecondSet;


    public void RotateSpearPlatforms(GameObject[] spearPlatforms)
    {
        foreach (var platform in spearPlatforms)
        {
            var script = platform.GetComponentInChildren<SpearPlatform>();
            script.FlipPlatform();
        }
    }

    public void FlipTwoWayLever(LeverTwoWay lever)
    {
        if (lever.gameObject.name.Contains("Left"))
        { RotateSpearPlatforms(leftLeverOne); }
        else { RotateSpearPlatforms(rightLeverOne); }

    }


    public void FlipFourWayLever(LeverFourWay lever)
    {
        if (swapSecondSet)
        { lever.leverAnimator.SetBool(lever.alternatePull, true); }


        if (lever.gameObject.name.Contains("Left"))
        {
            if (lever.leverAnimator.GetBool(lever.alternatePull))
            { RotateSpearPlatforms(leftLeverTwo_B); }

            else
            { RotateSpearPlatforms(leftLeverTwo_A); }
        }


        if (lever.gameObject.name.Contains("Right"))
        {
            lever.leverAnimator.SetBool(lever.invertedPull, true);

            if (lever.leverAnimator.GetBool(lever.alternatePull))
            { RotateSpearPlatforms(rightLeverTwo_B); }

            else
            { RotateSpearPlatforms(rightLeverTwo_A); }
        }
    }

}
