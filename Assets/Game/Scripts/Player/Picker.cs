using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Game.Scripts.Core.Observer;
using Game.Scripts.Managers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Scripts.Player
{
    public class Picker : Subject
    {
        [SerializeField] private GameObject parentLocation;
        [SerializeField] private List<GameObject> ownedBoxes;
        private GameObject _boxFirstLocation;
        private bool _canCraft;
        [FormerlySerializedAs("TargetBox")] [SerializeField]private string targetBox;
        [FormerlySerializedAs("TargetBridgeArea")] [SerializeField]private string targetBridgeArea;
        [FormerlySerializedAs("TargetBridgeStairsArea")] [SerializeField]private string targetBridgeStairsArea;
        [FormerlySerializedAs("CraftEndArea")] [SerializeField]private string craftEndArea;
        [FormerlySerializedAs("LevelEnd")] [SerializeField] private string levelEnd;
        protected override void Start()
        {
            base.Start();
            ownedBoxes = new List<GameObject>();
            _boxFirstLocation = parentLocation.transform.GetChild(0).gameObject;
            _canCraft = true;
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(targetBox))
            {
                PickObject(other.gameObject, _boxFirstLocation, parentLocation);
            }
            else if (other.CompareTag(targetBridgeArea))
            {
                DropObject(NotificationType.PlayerCrafting);
            }
            else if (other.CompareTag(targetBridgeStairsArea))
            {
                DropObject(NotificationType.PlayerCraftStairs);
            }
            else if(other.CompareTag(levelEnd))
            {
                 Notify(NotificationType.LevelChange);
            }
            else if (other.CompareTag(craftEndArea))
            {
                _canCraft = false;
                Notify(NotificationType.PlayerCraftDone);
                other.gameObject.SetActive(false);
            }
        }

        private void PickObject(GameObject obj, GameObject target, GameObject parent)
        {
            ownedBoxes.Add(obj);
            obj.transform.SetParent(parent.transform);
            obj.transform.DOLocalJump(target.transform.localPosition, 0.7f, 1, 0.3f);
            target.transform.position += new Vector3(0, 1.5f, 0);
        }

        private void DropObject(NotificationType type)
        {
            if (_canCraft)
            {
                if (ownedBoxes.Count > 0)
                {
                    var obj = ownedBoxes[ownedBoxes.Count - 1];
                    PoolManager.Instance.pool.ReturnObjectToPool(0, obj);
                    ownedBoxes.Remove(obj);
                    _boxFirstLocation.transform.position -= new Vector3(0, 1.5f, 0);
                    Notify(type);
                }
            }
        }
    }

}