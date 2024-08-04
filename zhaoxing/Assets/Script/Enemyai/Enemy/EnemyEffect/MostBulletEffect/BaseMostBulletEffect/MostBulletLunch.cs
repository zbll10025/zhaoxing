using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class MostBulletLunch : MonoBehaviour
{
    public MostBullet_SO mostBullet_SO;
    public Transform lunchTransform;
    public Vector2 lunchDirc;
    protected virtual void Awake()
    {
        mostBullet_SO = Resources.Load<MostBullet_SO>("So/MostBullet_So");
    }
    public MostBulletData GetBullet(string bulletName)
    {
        MostBulletData bullet = mostBullet_SO.List_MostBullet.Find(i => i.name == bulletName);
        return bullet;
    }

    public Vector2 GetBulletDirc(Transform transform)
    {
        Vector2 var = new Vector2(transform.position.x - this.gameObject.transform.position.x, transform.position.y - this.gameObject.transform.position.y);
        return  var;    
    }

    public void FixObjectDirc(Vector2 _lunchDirc,bool isRghtLocalscale ,GameObject obj)
    {
        if (!isRghtLocalscale)
        {
            if (-_lunchDirc.x > 0)
            {
                obj.transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                obj.transform.localScale  =new Vector3(-1, 1, 1);
            }
        }
        else
        {
            if (_lunchDirc.x > 0)
            {
                obj.transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                obj.transform.localScale = new Vector3(-1, 1, 1);
            }

        }
    }
}
