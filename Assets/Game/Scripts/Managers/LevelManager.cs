using System.Collections.Generic;
using Game.Scripts.Core.AI;
using Game.Scripts.Core.Observer;
using Game.Scripts.Helper;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;


namespace Game.Scripts.Managers
{
    public class LevelManager : Observer
    {
        [SerializeField] private GameObject spawPointPrefab;
        [SerializeField] private SceneScheme sceneData;
        private Vector3 _size;
        private Vector3 _center;
        private Vector3 _oldLocation;
        private int _currentScene;
        private GameObject environmentObj;
        private void Start()
        {
            ObserverManager.Instance.RegisterObserver(this);
            _size = spawPointPrefab.GetComponent<BoxCollider>().size;
            _center = spawPointPrefab.GetComponent<BoxCollider>().center;
            //_currentScene = sceneData.CurrentScene;
            environmentObj = GameObject.FindGameObjectWithTag("Environment");
        }
        
        public override void OnNotify(NotificationType type)
        {
            switch (type)
            {
                case NotificationType.GameStart:
                {
                    Debug.Log("kaç kere çalıştı");
                    SetLevel();
                    break;
                }
                case NotificationType.LevelChange:
                    break;
                case NotificationType.PlayerCrafting:
                    RespawnBox(0);
                    break;
                case NotificationType.EnemyCrafting:
                    RespawnBox(1);
                    break;
            }
        }

        private void RespawnBox(int type)
        {
            var obj = PoolManager.Instance.pool.GetObjectFromPool(type);
            obj.transform.SetParent(environmentObj.transform);
            obj.transform.localPosition = SetRandomLocation();
        }
        private Vector3 SetRandomLocation()
        {
            return _center + new Vector3(Calculate.RandomValForPosition(_size.x*20), 1f, Calculate.RandomValForPosition(_size.z*20));
        }
        private void SetLevel()
        {
            for (int i = 0; i < 5; i++)
            {
                var obj = PoolManager.Instance.pool.GetObjectFromPool(Calculate.RandomChoices(2));
                obj.transform.SetParent(environmentObj.transform);
                obj.transform.localPosition = SetRandomLocation();
                
            }
        }

        private void ChangeLevel()
        {
            _currentScene++;
            sceneData.CurrentScene = _currentScene;
            sceneData.LoadScene();
            Destroy(this);
        }
    }

}