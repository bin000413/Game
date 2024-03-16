using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class Enenmy : MonoBehaviour
{
    #region 定义变量
    public Animator anim;
    protected Rigidbody2D rb;
    public float F;
    public float currentspeek;
    public float wallspeek;
    public float runspeek;
    public Vector3 feac;
    public PhysicsCheck pck;
    [Header("状态")]
    public bool isdead;
    public bool ishurt;
    [Header("检测")]
    public Vector2 centerOffset;
    public Vector2 checkSize;
    public float checkDistance;
    public LayerMask attackLayer;
    [Header("计时器")]
    public float waittime;
    public float waittimecountrol;
    public bool wait;
    public float losttime;
    public float losttimecountrol;
    public Transform transattack;
    [Header("状态机")]
    public Basestate currentstate;
    public Basestate patrolstate;
    public Basestate chasestate;
    #endregion
    protected virtual void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        pck = GetComponent<PhysicsCheck>();
    }
    // Start is called before the first frame update
    private void Start()
    {
        waittimecountrol = waittime;
    }
    public void OnEnable()
    {
        currentstate = patrolstate;
        currentstate.OnEnter(this);
    }

    // Update is called once per frame
    private void Update()
    {
        currentstate.LogicUpdate();
        walktime();

    }
    private void FixedUpdate()
    {
        //Debug.Log("fixeupdata");
        if (!ishurt && !isdead)
        {
            move4();

        }
    }
    public virtual void move4()
    {//fiex
        rb.velocity = new Vector2( -transform.localScale.x* currentspeek*Time.deltaTime , rb.velocityY);
    }
    public void walktime()
    {
        if (wait)
        {
            rb.velocity = new Vector2(0, rb.velocityY);
            waittimecountrol -= Time.deltaTime;
            
            if (waittimecountrol <= 0) 
            {
                transform.localScale = new Vector3(feac.x, 1, 1);
                wait = false;
                waittimecountrol = waittime;             
            }
            
        }
        if (!FoundPlayer()&&losttimecountrol>0)
        {
            losttimecountrol -= Time.deltaTime;
        }
        else { }

    }
    public bool FoundPlayer()
    {
        return (bool)Physics2D.BoxCast((Vector2)transform.position + centerOffset, centerOffset, 0, feac, checkDistance, attackLayer);
    }
    public void SwitchState(NPCState state)
    {
        var newState = state switch
        {
            NPCState.chaseState => chasestate,
            NPCState.patorlState => patrolstate,
            _ => null,
        };
        currentstate.OnExit();
        currentstate=newState;
        currentstate.OnEnter(this);

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere((Vector2)transform.position + centerOffset, 0.1f);
    }
    #region enevnt 事件
    public void Takedamage(Transform attacker)
    {
        transattack = attacker;
        if (attacker.position.x - transform.position.x < 0)
            transform.localScale = new Vector3(1, 1, 1);
        if (attacker.position.x-transform.position.x > 0)
            transform.localScale = new Vector3(-1, 1, 1);
        ishurt = true;
        anim.SetTrigger("hurt");
        Vector2 der = new Vector2(transform.position.x - attacker.position.x, 0).normalized;
        rb.AddForce(der * F, ForceMode2D.Impulse);
        StartCoroutine(Onhurt(der));
    }
    private IEnumerator Onhurt(Vector2 der)
    {
        yield return new WaitForSeconds(0.5f);
        ishurt = false;
    }
    public void Ondead()
    {
        isdead = true;
        anim.SetBool("isdead", true);
    }
    public void frieanimation()
    {
        Destroy(this.gameObject);
    }
    #endregion
}
