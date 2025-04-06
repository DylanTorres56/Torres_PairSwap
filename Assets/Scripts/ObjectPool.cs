using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool<T> where T : IPooledObject
{    
    public HashSet<GameObject> pool { get; private set; } = new HashSet<GameObject>(); // Pool of objects stored in a hash set.

    Queue<T> queue = new Queue<T>(); // A queue of generics that is used to control spawning and despawning.
    Dictionary<T, GameObject> pooledObject = new Dictionary<T, GameObject>(); // A dictionary where pooled objects are stored.
    GameObject prefab; // The prefab type to spawn.

    public ObjectPool(int initialSize, GameObject objPrefab) 
    {
        prefab = objPrefab;
        for (int i = 0; i < initialSize; i++) 
        {
            GameObject obj = GameObject.Instantiate(prefab);
            T poolableObject = obj.GetComponent<T>();
            obj.SetActive(false);
            pool.Add(obj);
            pooledObject[poolableObject] = obj;
            queue.Enqueue(poolableObject);
            poolableObject.OnDestroy += ObjectDisabled;
        }
    }

    private void ObjectDisabled(IPooledObject poolableObject) 
    {
        queue.Enqueue((T)poolableObject);
    }

    // This generic function is used to spawn objects.
    public T Spawn(Vector3 position) 
    {
        if (queue.Count <= 0) 
        {
            for (int i = 0; i < 10; i++) 
            {
                GameObject objToInstantiate = GameObject.Instantiate(prefab);
                T poolableObject = objToInstantiate.GetComponent<T>();
                objToInstantiate.SetActive(false);
                pool.Add(objToInstantiate);
                pooledObject[poolableObject] = objToInstantiate;
                queue.Enqueue(poolableObject);
                poolableObject.OnDestroy += ObjectDisabled;
            }
        }

        T dequeuedGeneric = queue.Dequeue();
        pooledObject[dequeuedGeneric].SetActive(true);
        pooledObject[dequeuedGeneric].transform.position = position;

        return dequeuedGeneric; 
    }

    // This function is used to clear all the queues and disable all objects in the pool.
    public void DestroyAll() 
    {
        foreach (var obj in pool) 
        {
            GameObject.Destroy(obj);
        }

        pool.Clear();
        queue.Clear();
    }

}
