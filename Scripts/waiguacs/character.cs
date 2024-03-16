using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class character : MonoBehaviour
{

    [Header("基本属性")]
    public float Maxhealth;
    public float nowhealth;
    [Header("无敌时间调整")]
    public float invulnerableDuration;
    private float invulnerablecounterl;
    public bool invulnerable;
    public UnityEvent<character> OnheakthChange;
    public UnityEvent<Transform> Onhurt;
    public UnityEvent Isdead;
    //public UnityEvent<> 

    private void Start()
    {
        nowhealth = Maxhealth;
        OnheakthChange?.Invoke(this);
    }
    private void Update()
    {
        if (invulnerable)
        {
            invulnerablecounterl -= Time.deltaTime;
            if(invulnerablecounterl<=0) 
            { 
                invulnerable = false;
                
            }
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("whater"))
        {
            Debug.Log("deade");
            nowhealth = 0;
            OnheakthChange?.Invoke(this);
            Isdead?.Invoke();
        }
    }
    private void finvulnerbale()
    {
        if (!invulnerable)
        {
            invulnerable = true;
            invulnerablecounterl = invulnerableDuration;
        }
 

    }
    public void TakeDamage(attced attack)
    {
        if (invulnerable)
            return;


        if (nowhealth-attack.damage > 0)
        {
            nowhealth -= attack.damage;
            Onhurt.Invoke(attack.transform);
        }
        else { nowhealth = 0; Isdead.Invoke(); }
        finvulnerbale();
        OnheakthChange?.Invoke(this);


    }

}
