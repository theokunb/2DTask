using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerJump : MonoBehaviour
{
    [SerializeField] private int _jumpForce;

    private Animator _animator;
    private Rigidbody2D _rigibody;
    private GroundCheck _groundCheck;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigibody = GetComponent<Rigidbody2D>();
        _groundCheck = GetComponentInChildren<GroundCheck>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && _groundCheck.OnGround)
        {
            _rigibody.AddForce(Vector2.up * _jumpForce);
        }
        
        _animator.SetBool(FamilliarAnimationController.Params.OnGround, _groundCheck.OnGround);
    }
}