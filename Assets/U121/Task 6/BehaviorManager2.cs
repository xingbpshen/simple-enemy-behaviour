using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR;

public class BehaviorManager2 : MonoBehaviour
{
    List<IBehavior2> _behaviors = new List<IBehavior2>();
    IBehavior2 _currentBehavior;
    
    private void Awake()
    {
        _behaviors = GetComponents<IBehavior2>().ToList();
        _currentBehavior = _behaviors.First();
    }

    private void OnEnable()
    {
        foreach (var b in _behaviors)
        {
            b.OnStateChanged += HandleOnStateChanged;
        }
    }

    private void OnDisable()
    {
        foreach (var b in _behaviors)
        {
            b.OnStateChanged -= HandleOnStateChanged;
        }
    }

    private void HandleOnStateChanged()
    {        
        _currentBehavior = _behaviors.FindLast(b => b.IsActive); 
    }

    private void Update()
    {
        _currentBehavior.Tick();
    }
}
