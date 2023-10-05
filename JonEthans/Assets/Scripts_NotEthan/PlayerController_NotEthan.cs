using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController_NotEthan : MonoBehaviour
{
    public Rigidbody2D rb;

    private Vector2 moveInput, pointerInput;

    [SerializeField]
    private InputActionReference movement, attack, pointerPosition;

    [SerializeField]
    public float maxSpeed = 10, acceleration = 50, decceleration = 100;

    [SerializeField]
    private float currentSpeed = 0;
    private Vector2 oldMovementInput;
    private Vector2 movementInput { get; set; }

    private WeaponParent_NotEthan weaponParent;


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        weaponParent = GetComponentInChildren<WeaponParent_NotEthan>();
    }

    // Update is called once per frame
    void Update()
    {
        pointerInput = GetPointerInput();
        weaponParent.PointerPosition = pointerInput;
        moveInput = movement.action.ReadValue<Vector2>();

        movementInput = moveInput;
    }

    private Vector2 GetPointerInput() 
    {
        Vector3 mousePos = pointerPosition.action.ReadValue<Vector2>();
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
        
    }
    private void FixedUpdate()
    {
        if (movementInput.magnitude > 0 && currentSpeed >= 0)
        {
            oldMovementInput = movementInput;
            currentSpeed += acceleration * maxSpeed * Time.deltaTime;
        }
        else
        {
            currentSpeed -= decceleration + maxSpeed * Time.deltaTime;
        }
        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
        rb.velocity = oldMovementInput * currentSpeed;
    }
}
