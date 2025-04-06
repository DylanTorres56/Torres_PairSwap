using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpObject : MonoBehaviour, IPooledObject
{
    public event IPooledObject.OnDisable OnDestroy;
    public PowerUp powerUpToApply;

    [SerializeField] Rigidbody2D rB;
    [SerializeField] Animator anim;

    // Awake is called on the first active frame update
    void Awake()
    {
        rB = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    // When this object is destroyed, it instead turns itself off and moves at a speed of 0f.
    void SelfDestroy()
    {
        rB.velocity = Vector2.zero;
        this.gameObject.SetActive(false);
        OnDestroy?.Invoke(this);
    }

    // If a ball strikes this Power Up Object, apply the necessary changes and disable it once finished!
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            powerUpToApply.Apply(collision.gameObject);
            anim.SetBool("PowerUpCollected", true);
            Invoke("SelfDestroy", .4f);
        }
    }
}
