using System.Collections;
using System.Collections.Generic;
using Game.Scripts.Core.AI;
using UnityEngine;

public abstract class AIState 
{
    public abstract void Execute(NPC npc);
}
