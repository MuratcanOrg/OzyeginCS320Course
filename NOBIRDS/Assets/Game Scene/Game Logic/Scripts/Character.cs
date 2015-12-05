using UnityEngine;
using System.Collections;
using System;

public class Character : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void getInput()
    {
        getInputFromMouse();
        getInputFromTouchScreen();



        
    }

    private void getInputFromMouse()
    { 
        if (Input.GetButtonDown("Fire1"))
        {
            onTapped();
            Debug.Log("Clicked");
        }
    }

    private void onTapped()
    {
        GameLogic.stopScrolling();
    }

    private void onDragging()
    {
        GameLogic.stopScrolling();
    }

    private void changeColumn()
    {
        GameLogic.stopScrolling();
    }
    private void getInputFromTouchScreen()
    {
        if (Input.touchCount > 0)
        {
            int i = 0;
            while (i < Input.touchCount)
            {
                //mouseX = mCamera.ScreenToWorldPoint(Input.GetTouch(i).position).x - gameObject.transform.position.x;
                //mouseZ = mCamera.ScreenToWorldPoint(Input.GetTouch(i).position).z - gameObject.transform.position.z;

                //++i;
                //if ((Mathf.Tan(1 * Mathf.PI / 6) * mouseX > mouseZ) && (Mathf.Tan(1 * Mathf.PI / 6) * mouseX < -mouseZ))
                //{
                //    //moveRandomly (1);
                //    moveRandomly((int)(directions[0].transform.eulerAngles.y / 360 * 4));
                //}
                //if ((Mathf.Tan(2 * Mathf.PI / 6) * mouseX > -mouseZ) && (Mathf.Tan(2 * Mathf.PI / 6) * mouseX > mouseZ))
                //{
                //    //moveRandomly (0);
                //    moveRandomly((int)(directions[1].transform.eulerAngles.y / 360 * 4));
                //}
                //if ((Mathf.Tan(1 * Mathf.PI / 6) * mouseX < mouseZ) && (Mathf.Tan(1 * Mathf.PI / 6) * mouseX > -mouseZ))
                //{
                //    //moveRandomly (3);
                //    moveRandomly((int)(directions[2].transform.eulerAngles.y / 360 * 4));
                //}
                //if ((Mathf.Tan(2 * Mathf.PI / 6) * mouseX < -mouseZ) && (Mathf.Tan(2 * Mathf.PI / 6) * mouseX < mouseZ))
                //{
                //    //moveRandomly (2);
                //    moveRandomly((int)(directions[3].transform.eulerAngles.y / 360 * 4));
                //}
            }
        }

    }
}
