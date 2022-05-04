﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighting : MonoBehaviour
{
    private Animator anim;
    public float cooldownTime = 2f;
    private float nextFireTime = 0f;
    public static int numOfClicks = 0;
    float lastClickedTime = 0;
    float maxComboDelay = 1;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("Hit1"))
        {
            anim.SetBool("Hit1", false);
        }
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("Hit2"))
        {
            anim.SetBool("Hit2", false);
        }
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("Hit3"))
        {
            anim.SetBool("Hit3", false);
        }
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("Hit4"))
        {
            anim.SetBool("Hit4", false);
            numOfClicks = 0;
        }

        if(Time.time - lastClickedTime > maxComboDelay)
        {
            numOfClicks = 0;
        }
        if(Time.time > nextFireTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                onClick();
            }
        }
    }

    void onClick()
    {
        lastClickedTime = Time.time;
        numOfClicks++;
        if(numOfClicks == 1)
        {
            anim.SetBool("Hit1", true);
        }
        numOfClicks = Mathf.Clamp(numOfClicks, 0, 4);

        if(numOfClicks >= 2 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("Hit1"))
        {
            anim.SetBool("Hit1", false);
            anim.SetBool("Hit2", true);
        }
        if(numOfClicks >= 3 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("Hit2"))
        {
            anim.SetBool("Hit2", false);
            anim.SetBool("Hit3", true);
        }
        if(numOfClicks >= 3 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("Hit2"))
        {
            anim.SetBool("Hit3", false);
            anim.SetBool("Hit4", true);
        }
    }
}
