using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gastrigger : MonoBehaviour
{
    [SerializeField] private BoxCollider2D Placeitemareacollider;
    public void putgas()
    {
        gameObject.GetComponent<ParticleSystem>().Play();
        Collider[] colliderarray = Physics.OverlapBox(Placeitemareacollider.transform.position, Placeitemareacollider.size, Placeitemareacollider.transform.rotation);
        foreach (Collider collider in colliderarray)
        {
            /*
            if (collider.transform.CompareTag("NPC"))
            {
                Destroy(GameObject.FindWithTag("NPC"));
            }*/
            Debug.Log(collider);
        }
    }
}
