using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundHandler : MonoBehaviour {

    public static SoundHandler instance = null;

    [SerializeField]
    AudioClip[] gameFX = new AudioClip[1];

    [SerializeField]
    AudioClip buttonClick;

    [SerializeField]
    AudioClip mouseOverButton;

    [SerializeField]
    AudioSource gameSound;
	// Use this for initialization
	void Start () {
        gameSound = GetComponent<AudioSource>();
	}

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
		
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
