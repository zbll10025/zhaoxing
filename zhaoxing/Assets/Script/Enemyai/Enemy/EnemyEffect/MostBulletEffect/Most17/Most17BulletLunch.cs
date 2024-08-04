using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Most17BulletLunch : MostBulletLunch
{
    public void LunchMost17Fx()
    {  
        lunchDirc =   GetBulletDirc(lunchTransform);
        MostBulletData bullet = GetBullet("Rem17AttackFX");
        GameObject objBullet = PoolManger.Instance.Get(bullet.name, bullet.path);
        if (objBullet == null) { Debug.Log(bullet.name + "ʵ����Failure"); return; }
        objBullet.transform.position = lunchTransform.position; 
        FixObjectDirc(lunchDirc, bullet.isRightLocalscal, objBullet);
        objBullet.SetActive(true);
        Vector2 dir = new Vector2(lunchDirc.x, 0);
        objBullet.GetComponent<MostBullet>().Onstart_Velocity(dir, bullet.speed);
    
    }

    public void LunchMost17Bullet()
    {
        lunchDirc = GetBulletDirc(lunchTransform);
        MostBulletData bullet = GetBullet("Rem17Bullet");
        GameObject objBullet = PoolManger.Instance.Get(bullet.name, bullet.path);
        if (objBullet == null) { Debug.Log(bullet.name + "ʵ����Failure"); return; }
        objBullet.transform.position = lunchTransform.position;
        FixObjectDirc(lunchDirc, bullet.isRightLocalscal, objBullet);
        objBullet.SetActive(true);
        Vector2 dir = new Vector2(lunchDirc.x, 0);
        objBullet.GetComponent<MostBullet>().Onstart_Velocity(dir, bullet.speed);

    }
}
