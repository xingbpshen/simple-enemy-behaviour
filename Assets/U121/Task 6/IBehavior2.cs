using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBehavior2
{
    Action OnStateChanged { get; set; }
    
    bool IsActive { get; }
    void Tick();
}
