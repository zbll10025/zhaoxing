using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class PlayerCheck : MonoBehaviour
{
    public bool findPlayer;

    private  void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
           
            findPlayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            findPlayer = false;
        }
        
    }

}
