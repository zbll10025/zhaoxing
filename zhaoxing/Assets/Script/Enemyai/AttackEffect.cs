using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEffect : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")||collision.CompareTag("Platform"))
        PoolManger.Instance.Recycle("Rem5Projectile", this.gameObject);
    }
}
//这个是子弹或弓箭打中物体的效果
