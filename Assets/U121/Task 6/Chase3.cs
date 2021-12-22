using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[DisallowMultipleComponent]
public class Chase3 : MonoBehaviour, IBehavior2
{
    float _speed = 3f;

    Transform _target;

    public Action OnStateChanged { get; set; }

    bool _isActive = false;
    public bool IsActive => _isActive;

    public void Tick()
    {
        if (!_isActive || _target == null) return;

        transform.LookAt(_target);
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _target = other.transform;
            _isActive = true;
            OnStateChanged?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (_target.transform == other.transform) _target = null;
            _isActive = false;
            OnStateChanged?.Invoke();
        }
    }
}