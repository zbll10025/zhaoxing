using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
public class MostDash : Action
{
   public LandMost landEnemy;
    public Rigidbody2D rig;

    public override void OnAwake()
    {
       landEnemy = GetComponent<LandMost>();
       rig = GetComponent<Rigidbody2D>();
    }

    public override TaskStatus OnUpdate()
    {
           landEnemy.FixDirc();
        Vector2 dir = landEnemy.playerDirection;
        rig.AddForce(dir * landEnemy.dashForce, ForceMode2D.Impulse);
       return TaskStatus.Success;
    }
}
