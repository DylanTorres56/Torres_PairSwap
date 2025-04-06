using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab; // The prefab of the ball to be spawned.
    ObjectPool<Ball> ballPool; // An object pool of the ball.

    private void OnEnable()
    {
        Ball.OnLifeLost += BallSpawn;
        AddBallPowerUp.OnPowerUpApplied += BallSpawn;
    }

    private void OnDisable()
    {
        Ball.OnLifeLost -= BallSpawn;
        AddBallPowerUp.OnPowerUpApplied -= BallSpawn;
    }

    // Start is called before the first frame update
    void Start()
    {
        ballPool = new ObjectPool<Ball>(6, ballPrefab);
        BallSpawn();
    }

    // This function spawns a ball from the ball object pool.
    public void BallSpawn() 
    {
        ballPool.Spawn(Vector2.zero);
    }

}
