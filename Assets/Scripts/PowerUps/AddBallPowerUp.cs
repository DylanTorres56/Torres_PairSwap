using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/AddBallPowerUp")]
public class AddBallPowerUp : PowerUp
{
    public static event Action OnPowerUpApplied; 
    public int addAmount; // Amount of balls to add upon collection.

    // Loop the process of adding balls until the target is hit. This value should not exceed the ball pool size!
    public override void Apply(GameObject targetObject)
    {
        for (int i = 0; i < addAmount; i++)
        {
            targetObject.GetComponent<SpawnBall>().BallSpawn();
            OnPowerUpApplied?.Invoke();
        }
    }
}
