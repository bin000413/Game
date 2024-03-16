using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;// �����µ�unity����ϵͳ

public class playerconter : MonoBehaviour
{
    #region �����Ķ���
    public PlayInputConcrol inputControl;
    public Vector2 inputDirection;
    public Rigidbody2D rb;
    public PhysicsCheck physics;
    public SpriteRenderer sp;
    public PlatAnimation animtor;
    public CapsuleCollider2D coll;
    [Header("��������")]
    public float speend;
    public float jumpForce;
    public bool isHurt;
    public float hurtF;
    public bool isdead;
    public bool isattack;
    [Header("�������")]
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

    private void Attack(InputAction.CallbackContext obj)//Attack�¼�����
    {
        animtor.playerattack();
        isattack = true;
    }

    private void Jump(InputAction.CallbackContext obj)//jump�¼�����
    {
        if (physics.isGround)
          rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private void OnEnable()
    {
        inputControl.Enable();//��������ʱ����inputsystem
    }
    private void OnDisable()
    {
        inputControl.Disable();//�������ʱ�ر�inputsystem
    }
    void Update()
    {
        inputDirection = inputControl.GamePlay.Move.ReadValue<Vector2>();//ʵʱ���moveֵ
        CheekStar();//ʵʱ��������
    }
    private void FixedUpdate()
    {
        if(!isHurt)
            move2();
    }
    public void move2()//sprite���ʵ��move����
    {
        rb.velocity = new Vector2(inputDirection.x * speend * Time.deltaTime, rb.velocity.y);
        if (inputDirection.x<0)
            sp.flipX = true;
        if (inputDirection.x>0)
            sp.flipX = false;
    }
    public void move()//transform���ʵ��move����
    {
        rb.velocity = new Vector2(inputDirection.x * speend * Time.deltaTime, rb.velocity.y);
        int faceDir = (int)transform.localScale.x;
        if (inputDirection.x > 0)
            faceDir = 1;
        if (inputDirection.x<0)
            faceDir = -1;
        // ���ﷴת
        transform.localScale = new Vector3(faceDir, 1, 1);

    }
    public void GetHurt(Transform attacker)//���˻��˺���
    {
        isHurt = true;
        Vector2 dre = new Vector2(transform.position.x-attacker.position.x, 0).normalized;
        rb.AddForce(dre * hurtF, ForceMode2D.Impulse);
    }
    public void Ondead()//����ʵ��
    {
        isdead = true;
        inputControl.GamePlay.Disable();
        //Debug.Log(isdead);
    }
    public void CheekStar()//ʵʱ��⸡��״̬
    {
        coll.sharedMaterial = physics.isGround ? wall:nomal;
    }
}
