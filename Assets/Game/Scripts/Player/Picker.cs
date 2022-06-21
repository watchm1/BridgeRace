using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Game.Scripts.Core.Observer;
using Game.Scripts.Managers;
using Game.Scripts.Pool;
using UnityEngine;

namespace Game.Scripts.Player
{
    public class Picker : Subject
    {
        [SerializeField] private GameObject parentLocation;
        [SerializeField] private List<GameObject> ownedBoxes;
        [SerializeField] private ObjectPool pool;

        private GameObject _boxFirstLocation;

        protected override void Start()
        {
            base.Start();
            ownedBoxes = new List<GameObject>();
            _boxFirstLocation = parentLocation.transform.GetChild(0).gameObject;
            pool = FindObjectOfType<ObjectPool>();
        }

       

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("PlayerBox"))
            {
                PickObject(other.gameObject, _boxFirstLocation, parentLocation);
            }
            else if (other.CompareTag("BridgeArea"))
            {
                DropObject();
            }
        }

        private void PickObject(GameObject obj, GameObject target, GameObject parent)
        {
            ownedBoxes.Add(obj);
            obj.transform.SetParent(parent.transform);
            obj.transform.DOLocalJump(target.transform.localPosition, 0.7f, 1, 0.3f);
            target.transform.position += new Vector3(0, 1.5f, 0);
        }

        private void DropObject()
        {
            if (ownedBoxes.Count > 0)
            {
                var obj = ownedBoxes[ownedBoxes.Count - 1];
                pool.ReturnObjectToPool(0, obj);
                ownedBoxes.Remove(obj);
                _boxFirstLocation.transform.position -= new Vector3(0, 1.5f, 0);
                Notify(NotificationType.Crafting);
            }
        }
    }

}