using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSystem : MonoBehaviour
{
    public List<string> Keylist;
    [SerializeField] private DoorAnimation door;
    [SerializeField] private IDdooranimation IDdoor;
    private bool buttontrigger = false;
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && buttontrigger)
        {
            Destroy(GameObject.FindWithTag("Button1"));
            door.opendoor();
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
    }
}
