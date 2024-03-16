using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class BoarPatrolstate : Basestate
{
    public override void OnEnter(Enenmy enenmy)
    {
        currentenenmy = enenmy;
        currentenenmy.currentspeek = currentenenmy.wallspeek;
    }

    public override void LogicUpdate()
    {
        if (currentenenmy.FoundPlayer())
        {
            currentenenmy.SwitchState(NPCState.chaseState);
        }
        currentenenmy.feac = new Vector3(-currentenenmy. transform.localScale.x, 0, 0);
        if (!currentenenmy.pck.isGround||(currentenenmy.pck.leftwalk && (currentenenmy.transform.localScale.x > 0)) || (currentenenmy.pck.rightwalk && (currentenenmy.transform.localScale.x < 0)))
        {
            //Debug.Log("wall");
            currentenenmy.wait = true;
            currentenenmy.anim.SetBool("walk", false);

        }else { currentenenmy.anim.SetBool("walk", true); }
        //currentenenmy.walktime();
    }
    public override void PhysicsUpdate()
    {
      
    }

    public override void OnExit()
    {
        currentenenmy.wait = false;
    }

}
