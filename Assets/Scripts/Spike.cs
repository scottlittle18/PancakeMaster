﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{

    private bool active, wasActive, isAttacking;
    private float goalHeight, originHeight, endHeight;

    [SerializeField]
    private float readyHeight, attackHeight, checkRadius;

    [SerializeField]
    private Transform playerCheck;

    [SerializeField]
    private LayerMask whatIsPlayer;

    [SerializeField]
    private BoxCollider2D warningSpike;

    [SerializeField]
    private float extensionSpeed;

    AudioSource spikeSound;

    private void Start()
    {
        spikeSound = GetComponent<AudioSource>();
        originHeight = transform.position.y;
        Reset();
    }
    private void FixedUpdate()
    {
        //Sets the active variable
        wasActive = active;

        active = Physics2D.OverlapCircle(playerCheck.position,
            checkRadius, whatIsPlayer);

        if (active && !wasActive)
            spikeSound.Play();

        if (active)
        {
            if (transform.position.y < endHeight) //checks to see if it's at the final height
            {
                if (transform.position.y < goalHeight) //if current height is less than the goal height it moves up until it reaches it
                {
                    transform.Translate(Vector3.up * Time.deltaTime * extensionSpeed);
                }
                else //once it reaches the ready height, sets a new goal height
                {
                    goalHeight += attackHeight;
                    this.GetComponent<BoxCollider2D>().enabled = true;
                }
            }
            else //once it reaches end height, sets active to false, which lets it lower again
            {
                active = false;
            }
        }
        else //not active, either through being in origin or final height
        {
            if (transform.position.y > originHeight) //sees if it's higher than origin
            {
                this.GetComponent<BoxCollider2D>().enabled = false;
                transform.Translate(Vector3.down * Time.deltaTime);
                Reset();
            }
        }
    }
    private void Reset()
    {
        goalHeight = originHeight + readyHeight;
        endHeight = originHeight + readyHeight + attackHeight;
    }
}


