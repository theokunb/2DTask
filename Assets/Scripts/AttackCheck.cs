using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCheck : MonoBehaviour
{
    [SerializeField] private float _attackRange;
    [SerializeField] private LayerMask _mask;

    private bool _canAttack;
    private RaycastHit2D[] collisions = new RaycastHit2D[16];

    public bool CanAttack => _canAttack;


    private void Update()
    {
        _canAttack = Physics2D.Raycast(transform.position, transform.right, _attackRange, _mask);
    }
}
