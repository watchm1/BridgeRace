using Game.Scripts.Core.AI;
using UnityEngine;

namespace Game.Scripts.Rival
{
    public class MoveToCraftState : BaseState
    {
        public GameObject BridgeArea;
        public override void EnterState(Npc npc)
        {
             BridgeArea = GameObject.FindGameObjectWithTag("BridgeAreaEnemy");
             Debug.Log(BridgeArea.name);
            
        }

        public override void UpdateState(Npc npc)
        {
           
            npc.agent.SetDestination(BridgeArea.transform.position);
            if (npc.transform.position == BridgeArea.transform.position)
            {
                npc.ChangeState(npc.CraftState);
            }
        }

        public override void OnTriggerEnter(Npc npc, GameObject collision)
        {
           
        }
    }
}
