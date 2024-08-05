using Assets.Script.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
public class BaseEnemy : MonoBehaviour
{
    public float speed;
    public Transform Enemytransform;
   
    public Rigidbody2D rig;
    public float currentscal;
    [Header("初始化相关")]
    public bool isRightLocalscal;
    public int Id;
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
    [Header("玩家相关")]
    public GameObject player;
    public Vector2 playerDirection;
    public float playerDistance;
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
        ishit = false;


    }


    protected virtual void Update()
    {

        //死亡判定按键L
        if(Input.GetKeyDown(KeyCode.L)){
            isdead = true;
        }
        //怪物受伤判定
        if (Input.GetKeyDown(KeyCode.P))
        {
           
            Onhit();
        }

    }
     public virtual void Onhit()
        {
            ishit = true;
            Vector2 a = -playerDirection * hitForce;
            rig.AddForce(a, ForceMode2D.Impulse);
            hp -= 20;
        //受伤转身
            if (!isRightLocalscal)
            {
                if (-playerDirection.x > 0)
                {
                    this.gameObject.transform.localScale = new Vector3(1, 1);
                }
                else
                {
                    this.gameObject.transform.localScale = new Vector3(-1, 1);
                }
            }
            else
            {
                if (playerDirection.x > 0)
                {
                    this.gameObject.transform.localScale = new Vector3(1, 1);
                }
                else
                {
                    this.gameObject.transform.localScale = new Vector3(-1, 1);
                }

            }


        }
    public virtual void Cancel_isHit()
    {
        ishit = false;
    }

  
         public void FixDirc()
            {
                LandMost landEnemy = this.GetComponent<LandMost>();

                if (!landEnemy.isRightLocalscal)
                {
                    if (-landEnemy.playerDirection.x > 0)
                    {
                        landEnemy.gameObject.transform.localScale = new Vector3(1, 1, 1);
                    }
                    else
                    {
                        landEnemy.gameObject.transform.localScale = new Vector3(-1, 1, 1);
                    }
                }
                else
                {
                    if (landEnemy.playerDirection.x > 0)
                    {
                        landEnemy.gameObject.transform.localScale = new Vector3(1, 1, 1);
                    }
                    else
                    {
                        landEnemy.gameObject.transform.localScale = new Vector3(-1, 1, 1);
                    }
                }
            }

   

    public void GetPlayerDistance()
    {
        GetPlayerObject();
        if (player != null)
            playerDistance = math.abs(player.transform.position.x - Enemytransform.position.x);
    }

    public void GetPlayerDirction()
    {
        GetPlayerObject();
        if (player != null)
            playerDirection = (player.transform.position - Enemytransform.position).normalized;
    }

    public void GetPlayerObject()
    {
        if (player == null)
        {
            player = GameObject.Find("Player");

        }
    }

   


}
