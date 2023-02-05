using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    public Animator animator;
    public bool inArea;
    public AudioSource source;
    public AudioClip OpenSound;


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
        source.PlayOneShot(OpenSound);
        animator.Play("Open");
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
