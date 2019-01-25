using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ControlInputs : ScriptableObject
{
    public abstract void GetInputs(CarController cc);
}
