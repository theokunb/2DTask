using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private readonly float _angleOnRight = 0;
    private readonly float _angleOnLeft = 180;
    private Animator _animator;
    private bool _isWalking;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            _isWalking = true;
            StartCoroutine(Walk(_angleOnRight));
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _isWalking = true;
            StartCoroutine(Walk(_angleOnLeft));
        }

        if(Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            _isWalking = false;
            _animator.SetFloat(ArchangelAnimationController.Params.Speed, 0);
        }
    }

    private IEnumerator Walk(float angle)
    {
        _animator.SetFloat(ArchangelAnimationController.Params.Speed, _speed);
        transform.rotation = new Quaternion(0, angle, 0, 0);

        while(_isWalking)
        {
            transform.Translate(Vector3.right * _speed * Time.deltaTime);
            yield return null;
        }
    }
}
