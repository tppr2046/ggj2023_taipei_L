using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSystem : MonoBehaviour
{
    [SerializeField] private DoorAnimation door;
    [SerializeField] private IDdooranimation IDdoor;
    [SerializeField] private Gastrigger Gas;
    private bool buttontrigger = false;
    private bool gasbuttontrigger = false;
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && buttontrigger)
        {
            Destroy(GameObject.FindWithTag("Button1"));
            door.opendoor();
        }
        if (Input.GetKey(KeyCode.Space) && gasbuttontrigger)
        {
            Gas.putgas();
        }
    }
    void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.gameObject.CompareTag("Button1"))
        {
            buttontrigger= true;
        }
        if (collide.gameObject.CompareTag("IDRegion"))
        {
            IDdoor.openIDdoor();
        }
        if (collide.gameObject.CompareTag("GasButton"))
        {
            gasbuttontrigger = true;
        }
    }
    //void OnTriggerEnter2D(Gascollide collide)
    //{

    //}
    //GasRegion=gameObject.GetComponent<GasRegion>();
}
