using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDdooranimation : MonoBehaviour
{
    public Animator animator;
    bool inArea;

    public AudioSource source;
    public AudioClip OpenSound;

    private void Update()
    {
        if(inArea && Input.GetKeyDown(KeyCode.Space))
        {
            openIDdoor();
            source.PlayOneShot(OpenSound);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            if(collision.GetComponent<CollectStuff>().IDcard == true)
            {
                inArea = true;
            }
            


        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            inArea = false;


        }
    }


    public void openIDdoor()
    {
        animator.Play("Open");
        
    }
}
