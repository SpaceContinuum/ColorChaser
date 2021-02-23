using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //public Animator animator;
    public CharController controller;
    public float runSpeed = 40f;

    private float horizontalMove = 0f;
    private bool jump = false;


    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (horizontalMove == 0)
        {
            //animator.SetBool("isMove", true);
        }
        else
        {
            //animator.SetBool("isMove", false);
        }

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            // Need to test jumps with animations
            //animator.SetBool("isJump", true);
        }

    }

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
        //animator.SetBool("isJump", false);
    }
}
