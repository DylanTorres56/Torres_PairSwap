using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPaddle : MonoBehaviour, IPooledObject
{
    [Header("Movement")]
    [SerializeField] Rigidbody2D rB; // Player's 2D rb.
    [SerializeField] float movementSpeed; // Player's movement speed.
    [SerializeField] float hMovement;

    public InputAction paddleControls;

    public event IPooledObject.OnDisable OnDestroy;
    Vector2 moveDirection = Vector2.zero;

    // Awake is called on the first active frame update
    void Awake()
    {
        rB = gameObject.GetComponent<Rigidbody2D>();
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

    public void PlayerInput(InputAction.CallbackContext context) 
    {
        hMovement = context.ReadValue<Vector2>().x;        
    }

    void PlayerMovement() 
    {
        rB.velocity = new Vector2(hMovement * movementSpeed, rB.velocity.y);
    }    

}
