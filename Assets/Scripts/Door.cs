using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public string Level = "";
    BoxCollider2D box;

    private void Awake()
    {
        box = GetComponent<BoxCollider2D>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Collision detected.");

        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && other.tag == "Player")
        {
            Debug.Log("Up command registered.");

            if (Level == "")
            {
                Debug.Log("Next level not specified.");
            }
            else
            {
                Debug.Log("Next level loading.");
                SceneManager.LoadScene(Level);
            }
        }
    }
}
