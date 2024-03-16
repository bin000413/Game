using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Basestate
{
    protected Enenmy currentenenmy;
    public abstract void OnEnter(Enenmy enenmy);
    public abstract void LogicUpdate();
    public abstract void PhysicsUpdate();
    public abstract void OnExit();
}
