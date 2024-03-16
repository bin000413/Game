using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarChaseState : Basestate
{  
    public override void OnEnter(Enenmy enenmy)
    {
        currentenenmy = enenmy;
        //Debug.Log("chase");
        currentenenmy.currentspeek = currentenenmy.runspeek;
        currentenenmy.anim.SetBool("run", true);
    }
    public override void LogicUpdate()
    {
        if (!currentenenmy.pck.isGround || (currentenenmy.pck.leftwalk && (currentenenmy.transform.localScale.x > 0)) || (currentenenmy.pck.rightwalk && (currentenenmy.transform.localScale.x < 0)))
        {
            //Debug.Log("chase1");
            currentenenmy.transform.localScale = new Vector3(-currentenenmy.transform.localScale.x, 1, 1);
        }
        if(currentenenmy.losttimecountrol<=0)
        {
            currentenenmy.SwitchState(NPCState.patorlState);
        }
 
    }

    public override void PhysicsUpdate()
    {

    }
    public override void OnExit()
    {
        currentenenmy.anim.SetBool("run", false);
        currentenenmy.losttimecountrol = currentenenmy.losttime;
    }


}
