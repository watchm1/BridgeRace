using System.Collections.Generic;
using Game.Scripts.Core.Observer;
using Game.Scripts.Pool;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;


namespace Game.Scripts.Managers
{
    public class LevelManager : Observer
    {
        [SerializeField] private GameObject spawPointPrefab;
        [SerializeField] private ObjectPool pool;
        private Vector3 _size;
        private Vector3 _center;
        private Vector3 _oldLocation;
        private void Start()
        {
            ObserverManager.Instance.RegisterObserver(this);
            pool = FindObjectOfType<ObjectPool>();
            _size = spawPointPrefab.GetComponent<BoxCollider>().size;
            _center = spawPointPrefab.GetComponent<BoxCollider>().center;
        }
        
        public override void OnNotify(NotificationType type)
        {
            switch (type)
            {
                case NotificationType.GameStart:
                    SetLevel();
                    break;
            }
        }

        private Vector3 SetRandomLocation()
        {
            return _center + new Vector3(Calculate.RandomVal(_size.x*20), 1f, Calculate.RandomVal(_size.z*20));
        }
        private void SetLevel()
        {
            for (int i = 0; i < 15; i++)
            {
                var obj = pool.GetObjectFromPool(0);
                obj.transform.SetParent(GameObject.FindGameObjectWithTag("Environment").gameObject.transform);
                obj.transform.localPosition = SetRandomLocation();
            }
        }
    }

}