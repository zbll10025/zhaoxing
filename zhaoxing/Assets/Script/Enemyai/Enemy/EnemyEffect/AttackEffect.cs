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
        //����صĻ���
    }
}
//������ӵ��򹭼����������Ч��
