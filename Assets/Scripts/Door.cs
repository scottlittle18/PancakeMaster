using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    
    BoxCollider2D box;

    string currentScene;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
    }

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

            if (currentScene != null)
            {
                SceneManager.LoadScene(currentScene + 1);
            }
            else
            {
                SceneManager.LoadScene(currentScene);
                
            }
        }
    }
}
