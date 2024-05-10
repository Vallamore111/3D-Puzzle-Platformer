using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearPlatform : MonoBehaviour
{
    public GameObject spears;
    private GameObject instantiatedObject;
    private Vector3 heightOffset;
    private bool movingSpear;
    private float spearSpeed;
    private bool notFlipped;

    private Animator platformAnimator;
    private int platformFlip;
    private int platformFlipReverse;



    private void Awake() => platformAnimator = GetComponentInParent<Animator>();


    private void Start()
    {
        spearSpeed = 20f;
        heightOffset = new Vector3(0, -2, 0);
        notFlipped = true;
        platformFlip = Animator.StringToHash("platformFlip");
        platformFlipReverse = Animator.StringToHash("platformFlipReverse");
    }


    private void Update()
    {
        if (!movingSpear) return;

        ThrustSpears();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == GameObject.FindGameObjectWithTag("Player"))
        { InstantiateSpears(); }
    }


    private void InstantiateSpears()
    {
        instantiatedObject = Instantiate(spears, transform.position + heightOffset, Quaternion.identity, transform.parent);
        movingSpear = true;
    }


    private void ThrustSpears()
    {
        if (instantiatedObject.transform.localPosition.y < Vector3.zero.y)
        { instantiatedObject.transform.localPosition += Vector3.up * spearSpeed * Time.deltaTime; }

        else
        {
            instantiatedObject.transform.localPosition = Vector3.zero;
            movingSpear = false;
        }
    }


    public void FlipPlatform()
    {
        if (notFlipped)
        {
            platformAnimator.SetTrigger(platformFlip);
            notFlipped = false; 
        }
        else
        {
            platformAnimator.SetTrigger(platformFlipReverse);
            notFlipped = true;
        }
    }
}
