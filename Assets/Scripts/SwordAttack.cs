﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour {
    public Animator animator;
    private static readonly int hIsAttacking = Animator.StringToHash("isAttacking");

    // private float animationTimer = 0f;


    int noOfClicks;
    private bool canClick;
    private static readonly int hAttackNo = Animator.StringToHash("attackNo");

    // Start is called before the first frame update
    void Start() {
        animator.GetComponent<Animator>();

        noOfClicks = 0;
        canClick = true;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Fire1")) {
            
            Debug.Log("Fire: canClick: " + canClick+ " noOfClicks: " + noOfClicks+ ". Current Animation:" + animator.GetInteger(hAttackNo) );
            ComboStarter();
        }

        /*bool isAttacking = animator.GetBool("isAttacking");
        int attackNo = animator.GetInteger("attackNo");
        // // animator.GetCurrentAnimatorStateInfo(0).IsName("")
        // if (Input.GetButtonDown("Fire1")) {
        //     if (!isAttacking) {
        //         isAttacking = true;
        //         attackNo += 1;
        //     }
        //     else {
        //         if (attackNo < 3) {
        //             attackNo += 1;
        //         }
        //     }
        //     animator.SetBool("isAttacking", isAttacking);
        //     animator.SetInteger("attackNo", attackNo);
        //     // animationTimer = 5f;
        // }

        // if (animationTimer<=0f) {
        //     isAttacking = 0;
        // }
        // else {
        //     animationTimer -= 0.1f;
        // }


        if (Input.GetButtonDown("Fire1") && !isAttacking) {
            isAttacking = true;
            animator.SetBool(hIsAttacking, isAttacking);
        }
        
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("swing_1"))
        {
            // do something
        }
        else {
            
        }
        if (isAttacking) {
        }


        // set parameter*/
    }

    private void ComboStarter() {
        if (canClick) {
            noOfClicks++;
        }

        if (noOfClicks == 1) {
            animator.SetInteger(hAttackNo, 1);
        }
    }

    public void ComboCheck() {
        Debug.Log("ComboCheck: " + noOfClicks);
        canClick = false;

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("swing_1") && noOfClicks == 1) {
            
            // set to idle
            animator.SetInteger(hAttackNo, 0);

            // reset
            canClick = true;
            noOfClicks = 0;
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("swing_1") && noOfClicks >= 2) {
            // change to next attack
            animator.SetInteger(hAttackNo, 2);

            //reset
            canClick = true;
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("swing_2") && noOfClicks == 2) {
            
            Debug.Log("swing2 and noCLicks 2");
            // set to idle
            animator.SetInteger(hAttackNo, 0);

            // reset
            canClick = true;
            noOfClicks = 0;
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("swing_2") && noOfClicks >= 3) {
            // change to next attack
            animator.SetInteger(hAttackNo, 3);

            //reset
            canClick = true;
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("swing_3") ) {
            // set to idle
            animator.SetInteger(hAttackNo, 0);

            // reset
            canClick = true;
            noOfClicks = 0;
        }
    }
}