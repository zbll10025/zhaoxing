using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
public class LandMostHit : Conditional
{
    public LandMost mostData;

    public override void OnAwake()
    {
        mostData = GetComponent<LandMost>();
    }
    public override TaskStatus OnUpdate()
    {

        if (mostData.ishit)
        {
            return OnHit();
        }
        else
        {
            return TaskStatus.Failure;
        }
    }



    public TaskStatus OnHit()
    {
        return TaskStatus.Success;
    }
}
