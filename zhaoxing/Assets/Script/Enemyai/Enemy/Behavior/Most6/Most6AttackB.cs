using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
public class Most6AttackB : Most6Attack
{
    public GameObject prefab2;



    public override void OnAwake()
    {
        base.OnAwake();
        prefab2 = Resources.Load("")as GameObject;
    }
    public override TaskStatus OnUpdate()
    {
        prefab2.transform.position = most6Data.BAttack.transform.position;
        prefab2.transform.eulerAngles = new Vector3(0,0,lunchAngel.z+90);
        prefab2.SetActive(true);
        return TaskStatus.Success;
    }
}
