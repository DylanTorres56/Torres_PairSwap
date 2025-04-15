using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab; // The prefab of the ball to be spawned.
    [SerializeField] int poolSize; // An int that can help adjust the pool size of the ball.
    ObjectPool<Ball> ballPool; // An object pool of the ball.

    private void OnEnable()
    {
        Ball.OnLifeLost += BallSpawn;
    }

    private void OnDisable()
    {
        Ball.OnLifeLost -= BallSpawn;
    }

    // Start is called before the first frame update
    void Start()
    {
        ballPool = new ObjectPool<Ball>(poolSize, ballPrefab);
        BallSpawn();
    }

    // This function spawns a ball from the ball object pool.
    public void BallSpawn() 
    {        
        StartCoroutine(PlaceBallAtSpawn());
    }

    // Delay ball spawning by 0.5 seconds to make sure the player can reach the center in time.
    // This also helps with the transition to the Game Over screen, as the ball doesn't reappear before the switch.
    IEnumerator PlaceBallAtSpawn() 
    {
        yield return new WaitForSeconds(0.5f);
        ballPool.Spawn(Vector2.zero);
        AudioManager.instance.PlaySFX(AudioManager.instance.gameplaySFX[1]);
    }
}
