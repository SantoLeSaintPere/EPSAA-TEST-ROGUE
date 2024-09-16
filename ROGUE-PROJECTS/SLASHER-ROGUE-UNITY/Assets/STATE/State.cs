using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State 
{
    public abstract void InStart();
    public abstract void InUpdate(float time);

    public abstract void OnExit();
}
