using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAnimation : MonoBehaviour
{
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void PlayRoll()
    {
        animator.SetBool("Dashing", true);
    }
}
