using System;
using System.Collections;
using System.Collections.Generic;
using Game.Scripts.Core.Singleton;
using Game.Scripts.Pool;
using UnityEngine;

public class PoolManager : Singleton<PoolManager>
{
    public ObjectPool pool;
    private void Start()
    {
        pool = FindObjectOfType<ObjectPool>();
    }
}
