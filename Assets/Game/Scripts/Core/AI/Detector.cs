using System;
using UnityEngine;

namespace Game.Scripts.Core.AI
{
    public class Detector : MonoBehaviour
    {
        public bool isInsideArea;

        private void Start()
        {
            
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("EnemyBox"))
            {
                isInsideArea = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("EnemyBox"))
            {
                isInsideArea = false;
            }
        }

        private void Update()
        {
        }
    }
}
