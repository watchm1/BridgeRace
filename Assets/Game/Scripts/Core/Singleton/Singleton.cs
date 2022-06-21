using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Game.Scripts.Core.Singleton 
{
    public abstract class Singleton<T> : MonoBehaviour where T: Singleton<T>
    {
        [CanBeNull]
        public static T Instance { get; private set; }

        protected virtual void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
                throw new System.Exception("An instance of this singleton already exists.");
            }
            else
                Instance = (T)this;
        }

        protected void OnApplicationQuit()
        {
            Instance = null;
            Destroy(gameObject);
        }
    }
    public abstract class SingletonPersistent<T> : Singleton<T> where T : Singleton<T>
    {
        protected override void Awake()
        {
            if(Instance != null) Destroy(gameObject);
            DontDestroyOnLoad(gameObject);
            base.Awake();
        }
    }

}