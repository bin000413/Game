using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatAnimation : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private PhysicsCheck isground;
    private playerconter conter;
    //private playerconter 
    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        isground = GetComponent<PhysicsCheck>();
        conter = GetComponent<playerconter>();
    }
    void AnimationStar()
    {
        anim.SetFloat("velocity", Mathf.Abs(rb.velocity.x));
        anim.SetFloat("velocitY",rb.velocity.y);
        anim.SetBool("is grounf", isground.isGround);
        anim.SetBool("isdead", conter.isdead);
        anim.SetBool("isattack", conter.isattack);

    }
    void Update()
    {
        AnimationStar();

    }
    public void playerhurt()
    {
        anim.SetTrigger("hurt");
    }
    public void playerattack()
    {
        anim.SetTrigger("attack");
    }
}
