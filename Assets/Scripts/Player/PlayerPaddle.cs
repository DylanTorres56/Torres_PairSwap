using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddle : MonoBehaviour, IPooledObject
{
    [Header("Movement")]
    [SerializeField] Rigidbody2D rB; // Player's 2D rb.
    [SerializeField] float movementSpeed; // Player's movement speed.
    [SerializeField] float hInput; // Player's horizontal input (Left = -1, Right = 1).

    public event IPooledObject.OnDisable OnDestroy;

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

    void PlayerInput() 
    {
        hInput = Input.GetAxisRaw("Horizontal"); // Sets the player's horizontal movement input.
    }

    void PlayerMovement() 
    {
        rB.velocity = new Vector2(hInput * movementSpeed, rB.velocity.y);
    }

}
