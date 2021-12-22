using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[DisallowMultipleComponent]
public class Chase1 : MonoBehaviour
{
    [SerializeField] float _speed = 3f;
    
    Transform _target;
    
    bool _isActive = false;

    private void Update()
    {
        if (!_isActive || _target == null) return;
        
        transform.LookAt(_target);
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isActive = true;
            _target = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isActive = false;
            if (_target.transform == other.transform) _target = null;
        }
    }
}