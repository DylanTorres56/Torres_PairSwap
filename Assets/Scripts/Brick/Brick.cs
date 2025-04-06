using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour, IPooledObject
{
    public event IPooledObject.OnDisable OnDestroy;
    [SerializeField] Rigidbody2D rB;
    [SerializeField] Animator anim;

    // Awake is called on the first active frame update
    void Awake()
    {
        rB = gameObject.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // When this object is destroyed, it instead turns itself off and moves at a speed of 0f.
    void SelfDestroy()
    {
        rB.velocity = Vector2.zero;
        this.gameObject.SetActive(false);
        OnDestroy?.Invoke(this);
    }

    // If a ball strikes this brick, play its struck animation and disable it once finished!
    private void OnCollisionEnter2D(Collision2D collision)
    {
        anim.SetBool("StruckByBall", true);
        Invoke("SelfDestroy", .3f);
    }
}
