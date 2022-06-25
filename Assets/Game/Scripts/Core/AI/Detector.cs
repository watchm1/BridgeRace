using System;
using UnityEngine;

namespace Game.Scripts.Core.AI
{
    public class Detector : MonoBehaviour
    {
        public bool isInsideArea;
        public GameObject areaObj;
        private void Start()
        {
            areaObj = null;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("EnemyBox"))
            {
                isInsideArea = true;
                areaObj = other.gameObject;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("EnemyBox"))
            {
                isInsideArea = false;
                areaObj = other.gameObject;
            }
        }

        private void Update()
        {
        }
    }
}
