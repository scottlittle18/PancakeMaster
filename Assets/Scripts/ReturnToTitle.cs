﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToTitle : MonoBehaviour
{
	void Update ()
    {
		if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("Title Screen");
        }
	}
}
