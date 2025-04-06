using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : ScriptableObject //, IPooledObject
{
    //public event IPooledObject.OnDisable OnDestroy;
    public abstract void Apply(GameObject targetObject);
}
