using Assets.Script.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public float speed;
    public Transform Enemytransform;
    public phychik phy;
    public Rigidbody2D rig;
    public float currentscal;
    [Header("ËÙ¶È")]
    public float patorlSpeed;
    public float rushSpeed;
    public float currentsSpeed;
    public Animator ani;
    [Header("×´Ì¬")]
    public bool isdead;
    protected  virtual void Awake()
    {

        Enemytransform = GetComponent<Transform>();
        phy = GetComponent<phychik>();
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        rig.velocity = new Vector2 (1, 1);
        currentscal = Enemytransform.localScale.x;
        currentsSpeed = patorlSpeed;
    }


    protected virtual void Update()
    {

        if(Input.GetKeyDown(KeyCode.K)){
            isdead = true;
        }

    }

}
