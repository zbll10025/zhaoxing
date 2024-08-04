using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MostBullet : MonoBehaviour
{
    public Rigidbody2D rig;
    public bool CancelGrivaty;

    protected virtual void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        if (CancelGrivaty)
        {
           
        }
    }
    public void Onstart_Force(Vector2 dir, float force)
    {
        rig = GetComponent<Rigidbody2D>();
        rig.AddForce(dir * force, ForceMode2D.Impulse);
    }
    public void Onstart_Velocity(Vector2 dir,float speed)
    {
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = new Vector2(dir.x * speed, dir.y * speed);
    }
}
