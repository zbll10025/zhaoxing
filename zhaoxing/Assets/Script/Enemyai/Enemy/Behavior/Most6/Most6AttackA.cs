using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
public class Most6AttackA : Most6Attack
{
    public GameObject prefab1;
   
    public override TaskStatus OnUpdate()
    {
         GameObject a = GameObject.Instantiate(prefab1,lunchDirection.transform.position,Quaternion.identity);
          a.transform.eulerAngles = lunchAngel;
        a.GetComponent<Rigidbody2D>().AddForce(dirce * force, ForceMode2D.Impulse);
          return TaskStatus.Success;
    }
}
