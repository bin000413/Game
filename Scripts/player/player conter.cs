using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;// 接入新的unity控制系统

public class playerconter : MonoBehaviour
{
    #region 变量的定义
    public PlayInputConcrol inputControl;
    public Vector2 inputDirection;
    public Rigidbody2D rb;
    public PhysicsCheck physics;
    public SpriteRenderer sp;
    public PlatAnimation animtor;
    public CapsuleCollider2D coll;
    [Header("人物属性")]
    public float speend;
    public float jumpForce;
    public bool isHurt;
    public float hurtF;
    public bool isdead;
    public bool isattack;
    [Header("物理材质")]
    public PhysicsMaterial2D nomal;
    public PhysicsMaterial2D wall;
    #endregion
    private void Awake()
    {
        inputControl = new PlayInputConcrol();
        rb = GetComponent<Rigidbody2D>();
        inputControl.GamePlay.Jump.started += Jump;
        inputControl.GamePlay.atttack.started += Attack;
        physics = GetComponent<PhysicsCheck>();
        animtor = GetComponent<PlatAnimation>();
        coll = GetComponent<CapsuleCollider2D>();

    }

    private void Attack(InputAction.CallbackContext obj)//Attack事件函数
    {
        animtor.playerattack();
        isattack = true;
    }

    private void Jump(InputAction.CallbackContext obj)//jump事件函数
    {
        if (physics.isGround)
          rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private void OnEnable()
    {
        inputControl.Enable();//对象启用时启动inputsystem
    }
    private void OnDisable()
    {
        inputControl.Disable();//对象禁用时关闭inputsystem
    }
    void Update()
    {
        inputDirection = inputControl.GamePlay.Move.ReadValue<Vector2>();//实时检测move值
        CheekStar();//实时更换材质
    }
    private void FixedUpdate()
    {
        if(!isHurt)
            move2();
    }
    public void move2()//sprite组件实现move函数
    {
        rb.velocity = new Vector2(inputDirection.x * speend * Time.deltaTime, rb.velocity.y);
        if (inputDirection.x<0)
            sp.flipX = true;
        if (inputDirection.x>0)
            sp.flipX = false;
    }
    public void move()//transform组件实现move（）
    {
        rb.velocity = new Vector2(inputDirection.x * speend * Time.deltaTime, rb.velocity.y);
        int faceDir = (int)transform.localScale.x;
        if (inputDirection.x > 0)
            faceDir = 1;
        if (inputDirection.x<0)
            faceDir = -1;
        // 人物反转
        transform.localScale = new Vector3(faceDir, 1, 1);

    }
    public void GetHurt(Transform attacker)//受伤击退函数
    {
        isHurt = true;
        Vector2 dre = new Vector2(transform.position.x-attacker.position.x, 0).normalized;
        rb.AddForce(dre * hurtF, ForceMode2D.Impulse);
    }
    public void Ondead()//死亡实现
    {
        isdead = true;
        inputControl.GamePlay.Disable();
        //Debug.Log(isdead);
    }
    public void CheekStar()//实时检测浮空状态
    {
        coll.sharedMaterial = physics.isGround ? wall:nomal;
    }
}
