using System;
using System.Collections.Generic;
using Game.Scripts.Rival;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

namespace Game.Scripts.Core.AI
{
   public abstract class Npc : MonoBehaviour
   {
      public NavMeshAgent agent;
      public Detector detector;
      public GameObject box;
      public GameObject stackLocation;
      public List<GameObject> ownedBox;
      public GameObject boxFirstLocation;
      public float radius;
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

      public abstract void ChangeState(BaseState state);
      public abstract bool ObjectTouched();
      public abstract bool DoesHaveBox();
      
      #if UNITY_EDITOR
       private void OnDrawGizmos()
       {
          
           Gizmos.DrawWireSphere(transform.position, radius);
       }
#endif
   }
}
