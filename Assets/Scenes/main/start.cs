using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start : MonoBehaviour 
{

    public Object scene;

    public void Start() 
    {

    }

    public void LoadLevel1() 
    {
        Debug.Log("loadlevel");
        Application.LoadLevel(scene.name);
    }

}
