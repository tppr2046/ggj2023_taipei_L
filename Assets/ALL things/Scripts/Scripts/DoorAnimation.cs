using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    public Animator animator;
    public void opendoor()
    {
        animator.Play("Open");
    }
}
