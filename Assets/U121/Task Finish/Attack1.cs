using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Attack1 : MonoBehaviour, IBehavior2
{
    public Action OnStateChanged { get; set; }
    
    bool _isActive = false;
    public bool IsActive => _isActive;
    
    [SerializeField] float _attackRange = 5f, _speed = 3f;
    Transform _target = null;
    Vector3 _originalScale;

    private void Start()
    {
        _originalScale = transform.localScale;
        _target = GameObject.FindWithTag("Player").transform;
    }

    public void Tick()
    {
        if (!IsActive) return;

        transform.LookAt(_target.position);
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
        transform.localScale *= 1.001f;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, _target.position) <= _attackRange)
        {
            if (!IsActive)
            {
                _isActive = true;
                OnStateChanged?.Invoke();
            }
        }
        else
        {
            if (IsActive)
            {
                _isActive = false;
                OnStateChanged?.Invoke();
                transform.localScale = _originalScale;
            }
        }
    }
}