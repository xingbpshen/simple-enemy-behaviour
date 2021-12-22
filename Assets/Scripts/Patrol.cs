using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] Transform[] patrolPoints;
    [SerializeField] float _speed = 1f;

    Transform _target;

    int _targetIndex = 0;

    private void Start() 
    {
        _target = patrolPoints[_targetIndex];
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, _target.position) < 0.5f)
        {
            _targetIndex++;
            if (_targetIndex >= patrolPoints.Length)
            {
                _targetIndex = 0;
            }
            _target = patrolPoints[_targetIndex];
        }
        transform.LookAt(_target);
        transform.position = Vector3.Lerp(transform.position, _target.position, _speed * Time.deltaTime);
    }
}
