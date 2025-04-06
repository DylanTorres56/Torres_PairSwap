using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerUp : MonoBehaviour
{
    [SerializeField] GameObject powerUpObjectToSpawn;
    ObjectPool<PowerUpObject> powerUpObjectPool; // An object pool of the Power Ups.

    private void OnEnable()
    {
        GameManager.OnPowerUpSpawnQuotaHit -= PowerUpSpawn;
    }

    private void OnDisable()
    {        
        GameManager.OnPowerUpSpawnQuotaHit += PowerUpSpawn;     
    } 

    void Start()
    {
        powerUpObjectPool = new ObjectPool<PowerUpObject>(3, powerUpObjectToSpawn);
    }

    void PowerUpSpawn() 
    {
        powerUpObjectPool.Spawn(Vector2.zero);
    }

}