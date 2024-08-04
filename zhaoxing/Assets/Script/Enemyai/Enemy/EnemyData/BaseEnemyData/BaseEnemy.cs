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
    [Header("初始化相关")]
    public bool isRightLocalscal;
    [Header("速度")]
    public float patorlSpeed;
    public float rushSpeed;
    public float currentsSpeed;
    public Animator ani;
    [Header("状态")]
    public float hp;
    public bool isdead;
    public bool ishit;
    public bool isGround;
    [Header("攻击")]
    public float attackValue;
    [Header("力相关")]
    public float dashForce;
    public float hitForce;
    [Header("子物体上组件相关")]
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
        //之后补地面与墙的全检测
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
