using System.Collections;
using System.Collections.Generic;
using Game.Scripts.Core.AI;
using UnityEngine;

namespace Game.Scripts.Rival
{
    public class IdleState : AIState
    {
        public override void Execute(NPC npc)
        {
            // change run to box state
            // Run To Craft state
            // DieState 
            npc.ChangeState(null);
        }
    }

}