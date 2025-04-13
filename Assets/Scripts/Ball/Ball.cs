using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour, IPooledObject
{    
    public static event Action OnLifeLost; // A call to the CanvasTrackers' Decrement Life Count function without a hard reference-- the Observer Pattern!
    public event IPooledObject.OnDisable OnDestroy;
    
    [SerializeField] Rigidbody2D rB;

    // Awake is called on the first active frame update
    void Awake()
    {
        rB = gameObject.GetComponent<Rigidbody2D>();
    }

    // When this object is destroyed, it instead turns itself off and moves at a speed of 0f.
    void SelfDestroy()
    {
        rB.velocity = Vector2.zero;
        this.gameObject.SetActive(false);
        OnDestroy?.Invoke(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.gameplaySFX[0]);
    }

    // If this ball is out of bounds, it freezes and disables itself!
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3) 
        {
            AudioManager.instance.PlaySFX(AudioManager.instance.gameplaySFX[2]);
            SelfDestroy();
            OnLifeLost?.Invoke();
        }
    }

}
