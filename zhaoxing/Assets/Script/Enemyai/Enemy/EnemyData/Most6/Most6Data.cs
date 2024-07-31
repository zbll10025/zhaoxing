using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Most6Data : LandMost
{
   public PlayerCheck PlayerCheck;
    public GameObject BAttack;
    protected override void Awake()
    {
        base.Awake();
        PlayerCheck= transform.Find("PlayerCheck").gameObject.GetComponent<PlayerCheck>();
        BAttack = transform.Find("BAttackLunch").gameObject;
    }
}
