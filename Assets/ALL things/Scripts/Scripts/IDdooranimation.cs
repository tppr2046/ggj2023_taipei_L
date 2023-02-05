using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDdooranimation : MonoBehaviour
{
    public Animator animator;
    public void openIDdoor()
    {
        animator.Play("NewAnimation");
    }
}
