using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBrick : MonoBehaviour
{
    [SerializeField] GameObject brickPrefab; // The prefab of the brick to be spawned.
    [SerializeField] int poolQuantity; // The amount of bricks that should spawn on a given row.
    [SerializeField] float spacerConstant; // The amount of space between each brick.
    ObjectPool<Brick> brickPool; // An object pool of the ball.
    
    // Start is called before the first frame update
    void Start()
    {
        brickPool = new ObjectPool<Brick>(poolQuantity, brickPrefab);
        BrickSpawn();
    }

    void BrickSpawn()
    {
        float spacer;
        for (int i = 0; i < poolQuantity; i++) 
        {
            spacer = spacerConstant * i;
            brickPool.Spawn(new Vector2((transform.position.x + spacer), transform.position.y));
        }

    }
}
