using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBehavior1
{
    bool IsActive { get; }
    void Tick();
}
