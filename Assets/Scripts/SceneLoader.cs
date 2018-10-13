﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
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
}
