using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BehaviorManager1 : MonoBehaviour
{
    List<IBehavior1> _behaviors = new List<IBehavior1>();
    IBehavior1 _currentBehavior;

    private void Awake()
    {
        _behaviors = GetComponents<IBehavior1>().ToList();
        _currentBehavior = _behaviors.First();
    }

    private void Update()
    {
        _currentBehavior.Tick();
    }
}
