using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        #region Variables

        [SerializeField] private PlayerData data;
        private float _xMovement;
        private float _zMovement;
        private float _speed;
        private float _groundRadius;
        [SerializeField]private Transform groundCheck;
        private LayerMask _whatIsGround;
        [SerializeField]private Rigidbody rb;
        private bool _onGround;


        private void Awake()
        {
            _speed = data.speed;
            _groundRadius = data.groundRadius;
            _whatIsGround = data.whatIsGround;
            
        }

        private void Update()
        {
            _xMovement = Input.GetAxisRaw("Horizontal");
            _zMovement = Input.GetAxisRaw("Vertical");
            if(GroundChecker())
                Movement();
            HandleAnim();
        }

        private bool GroundChecker()
        {
            _onGround = Physics.CheckSphere(groundCheck.position, _groundRadius, _whatIsGround);
            return _onGround;
        }

        private void HandleAnim()
        {
            if (_xMovement > 0 | _xMovement < 0)
            {
                AnimatorController.Instance.MoveAnimationControl(_xMovement, 0);
            }
            else if(_zMovement > 0 | _zMovement < 0)
                AnimatorController.Instance.MoveAnimationControl(0, _zMovement);
            else if(_zMovement == 0 && _xMovement == 0)
                AnimatorController.Instance.MoveAnimationControl(0,0);
        }
        private void Movement()
        {
            rb.velocity = new Vector3(_xMovement, 0 , _zMovement) * _speed;
        }

        #endregion
    }

}