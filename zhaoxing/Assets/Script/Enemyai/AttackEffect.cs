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
//������ӵ��򹭼����������Ч��
