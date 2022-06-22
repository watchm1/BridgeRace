using Game.Scripts.Core.Singleton;
using UnityEngine;

namespace Game.Scripts.Rival
{
    public class RivalAnimatorController : Singleton<RivalAnimatorController>
    {
        [SerializeField] private Animator animator;
        
        protected override void Awake()
        {
            base.Awake();
            animator.GetComponent<Animator>();
        }

        private void AnimationControl(string animName, bool trigger)
        {
            animator.SetBool(animName, trigger);
        }

        public void IdleAnim(bool triggerVal)
        {
            // "idleAnimTrigger"
            //AnimationControl();
        }

        public void MoveAnim()
        {
            //AnimationControl();   
        }
    }
}