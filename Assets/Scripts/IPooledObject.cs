using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPooledObject
{
    public delegate void OnDisable(IPooledObject poolableObject);
    public event OnDisable OnDestroy;
}
