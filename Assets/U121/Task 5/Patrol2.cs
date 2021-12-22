using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

[DisallowMultipleComponent]
public class Patrol2 : MonoBehaviour, IBehavior1
{
    [SerializeField] Transform[] _patrolPoints;
    [SerializeField] float _speed = 1f;
    
    Transform _target;
    int _targetIndex = 0;
    float _startTime;

    public bool IsActive => true;

    private void Start()
    {
        _target = _patrolPoints[_targetIndex];
    }

    public void Tick()
    {
        if (Vector3.Distance(transform.position, _target.position) < 0.5f)
        {
            _targetIndex++;
            if (_targetIndex >= _patrolPoints.Length)
            {
                _targetIndex = 0;
            }
            _target = _patrolPoints[_targetIndex];
        }
        
        transform.LookAt(_target);
        transform.position = Vector3.Lerp(transform.position, _target.position,  _speed * Time.deltaTime);
    }
}
