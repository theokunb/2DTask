using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class GroundCheck : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;

    private CircleCollider2D _circleCollider;
    private bool _onGround;

    public bool OnGround => _onGround;

    private void Start()
    {
        _circleCollider = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        _onGround = Physics2D.OverlapCircle(transform.position, _circleCollider.radius, _layerMask);
    }
}
