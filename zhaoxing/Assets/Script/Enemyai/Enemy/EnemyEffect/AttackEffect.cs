using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEffect : MonoBehaviour
{
    public string objectName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Platform")) { }
        PoolManger.Instance.Recycle(objectName, this.gameObject);
        //对象池的回收
    }
}
//这个是子弹或弓箭打中物体的效果
