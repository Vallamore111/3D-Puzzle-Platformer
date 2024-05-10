using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Collider stepCollider;
    private bool isMoving;
    private bool movingDown;
    private float elevatorSpeed = 3f;
    private float groundThreshold = -15.2f;
    private Vector3 upPosition;
    private Vector3 downPosition;

    private Animator elevatorAnim;
    private int buttonPress;


    private void Awake()
    {
        elevatorAnim = GetComponent<Animator>();
    }

    private void Start()
    {
        downPosition = new Vector3(0, groundThreshold, 0);
        upPosition = Vector3.zero;
        stepCollider.enabled = !stepCollider.enabled;
        buttonPress = Animator.StringToHash("buttonPress");
    }


    private void Update()
    {
        if (!isMoving) return;
        MoveElevator();
    }


    private void MoveElevator()
    {
        if (movingDown)
        {
            transform.position += Vector3.down * elevatorSpeed * Time.deltaTime;

            if (transform.position.y < groundThreshold)
            {
                transform.position = downPosition;
                stepCollider.enabled = !stepCollider.enabled;
                isMoving = false;
                ButtonPressed();
            }
        }
        else
        {
            stepCollider.enabled = !stepCollider.enabled;
            transform.position += Vector3.up * elevatorSpeed * Time.deltaTime;

            if (transform.position.y > upPosition.y)
            {
                transform.position = upPosition;
                isMoving = false;
                ButtonPressed();
            }
        }
    }


    public void SetElevatorDirection(Vector3 destination)
    {
        if (destination.y > transform.position.y)
        { movingDown = false; }

        if (destination.y < transform.position.y)
        { movingDown = true; }
    }


    public Vector3 ToggleDestination()
    {
        if (transform.position == downPosition)
            return upPosition;
        else return downPosition;
    }

    
    public void ToggleMovement() => isMoving = !isMoving;
    public void ButtonPressed() => elevatorAnim.SetTrigger(buttonPress);
}
