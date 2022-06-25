using System;
using System.Collections.Generic;
using Game.Scripts.Core.Observer;
using Game.Scripts.Managers;
using UnityEngine;

namespace Game.Scripts.Crafter
{
	
    public class Crafter : Observer
    {
        [SerializeField] private List<GameObject> bridgePieces;
        private float _spaceBetweenPieces = 0.4f;
        private bool _canCraft;

        private void Start()
        {
            ObserverManagment.Instance.RegisterObserver(this);
            bridgePieces = new List<GameObject>();
            transform.SetParent(GameObject.FindGameObjectWithTag("Environment").transform);
            _canCraft = true;
        }
		
        private void Craft(GameObject bridgePiece, float y)
        {
            if (CanCraft())
            {
                bridgePieces.Add(bridgePiece);
                bridgePiece.transform.localPosition = new Vector3(transform.position.x, transform.position.y -
						_spaceBetweenPieces -0.1f,
                    transform.position.z + bridgePiece.transform.localScale.z + _spaceBetweenPieces);
                transform.position += new Vector3(0f, y, bridgePiece.transform.localScale.z + _spaceBetweenPieces);
            }
        }
        private void ReturnAllPiecesToPool()
        {
            foreach (var item in bridgePieces)
            {
                PoolManager.Instance.pool.ReturnObjectToPool(2, item);
            }
        }

        private bool CanCraft()
        {
            return _canCraft;
        }

		private void SetBool()
        {
            _canCraft = false;
            gameObject.SetActive(false);
        }
        public override void OnNotify(NotificationType type)
        {
            switch (type)
            {
                case NotificationType.PlayerCrafting:
                    Craft(PoolManager.Instance.pool.GetObjectFromPool(2), 0);
                    break;
                case NotificationType.PlayerCraftStairs:
                    Craft(PoolManager.Instance.pool.GetObjectFromPool(2), 0.5f);
                    break;
                case NotificationType.LevelChange:
                    ReturnAllPiecesToPool();
                    break;
                case NotificationType.PlayerDead:
                    ReturnAllPiecesToPool();
                    break;
                case NotificationType.PlayerCraftDone:
                    SetBool();
                    break;
            }
        }
    }
}
