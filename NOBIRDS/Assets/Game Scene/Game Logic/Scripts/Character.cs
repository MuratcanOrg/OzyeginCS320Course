using UnityEngine;
using System.Collections;
using System;

public class Character : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
       getInput();

    }

    private void getInput()
    {
        if (isTapDown())
        {
            GameLogic.stopScrolling();
        }
        if (isTapUp())
        {
            GameLogic.startScrolling();
        }
    }

    private bool isTapDown()
    {
        return Input.GetMouseButtonDown(0);
    }

    private bool isTapUp()
    {
        return Input.GetMouseButtonUp(0);
    }
}
