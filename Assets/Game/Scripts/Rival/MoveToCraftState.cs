using Game.Scripts.Core.AI;
using UnityEngine;

namespace Game.Scripts.Rival
{
    public class MoveToCraftState : BaseState 
    {
        public override void EnterState(Npc npc)
        {
            Debug.Log("craft alanında");
        }

        public override void UpdateState(Npc npc)
        {
            
        }

        public override void OnTriggerEnter(Npc npc, GameObject collision)
        {
           
        }
    }
}
