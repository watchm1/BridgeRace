using System.Collections;
using System.Collections.Generic;
using Game.Scripts.Core.AI;
using UnityEngine;
using UnityEngine.AI;

namespace Game.Scripts.Rival
{
    
    public class SearchBoxState : BaseState
    {
        public override void EnterState(Npc npc)
        {
              
        }

        public override void UpdateState(Npc npc)
        {
           
            if (npc.detector.isInsideArea)
            {
                npc.ChangeState(npc.MoveToBoxState);
            }
            else
            {
               Movement(npc); 
            }
        }

        private void Movement(Npc npc)
        {
            if (!npc.agent.hasPath )
            {
                npc.agent.SetDestination(GetPoint.Instance.GetRandomPoint());
            }
        }
        public override void OnTriggerEnter(Npc npc, GameObject collision)
        {
            
        }
    }
}
