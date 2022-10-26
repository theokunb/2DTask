using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _offset;

    void Update()
    {
        float positionX = _target.position.x - transform.position.x;
        float positionY = _target.position.y - transform.position.y;
        float positionZ = transform.position.z;

        if(Mathf.Abs(positionX) > _offset || Mathf.Abs(positionY) > _offset)
        {
            transform.position += new Vector3(positionX,positionY,positionZ) * Time.deltaTime;
        }
    }
}
