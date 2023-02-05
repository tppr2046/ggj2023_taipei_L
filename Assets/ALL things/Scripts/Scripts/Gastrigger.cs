using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gastrigger : MonoBehaviour
{
    public bool dead = false;
    public Collider2D area;
    
    //[SerializeField] private BoxCollider2D Placeitemareacollider;
    public void putgas()
    {
        gameObject.GetComponent<ParticleSystem>().Play();
        dead = true;
        area.enabled = true;
    }
    void OnTriggerEnter2D(Collider2D collide)
    {
        //if (collide.gameObject.CompareTag("scientist"))
        if (dead)
        {
            if (collide.gameObject.CompareTag("cleaner"))
            {
                Destroy(GameObject.FindWithTag("cleaner"));
            }
            if (collide.gameObject.CompareTag("guard") )
            {
                Destroy(GameObject.FindWithTag("guard"));
            }
            if (collide.gameObject.CompareTag("scientist") )
            {
                Destroy(collide.gameObject);
            }
        }    


    }
}    

