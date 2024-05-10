using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverFourWay : MonoBehaviour, IHandleCursor
{
    private LeverManager leverManager;
    [System.NonSerialized] public Animator leverAnimator;
    [System.NonSerialized] public int alternatePull;
    [System.NonSerialized] public int invertedPull;
    [System.NonSerialized] public int leverPull;


    private void Awake()
    {
        leverAnimator = GetComponent<Animator>();
        leverManager = FindObjectOfType<LeverManager>();
    }

    private void Start()
    {
        leverPull = Animator.StringToHash("leverPull");
        alternatePull = Animator.StringToHash("alternatePull");
        invertedPull = Animator.StringToHash("invertedPull");
    }


    public void OnCursorDown()
    {
        leverAnimator.SetTrigger(leverPull);
        leverManager.HandleLeverBehavior(this);
    }

    public void OnCursorDrag() { }
    public void OnCursorUp() { }
    public void OnCursorClickAndHold() { }
}
