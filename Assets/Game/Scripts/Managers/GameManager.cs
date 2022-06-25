using System;
using System.Collections;
using System.Collections.Generic;
using Game.Scripts.Core.Observer;
using UnityEngine;

namespace Game.Scripts.Managers
{
    public class GameManager : Subject
    {
        private int _count= 0;
        protected override void Start()
        {
            base.Start();
        }
        
        private void Update()
        {
            if (_count == 0)
            {
                Notify(NotificationType.GameStart);
                _count++;
                Debug.Log("start verildi");
            }
               
        }
    }
}
