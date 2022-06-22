using System.Collections;
using System.Collections.Generic;
using Game.Scripts.Core.Singleton;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Scripts.Player
{
    public class AnimatorController : Singleton<AnimatorController>
    {
        [SerializeField] private Animator animator;

        private static readonly int Vertical = Animator.StringToHash("Vertical");
        private static readonly int Horizontal = Animator.StringToHash("Horizontal");

        protected override void Awake()
        {
            base.Awake();
            animator = GetComponent<Animator>();
        }

        private void AnimationControl(int value, float index)
        {
            animator.SetFloat(value, index);
        }

        public void MoveAnimationControl(float x, float z)
        {
            AnimationControl(Horizontal, x);
            AnimationControl(Vertical, z);
        }
    }

}