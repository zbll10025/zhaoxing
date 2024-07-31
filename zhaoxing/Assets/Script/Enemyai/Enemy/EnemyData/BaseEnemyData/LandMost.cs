using BehaviorDesigner.Runtime;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using Unity.Mathematics;
using Cysharp.Threading.Tasks;



public class LandMost : BaseEnemy
    {
 
        public AttackAreac AttackAreac;
        public BehaviorTree behaviorTree;
        public Most4Hit mosthit;
        public GameObject player;
        public Vector2 playerDirection;
        public float playerDistance;
         public bool ishit;
        public float hitForce;
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
        if (Input.GetKeyDown(KeyCode.Space)){

            Onhit();
        }

            
        }

        public virtual void Onhit()
        {
          ishit = true;
           Vector2 a = -playerDirection*hitForce;
         rig.AddForce(a, ForceMode2D.Impulse);
        }

        public void GetPlayerObject(){
            if (player == null)
            {
                player = GameObject.Find("Player");

            }
        }
        public void GetPlayerDirction()
        {
        if (player != null)
           playerDirection = (player.transform.position - Enemytransform.position).normalized;
        }

        public void GetPlayerDistance()
        {
        if(player != null)
             playerDistance = math.abs(player.transform.position.x - Enemytransform.position.x);
        }
    }
