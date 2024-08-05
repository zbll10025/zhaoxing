using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Most19Data : LandMost
{
    [Header("状态")]
            public bool isHide;
    protected override void Awake()
    {
        base.Awake();
        
    }
    public override void Onhit()
    {
        base.Onhit();
        isHide = true;
    }

    public void Cancel_AinisHide()
    {
        ani.SetBool("isHide",false);
    }
}
