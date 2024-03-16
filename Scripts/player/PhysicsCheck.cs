using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCheck : MonoBehaviour
{
    [Header("检测物体")]
    public Vector2 bott;
    public Vector2 leftbott;
    public Vector2 rightbott;
    public float checkRaduis;
   // public bool manual;
    [Header("状态")]
    public bool isGround;
    public bool leftwalk;
    public bool rightwalk;

    private CapsuleCollider2D coll; 
    public LayerMask GroundLayer;
    public void Awake()
    {
        coll = GetComponent<CapsuleCollider2D>();
        //if (!manual)
       // {

       // }
    }
    public void Check()
    {
        //检测地面
        isGround = Physics2D.OverlapCircle(((Vector2)transform.position+bott)*(Vector2)transform.localScale, checkRaduis,GroundLayer);
        leftwalk = Physics2D.OverlapCircle((Vector2)transform.position+leftbott, checkRaduis,GroundLayer);  
        rightwalk = Physics2D.OverlapCircle((Vector2)transform.position+rightbott, checkRaduis,GroundLayer);   
    }
    void Update()
    {
        Check();
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere((Vector2)transform.position + bott, checkRaduis);
        Gizmos.DrawWireSphere((Vector2)transform.position + leftbott, checkRaduis);
        Gizmos.DrawWireSphere((Vector2)transform.position + rightbott, checkRaduis);
    }
}
