using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoundHandler : MonoBehaviour {

    public static SoundHandler instance = null;

    [SerializeField]
    AudioClip[] gameFX = new AudioClip[1];

    [SerializeField]
    AudioClip buttonClick;

    [SerializeField]
    AudioClip mouseOverButton;

    [SerializeField]
    AudioSource gameSound, gameMusic;

    int currentScene;

	// Use this for initialization
	void Start () {

    }

    void Awake()
    {
        //Check if there is already an instance of SoundManager
        if (instance == null)
            //if not, set it to this.
            instance = this;
        //If instance already exists:
        else if (instance != this)
            //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
            Destroy(gameObject);

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);

        //gameSound = GetComponent<AudioSource>();
        currentScene = SceneManager.GetActiveScene().buildIndex;

        LevelCheck();
    }

    // Update is called once per frame
    void Update () {
	}

    void LevelCheck()
    {
        switch (currentScene)
        {
            case 0:
                instance.PlayTitleMusic();
                break;
            case 1:
                instance.PlayGameMusic();
                break;
            case 5:
                instance.PlayGameOverSound();
                break;
        }
    }

    void PlayTitleMusic()
    {
        //gameSound.PlayOneShot(gameFX[1]);
        gameMusic.Stop();
        gameMusic.clip = gameFX[1];
        gameMusic.loop = true;
        gameMusic.Play();
    }

    void PlayGameMusic()
    {

            gameMusic.Stop();
            gameMusic.clip = gameFX[2];
            gameMusic.loop = true;
            gameMusic.Play();
        //if (gameSound.clip != gameFX[2])
        //{
        //}
    }

    void PlayGameOverSound()
    {
        gameMusic.Stop();
        gameMusic.clip = gameFX[3];
        gameMusic.loop = false;
        gameMusic.Play();
    }

    public void MouseOverSound()
    {
        gameSound.PlayOneShot(mouseOverButton);
    }

    public void PlayGameSound(int newClip)
    {
        gameSound.PlayOneShot(gameFX[newClip]);
    }

    public void PlayUISound()
    {
        gameSound.PlayOneShot(buttonClick);
    }
}
