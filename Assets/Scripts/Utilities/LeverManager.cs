using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverManager : MonoBehaviour
{
    public LeverTwoWay[] twoWayLevers;
    public LeverFourWay[] fourWayLevers;

    private SpearFloor spearFloor;


    private void Awake()
    {
        spearFloor = FindObjectOfType<SpearFloor>();
    }


    public void HandleLeverBehavior(LeverTwoWay lever)
    {
        int leverInArray = twoWayLevers.Length + 1;

        for (int i = 0; i < twoWayLevers.Length; i++)
        {
            if (twoWayLevers[i] == lever)
            { leverInArray = i; }
        }

        switch (leverInArray)
        {
            case 0:
                spearFloor.FlipTwoWayLever(lever);
                break;

            case 1:
                spearFloor.FlipTwoWayLever(lever);
                break;

            default:
                return;
        }
    }


    public void HandleLeverBehavior(LeverFourWay lever)
    {
        int leverInArray = fourWayLevers.Length + 1;

        for (int i = 0; i < fourWayLevers.Length; i++)
        {
            if (fourWayLevers[i] == lever)
            { leverInArray = i; }
        }

        switch (leverInArray)
        {
            case 0:
                spearFloor.FlipFourWayLever(lever);
                break;

            case 1:
                spearFloor.FlipFourWayLever(lever);
                break;

            default:
                return;
        }
    }
}
