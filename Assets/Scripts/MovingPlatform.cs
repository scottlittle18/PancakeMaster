﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
    private bool active, isAttacking;
    private float goalHeight, originHeight, endHeight;

    [SerializeField]
    private float readyHeight, attackHeight;


    private void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision) //other.CompareTag("Some tag")
    {

        Debug.Log("Collision detected!");

        if (collision.CompareTag("Player"))
        {
            originHeight = transform.position.y;
            goalHeight = originHeight + readyHeight;
            endHeight = originHeight + readyHeight + attackHeight;
            active = true;
        }
    }

    private void Update()
    {
        if (active) //checks to see if spike ready to move up
        {
            Debug.Log("Ready to move!");
            if (transform.position.y < endHeight) //checks to see if it's at the final height
            {
                if (transform.position.y < goalHeight) //if current height is less than the goal height it moves up until it reaches it
                {
                    transform.Translate(Vector3.up * Time.deltaTime);
                }
                else //once it reaches the ready height, sets a new goal height
                {
                    goalHeight += attackHeight;
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
                Debug.Log("Resetting...");
                transform.Translate(Vector3.down * Time.deltaTime);
            }
        }
    }
}
