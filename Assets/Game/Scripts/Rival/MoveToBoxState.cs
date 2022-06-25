using System.Collections.Generic;
using Game.Scripts.Core.AI;
using Game.Scripts.Pool;
using Unity.VisualScripting;
using UnityEngine;

namespace Game.Scripts.Rival
{
    public class MoveToBoxState : BaseState
    {
       
        public override void EnterState(Npc npc)
        {
            npc.detector.GetComponent<Collider>().enabled = false;
        }

        public override void UpdateState(Npc npc)
        {
            if (npc.detector.isInsideArea && npc.detector.areaObj != null)
            {
                npc.box = npc.detector.areaObj;
                npc.agent.SetDestination(npc.box.transform.position);
                npc.ChangeState(npc.PickBoxState);
            }
        }

        public override void OnTriggerEnter(Npc npc, GameObject collision)
        {
            
        }
    }
}
