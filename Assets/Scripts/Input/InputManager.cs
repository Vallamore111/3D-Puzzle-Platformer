using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour, IHandleCursor
{
    private InputAction dragAction;
    private Vector2 movementInput;
    private IHandleCursor currentObjectInterface;
    private PlayerControls playerControls;
    private PlayerLocomotion playerLocomotion;

    private bool shiftKey;
    private bool spaceBar;
    private bool clickAndHold;
    [System.NonSerialized] public Vector3 inputDirection;
    [System.NonSerialized] public Vector2 mousePosition;
    [System.NonSerialized] public Vector2 mouseLook;
    [System.NonSerialized] public bool rightClick;



    private void Awake()
    {
        playerLocomotion = GetComponent<PlayerLocomotion>();
    }


    private void OnEnable()
    {
        if (playerControls != null) return;
        playerControls = new PlayerControls();

        playerControls.PlayerMovement.Movement.started += i => movementInput = i.ReadValue<Vector2>();
        playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
        playerControls.PlayerMovement.Movement.canceled += i => movementInput = i.ReadValue<Vector2>();

        playerControls.PlayerMovement.MousePosition.performed += i => mousePosition = i.ReadValue<Vector2>();
        playerControls.PlayerMovement.MouseLook.performed += i => mouseLook = i.ReadValue<Vector2>();

        playerControls.PlayerActions.MouseLeftClick.started += i => OnCursorDown();
        playerControls.PlayerActions.MouseLeftClick.canceled += i => OnCursorUp();

        playerControls.PlayerActions.MouseLeftClick_Hold.performed += i => clickAndHold = true;

        playerControls.PlayerActions.Sprint.performed += i => shiftKey = true;
        playerControls.PlayerActions.Sprint.canceled += i => shiftKey = false;

        playerControls.PlayerActions.MouseRightClick.performed += i => rightClick = true;
        playerControls.PlayerActions.MouseRightClick.canceled += i => rightClick = false;

        playerControls.PlayerActions.Jump.performed += i => spaceBar = true;

        dragAction = playerControls.PlayerActions.MouseDrag;

        playerControls.Enable();
    }
    private void OnDisable() => playerControls.Disable();



    public void HandleAllInputs()
    {
        HandleMovementInput();
        HandleSprintInput();
        HandleJumpInput();
        HandleClickAndHold();
    }


    private void HandleMovementInput()
    {
        float horizontalInput = movementInput.x;
        float verticalInput = movementInput.y;
        inputDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;
    }


    private void HandleSprintInput() => playerLocomotion.isSprinting = shiftKey;


    private void HandleJumpInput()
    {
        if (!spaceBar) return;

        playerLocomotion.HandleJump(); 
        spaceBar = false;
    }


    private void HandleClickAndHold()
    {
        if (!clickAndHold) return;

        OnCursorClickAndHold();
    }


    public void OnCursorDown()
    {
        if (PlayerRaycast.currentObject == null) return;

        PlayerRaycast.currentObject.TryGetComponent<IHandleCursor>(out currentObjectInterface);

        if (currentObjectInterface == null) return;

        currentObjectInterface.OnCursorDown();
        dragAction.performed += i => OnCursorDrag();
    }


    public void OnCursorDrag()
    {
        if (currentObjectInterface == null) return;

        currentObjectInterface.OnCursorDrag();
    }


    public void OnCursorUp()
    {
        if (currentObjectInterface == null) return;

        currentObjectInterface.OnCursorUp();
        dragAction.performed -= i => OnCursorDrag();

        rightClick = false;
        clickAndHold = false;
        currentObjectInterface = null;
    }


    public void OnCursorClickAndHold()
    {
        if (currentObjectInterface == null) return;

        currentObjectInterface.OnCursorClickAndHold();
    }
}
