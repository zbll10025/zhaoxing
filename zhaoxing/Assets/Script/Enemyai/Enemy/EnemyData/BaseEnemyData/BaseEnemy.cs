using Assets.Script.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public float speed;
    public Transform Enemytransform;
   
    public Rigidbody2D rig;
    public float currentscal;
    [Header("��ʼ�����")]
    public bool isRightLocalscal;
    [Header("�ٶ�")]
    public float patorlSpeed;
    public float rushSpeed;
    public float currentsSpeed;
    public Animator ani;
    [Header("״̬")]
    public float hp;
    public bool isdead;
    public bool ishit;
    public bool isGround;
    [Header("����")]
    public float attackValue;
    [Header("�����")]
    public float dashForce;
    public float hitForce;
    [Header("��������������")]
    public AttackAreac AttackAreac;
    public PlayerCheck playerCheck;
    protected  virtual void Awake()
    {

        Enemytransform = GetComponent<Transform>();
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        playerCheck = transform.Find("PlayerCheck").GetComponent<PlayerCheck>();
        AttackAreac = transform.Find("AttackAcrea").GetComponent<AttackAreac>();
        rig.velocity = new Vector2 (1, 1);
        currentscal = Enemytransform.localScale.x;
        currentsSpeed = patorlSpeed;
        //֮�󲹵�����ǽ��ȫ���
        isGround = true;


    }


    protected virtual void Update()
    {

        if(Input.GetKeyDown(KeyCode.K)){
            isdead = true;
        }

    }

    public virtual void Cancel_isHit()
    {
        ishit = false;
    }
}
