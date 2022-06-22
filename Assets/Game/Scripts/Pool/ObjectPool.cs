using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Pool
{
    
    public class ObjectPool : MonoBehaviour
    {

        #region PoolStruct
        [System.Serializable]
        public struct Pool
        {
            public int poolSize;
            public List<GameObject> pooledObject;
            public GameObject objectPrefab;
        }
        
        [SerializeField] public Pool[] pools;
        private void Awake()
        {
            for (int i = 0; i < pools.Length; i++)
            {
                pools[i].pooledObject = new List<GameObject>();
                for (int j = 0; j < pools[i].poolSize; j++)
                {
                    GameObject obj = Instantiate(pools[i].objectPrefab);
                    obj.SetActive(false);
                    obj.transform.SetParent(transform);
                    pools[i].pooledObject.Add(obj);
                }
            }
        }
        #endregion

        #region GetObjectFromPool

        public GameObject GetObjectFromPool(int objectType)
        {
            if (objectType >= pools.Length) return null;
            else 
            {
                if (pools[objectType].pooledObject.Count <= 0)
                {
                    GameObject obj = Instantiate(pools[objectType].objectPrefab);
                    obj.transform.SetParent(transform);
                    obj.SetActive(true);
                    return obj;
                }
                else
                {
                    GameObject obj = pools[objectType].pooledObject[0];
                    pools[objectType].pooledObject.RemoveAt(0);
                    obj.SetActive(true);
                    return obj;
                }
            }
        }
        #endregion
        #region ReturnObjectToPool

        public void ReturnObjectToPool(int objectType, GameObject obj)
        {
            obj.transform.SetParent(this.transform);
            obj.transform.position = this.transform.position;
            obj.SetActive(false);
            pools[objectType].pooledObject.Add(obj);
        }
        #endregion
    }

}