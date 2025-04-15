using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPaddle : MonoBehaviour, IPooledObject
{
    [Header("Movement")]
    [SerializeField] Rigidbody2D rB; // Player's 2D rb.
    [SerializeField] float movementSpeed; // Player's movement speed.
    
    public InputAction paddleControls;

    public event IPooledObject.OnDisable OnDestroy;
    Vector2 moveDirection = Vector2.zero;

    // Awake is called on the first active frame update
    void Awake()
    {
        rB = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput(); // Inputs are counted by frame.
    }

    // FixedUpdate is called once per physics update
    void FixedUpdate()
    {
        PlayerMovement(); // Movement is controlled by physics.
    }

    void OnEnable()
    {
        paddleControls.Enable();
    }

    void OnDisable() 
    {
        paddleControls.Disable();
    }


    void PlayerInput() 
    {
        moveDirection = paddleControls.ReadValue<Vector2>();
    }

    void PlayerMovement() 
    {
        rB.velocity = new Vector2(moveDirection.x * movementSpeed, rB.velocity.y);
    }

}
