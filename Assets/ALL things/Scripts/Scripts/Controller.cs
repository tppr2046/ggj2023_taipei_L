using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    //public List<string> Keylist;
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.position += new Vector3(0.02f, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.position += new Vector3(-0.02f, 0, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.position += new Vector3(0, 0.02f, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.position += new Vector3(0, -0.02f, 0);
        }
        
    }
}
