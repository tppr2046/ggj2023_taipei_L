using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gastrigger : MonoBehaviour
{
    private bool dead = false;
    //[SerializeField] private BoxCollider2D Placeitemareacollider;
    public void putgas()
    {
        gameObject.GetComponent<ParticleSystem>().Play();
        dead = true;
    }
    void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.gameObject.CompareTag("cleaner") && dead)
        {
            Destroy(GameObject.FindWithTag("cleaner"));
        }
        if (collide.gameObject.CompareTag("guard") && dead)
        {
            Destroy(GameObject.FindWithTag("guard") );
        }
        if (collide.gameObject.CompareTag("scientist") && dead)
        {
            Destroy(GameObject.FindWithTag("scientist"));
        }
    }
}    

