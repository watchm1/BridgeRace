using System;
using DG.Tweening;
using Game.Scripts.Core.AI;
using UnityEngine;

namespace Game.Scripts.Rival
{
    public class PickBoxState : BaseState
    {
        private bool picked = false;
        public override void EnterState(Npc npc)
        {
          Debug.Log("picked"); 
        }

        public override void UpdateState(Npc npc)
        {
            if (!picked)
            {
                
            }
            else
            {
                if (npc.ownedBox.Count < 5)
                {
                    npc.ChangeState(npc.SearchBoxState);
                }
                else
                {
                    npc.ChangeState(npc.CraftState);
                }
            }
        }

        private void PickObject(Npc npc, GameObject collision)
        {
            
            Debug.Log("fonksiyon çalıştı"); 
            npc.ownedBox.Add(collision);
            collision.transform.SetParent(npc.stackLocation.transform);
            collision.transform.DOLocalJump(npc.boxFirstLocation.transform.localPosition, 0.7f, 1, 0.3f);
            npc.boxFirstLocation.transform.position += new Vector3(0, 1.5f, 0);
            picked = true;
            npc.ownedBox[npc.ownedBox.Count -1].transform.localRotation = Quaternion.Euler(new Vector3(0,0,0)); 

        }
        public override void OnTriggerEnter(Npc npc, GameObject collision)
        {
            PickObject(npc, collision);
        }
    }
}
