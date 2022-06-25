using System.Collections;
using System.Collections.Generic;
using Game.Scripts.Core.AI;
using UnityEngine;

namespace Game.Scripts.Core.AI
{
    
    public abstract class BaseState
    {
        public abstract void EnterState(Npc npc);
        public abstract void UpdateState(Npc npc);
        public abstract void OnTriggerEnter(Npc npc, GameObject obj);

    }
}
    