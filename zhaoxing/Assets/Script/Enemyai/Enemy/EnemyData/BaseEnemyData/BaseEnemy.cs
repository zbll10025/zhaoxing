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
    [Header("��ʼ�����")]
    public bool isRightLocalscal;
    public int Id;
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
    [Header("������")]
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
        //֮�󲹵�����ǽ��ȫ���
        isGround = true;
        ishit = false;


    }


    protected virtual void Update()
    {

        //�����ж�����L
        if(Input.GetKeyDown(KeyCode.L)){
            isdead = true;
        }
        //���������ж�
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
        //����ת��
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
