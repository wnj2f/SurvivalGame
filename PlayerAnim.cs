using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Animator anim;

    void Start ()
    {
        anim = GetComponent<Animator>();
    }

    void Update ()
    {
        // Walk Animation Condition
        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        // Jump Animation Condition
        if (Input.GetButtonDown("Jump"))
        {
            anim.SetTrigger("jump");
        }

        // Weaponless Attack Animation Condition
        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("attack");
        }

        /*
        // Crouch Animation Condition
        if (Input.GetButtonDown("Crouch"))
        {
            anim.SetBool("isCrouching", true);
        }
        else
        {
            anim.SetBool("isCrouching", false);
        }
        */
    }
}
