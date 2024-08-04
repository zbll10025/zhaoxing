using BehaviorDesigner.Runtime;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using Unity.Mathematics;
using Cysharp.Threading.Tasks;



public class LandMost : BaseEnemy
    {
 
        
       //前十个地面怪物检测组件的方法在各自的子类里
        public BehaviorTree behaviorTree;

        public GameObject player;
        public Vector2 playerDirection;
        public float playerDistance;
       
       
        protected override void Awake()
        {
           base.Awake();
           player = GameObject.Find("Player");
           ishit=false;

        }  

        // Update is called once per frame
        protected override void Update()
        {
             base.Update();
            GetPlayerObject();
            GetPlayerDirction();
            GetPlayerDistance();
        //按空格受伤触发
        if (Input.GetKeyDown(KeyCode.P)){

            Onhit();
        }

            
        }

        public virtual void Onhit()
        {
            ishit = true;
            Vector2 a = -playerDirection*hitForce;
            rig.AddForce(a, ForceMode2D.Impulse);
            hp -= 20;
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
        else {
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

    public void GetPlayerObject(){
            if (player == null)
            {
                player = GameObject.Find("Player");

            }
        }
        public void GetPlayerDirction()
        {
        GetPlayerObject();
        if (player != null)
           playerDirection = (player.transform.position - Enemytransform.position).normalized;
        }

        public void GetPlayerDistance()
        {
        GetPlayerObject();
        if (player != null)
             playerDistance = math.abs(player.transform.position.x - Enemytransform.position.x);
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

       

    public virtual void CancelAniAttack()
    {
        
        ani.SetBool("isAttack", false);
    }
}
