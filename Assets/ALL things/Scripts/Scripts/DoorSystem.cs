using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSystem : MonoBehaviour
{
    public List<string> Keylist;
    [SerializeField] private DoorAnimation door;
    [SerializeField] private IDdooranimation IDdoor;
    void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.gameObject.CompareTag("Button1"))
        {
            Destroy(GameObject.FindWithTag("Button1"));
            door.opendoor();
        }
        if (collide.gameObject.CompareTag("IDRegion"))
        {
            IDdoor.openIDdoor();
        }
    }
}
