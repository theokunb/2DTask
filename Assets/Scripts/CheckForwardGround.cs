using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForwardGround : MonoBehaviour
{
    [SerializeField] private float _visibilityRange;
    [SerializeField] private LayerMask _ground;

    private bool _canMove;

    public bool CanMove => _canMove;

    private void Update()
    {
        _canMove = Physics2D.Raycast(transform.position, transform.right, _visibilityRange, _ground);
    }
}
