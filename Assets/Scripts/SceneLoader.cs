using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    public void LoadTest()
    {
        SceneManager.LoadScene("Test Level");
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void LoadTitleScreen()
    {
        SceneManager.LoadScene("Title Screen");
    }
	
}
