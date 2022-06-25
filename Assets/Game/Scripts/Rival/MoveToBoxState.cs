using Game.Scripts.Core.AI;
using Unity.VisualScripting;
using UnityEngine;

namespace Game.Scripts.Rival
{
    public class MoveToBoxState : BaseState 
    {
        public override void EnterState(Npc npc)
        {
        }

        public override void UpdateState(Npc npc)
        {
            Debug.Log("UPDATE FROM MOVE TO BOX");
            npc.box = GameObject.FindGameObjectWithTag("EnemyBox");
            npc.agent.SetDestination(npc.box.transform.position);
            npc.ChangeState(npc.PickBoxState);
            npc.detector.isInsideArea = false;
        }

        public override void OnTriggerEnter(Npc npc, GameObject collision)
        {
            
        }
    }
}
