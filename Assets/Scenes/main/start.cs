using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start : MonoBehaviour 
{

    public Object scene1;
    public Object scene2;

    public void Start() 
    {

    }

    public void LoadLevel1() 
    {
        Debug.Log("loadlevel");
        Application.LoadLevel(scene1.name);
    }

    public void LoadLeve2()
    {
        Debug.Log("loadleve2");
        Application.LoadLevel(scene2.name);
    }

}
