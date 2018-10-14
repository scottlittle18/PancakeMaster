using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{

    protected Transform cursorPosition;

    public float cursorSensitivity;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        cursorPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    }
}
