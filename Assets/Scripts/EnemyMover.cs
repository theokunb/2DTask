using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private readonly float _angleOnRight = 0;
    private readonly float _angleOnLeft = 180;

    private CheckForwardGround _checkForward;
    private Animator _animator;
    private AttackCheck _attackCheck;
    


    private void Start()
    {
        _checkForward = GetComponentInChildren<CheckForwardGround>();
        _animator = GetComponent<Animator>();
        _attackCheck = GetComponentInChildren<AttackCheck>();
    }

    private void Update()
    {
        if(_checkForward.CanMove)
        {
            _animator.SetFloat(ArchangelAnimationController.Params.Speed, _speed);
            transform.Translate(Vector3.right * _speed * Time.deltaTime);
        }
        else 
        {
            transform.Rotate(new Vector3(0,180,0));
        }

        _animator.SetBool(ArchangelAnimationController.Params.Attack, _attackCheck.CanAttack);
    }
}
