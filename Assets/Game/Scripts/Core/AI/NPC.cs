using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Game.Scripts.Core.AI
{
    public class NPC : MonoBehaviour
    {
        private AIState _currentState;
        private bool _result;
        private void Update()
        {
            _currentState.Execute(this);
        }

        public void ChangeState(AIState state)
        {
            _currentState = state;
        }

        public bool BoxInRange()
        {
            // game logic
            return _result;
        }

        public bool CraftAreaInRange()
        {
            // game logic
            return _result;
        }
    }

}