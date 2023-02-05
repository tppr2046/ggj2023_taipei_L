using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    public Animator animator;
    bool inArea;


    void Update()
    {
        if (inArea)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                opendoor();
            }
        }
    }

    public void opendoor()
    {
        animator.Play("DoorAnimation");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            //opendoor();
            inArea = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            inArea = false;

        }
    }
}
