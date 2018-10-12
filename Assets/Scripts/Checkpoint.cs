using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Checkpoint : MonoBehaviour
{
    public bool isActivated = false;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //creates a variable that refers to the PlayerController
            PlayerController player = collision.GetComponent<PlayerController>();

            //Sends whatever object this script is attached to  to the PlayerController
            player.SetCurrentCheckpoint(this);
        }
    }

    public void SetAsActivated(bool value)
    {
        isActivated = value;
    }
}
