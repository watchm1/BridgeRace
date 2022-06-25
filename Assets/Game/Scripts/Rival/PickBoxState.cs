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
          
          picked = false;
        }

        public override void UpdateState(Npc npc)
        {
            if (!picked)
            {
                
            }
            else
            {
                if (npc.ownedBox.Count < 15 && picked)
                {
                    npc.ChangeState(npc.SearchBoxState);
                }
                else
                {
                    npc.ChangeState(npc.MoveToCraftState);
                }
            }
        }

        private void PickObject(Npc npc, GameObject collision)
        {
            
            
            npc.ownedBox.Add(collision);
            collision.transform.SetParent(npc.stackLocation.transform);
            collision.transform.DOLocalJump(npc.boxFirstLocation.transform.localPosition, 0.7f, 1, 0.3f);
            npc.boxFirstLocation.transform.position += new Vector3(0, 1.5f, 0);
            picked = true;
            collision.transform.localRotation = Quaternion.Euler(new Vector3(0,0,0));
            collision.GetComponent<Collider>().enabled = false;
            npc.detector.isInsideArea = false;
            npc.detector.areaObj = null;
            npc.detector.GetComponent<Collider>().enabled = true;

        }
        public override void OnTriggerEnter(Npc npc, GameObject collision)
        {
            PickObject(npc, collision);
        }
    }
}
