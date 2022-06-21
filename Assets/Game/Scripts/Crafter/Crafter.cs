using System;
using System.Collections;
using System.Collections.Generic;
using Game.Scripts.Core.Observer;
using Game.Scripts.Managers;
using Game.Scripts.Pool;
using UnityEngine;

namespace Game.Scripts.Crafter
{
    public class Crafter : Observer
    {
        [SerializeField] private List<GameObject> bridgePieces;
        private float _spaceBetweenPieces = 0.3f;

        private void Start()
        {
            ObserverManagment.Instance.RegisterObserver(this);
            bridgePieces = new List<GameObject>();
            transform.SetParent(GameObject.FindGameObjectWithTag("Environment").transform);
        }

        private void Craft(GameObject bridgePiece)
        {
            bridgePieces.Add(bridgePiece);
            bridgePiece.transform.localPosition = new Vector3(transform.position.x, transform.position.y -_spaceBetweenPieces,
                transform.position.z + bridgePiece.transform.localScale.z + _spaceBetweenPieces);
            transform.position += new Vector3(0f, 0f, bridgePiece.transform.localScale.z + _spaceBetweenPieces);
            
            
        }

        private void ReturnAllPiecesToPool()
        {
            foreach (var item in bridgePieces)
            {
                PoolManager.Instance.pool.ReturnObjectToPool(2, item);
            }
        }
        public override void OnNotify(NotificationType type)
        {
            switch (type)
            {
                case NotificationType.Crafting:
                    Craft(PoolManager.Instance.pool.GetObjectFromPool(2));
                    break;
                case NotificationType.LevelChange:
                    ReturnAllPiecesToPool();
                    break;
                case NotificationType.PlayerDead:
                    ReturnAllPiecesToPool();
                    break;
            }
        }
    }
}
