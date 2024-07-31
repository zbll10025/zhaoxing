using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Pool
{
    public GameObject prefabe;
    private Queue<GameObject> _pool=new Queue<GameObject>();

    public void Creatpool(string path,int max)
    {
        for(int i = 0; i < max; i++)
        {
            GameObject gameobject = CreatObject(path);
            if(gameobject != null)
            {
                _pool.Enqueue(gameobject);
            }
        }
    }

    public GameObject Get(string path)
    {
          if (_pool.Count != 0)
        {
            return _pool.Dequeue();
        }
        else
        {
            return CreatObject(path);
        }
    }

    public void Recycle(GameObject obj)
    {
        obj.SetActive(false);
        _pool.Enqueue(obj);
    }

    public void ClearPool()
    {
        for(int i = 0; i < _pool.Count; i++)
        {
            var gameobject = _pool.Dequeue();
           // Destroy(gameobject);
        }
    }

    public GameObject CreatObject(string path)
    {
        Debug.Log("ря╪сть");
      return GameObject.Instantiate(Resources.Load("Prefabs/Enemy/ReEnemy/Project/Rem5Projectile")) as GameObject;
    }
}
