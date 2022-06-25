
using System;
using Game.Scripts.Core.AI;
using UnityEngine;

namespace Game.Scripts.Rival
{

    public class Rival : Npc
    {
        [SerializeField] private BaseState _currentState;
        [SerializeField] private Rigidbody rb;
        private bool touched;

      
        private void Start()
        {
            _currentState = SearchBoxState;
            _currentState.EnterState(this);
            detector = FindObjectOfType<Detector>();
            touched = false;
        }
        private void Update()
        {
            _currentState.UpdateState(this); 
        }
        public override void ChangeState(BaseState state)
        {
            _currentState = state;
            _currentState.EnterState(this);
        }
        public override bool ObjectTouched()
        {
            return touched;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("EnemyBox"))
            {
                touched = true;
                _currentState.OnTriggerEnter(this, other.gameObject);
                Debug.Log(_currentState);
            }
        }

        public override bool DoesHaveBox()
        {
            return false;
        }
    }

}