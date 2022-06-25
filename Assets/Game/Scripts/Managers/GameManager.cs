using System;
using System.Collections;
using System.Collections.Generic;
using Game.Scripts.Core.Observer;
using Game.Scripts.Core.AI;
using UnityEngine;

namespace Game.Scripts.Managers
{
    public class GameManager : Subject
    {
        private int _count= 0;
        protected override void Start()
        {
            base.Start();
            FindObjectOfType<Npc>().enabled = true;
            
        }
        
        private void Update()
        {
            if (_count == 0)
            {
                _count++;
                Notify(NotificationType.GameStart);
                Debug.Log("update çalıştı");
            }
               
        }
    }
}
