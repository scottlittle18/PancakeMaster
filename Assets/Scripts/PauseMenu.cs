using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SceneLoader))]
public class PauseMenu : MonoBehaviour {

    private bool paused = false;
    public GameObject PauseUI;
    private SceneLoader sceneLoader;

	// Use this for initialization
	void Start ()
    {
        PauseUI.SetActive(false);
        sceneLoader = GetComponent<SceneLoader>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetButtonDown("Pause"))
        {
            paused = !paused;

            if (paused)
            {
                PauseUI.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                PauseUI.SetActive(false);
                Time.timeScale = 1;
            }
        }
	}

    public void Resume()
    {
        paused = false;
        PauseUI.SetActive(false);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        sceneLoader.LoadTitleScreen();
    }
}
