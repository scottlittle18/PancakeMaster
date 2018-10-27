using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverButtonSound : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public void OnMouseEnter()
    {        
        SoundHandler.instance.MouseOverSound();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
