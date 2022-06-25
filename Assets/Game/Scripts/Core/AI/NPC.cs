using System;
using System.Collections.Generic;
using Game.Scripts.Rival;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

namespace Game.Scripts.Core.AI
{
   public class Npc : MonoBehaviour
   {
       public NavMeshAgent agent; 
       public Detector detector;
       public GameObject box;
       public GameObject stackLocation;
       public List<GameObject> ownedBox;
       public GameObject boxFirstLocation;
       public float radius;

       [SerializeField] private BaseState _currentState;
       [SerializeField] private Rigidbody rb;
       private bool _touched;
       #region State's references 
                  
              public BaseState CraftState = new CraftState();
              public BaseState MoveToBoxState = new MoveToBoxState();
              public BaseState PickBoxState = new PickBoxState();
              public BaseState MoveToCraftState = new MoveToCraftState();
              public BaseState SearchBoxState = new SearchBoxState();
              
      
      
      #endregion

      private void Awake()
      {
          agent = GetComponent<NavMeshAgent>();
          stackLocation = GameObject.FindGameObjectWithTag("Stack");
          ownedBox = new List<GameObject>();
          boxFirstLocation = stackLocation.transform.GetChild(0).gameObject;
      }

      private void Start()
      {
          _currentState = SearchBoxState;
          _currentState.EnterState(this);
          detector = FindObjectOfType<Detector>();
          _touched = false;
      }

      private void Update()
      {
         _currentState.UpdateState(this); 
      }

      public void ChangeState(BaseState state)
      {
          _currentState = state;
          _currentState.EnterState(this);
      }

      public bool ObjectTouched()
      {
          return _touched;
      }

      public bool DoesHaveBox()
      {
          return false;
      }

      private void OnTriggerEnter(Collider other)
      {
          if (other.CompareTag("EnemyBox"))
          {
              _touched = true;
              _currentState.OnTriggerEnter(this, other.gameObject);
              Debug.Log(_currentState);
          }
      }
#if UNITY_EDITOR
       private void OnDrawGizmos()
       {
          
           Gizmos.DrawWireSphere(transform.position, radius);
       }
#endif
   }
}
