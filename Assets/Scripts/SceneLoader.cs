using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    int currentScene;
    bool onPlay, onCredits;

    MouseCursor currentPosition;    

    LayerMask uiPlay, uiCredits;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        
    }

    private void Update()
    {
        onPlay = Physics2D.OverlapCircle(currentPosition.transform.position, currentPosition.cursorSensitivity, uiPlay);
        onCredits = Physics2D.OverlapCircle(currentPosition.transform.position, currentPosition.cursorSensitivity, uiCredits);

        if (onPlay && Input.GetButton("Fire1"))
            PlayGame();
        else if (onCredits && Input.GetButton("Fire1"))
            PlayCredits();



    }

    private void PlayGame()
    {
        
    }

    private void PlayCredits()
    {
        SceneManager.LoadScene(5);
        
    }
    /***
        public void LoadTest()
        {
            SceneManager.LoadScene("Test Level");
        }
        public void LoadTitleScreen()
        {
            SceneManager.LoadScene("Title Screen");
        }

        public void LoadLevel1()
        {
            SceneManager.LoadScene("Level 1");
        }

        public void LoadLevel2()
        {
            SceneManager.LoadScene("Level 2");
        }

        public void LoadLevel3()
        {
            SceneManager.LoadScene("Level 3");
        }

        public void LoadLevel4()
        {
            SceneManager.LoadScene("Level 4");
        }

        public void LoadCredits()
        {
            SceneManager.LoadScene("Credits");
        }
        ***/
}
