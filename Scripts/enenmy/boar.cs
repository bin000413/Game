using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boar : Enenmy
{
    // Start is called before the first frame update

    protected override void Awake()
    {
        base.Awake();
        patrolstate = new BoarPatrolstate();
        chasestate = new BoarChaseState();
    }

  
    public override void move4()
    {
        base.move4();
        anim.SetBool("walk", true);
    }
}
