using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Most8Fire : MonoBehaviour
{
 public   Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();    
    }


    private void Update()
    {
        if (transform.parent.gameObject.GetComponent<Animator>().GetBool("canAttack"))
        {
            animator.SetBool("canAttack", true);
        }
        else
        {
            animator.SetBool("canAttack", false);
        }
    }

}
