using UnityEngine;
using System.Collections;
using System;

public class Character : MonoBehaviour {
    private Vector3 firstScale = new Vector3(1, 1, 1); 
    public Rigidbody2D rgdBody2D; 

    void Start () {
        rgdBody2D = GetComponent<Rigidbody2D>();
    }
     
    void FixedUpdate ()
    {  
        setSize();
        getInput();

    }

    private void setSize()
    {
        gameObject.transform.localScale = firstScale * GameLogic.hardnessRate;
    }

    private void getInput()
    {
        if (isTapDown())
        {
            move();
        }
        else
        {
            stop();
        }
    }

    private bool isTapDown()
    {
        return Input.GetMouseButton(0);
    }

    private void move()
    {
        switch (GameLogic.level)
        {
            case 1: 
                GameLogic.stopScrolling();
                break;
            case 2:
                trackColumnOfInput();
                break;
            case 3:
                trackCellOfInput();
                break;
            case 4:
                trackInputXOnRows();
                break;
            case 5:
                trackInput();
                break;
            default:
                break;
        }
         
    }

    private void trackColumnOfInput()
    {
        //Debug.Log(GameScreen.mouseX); 
        rgdBody2D.velocity = getHorizontalDirection() * GameScreen.columnSpace * 10;
    }

    private Vector2 getHorizontalDirection()
    {
        if (getPosition().x > GameScreen.leftMostColumnX && GameScreen.mouseX < getPosition().x) 
            return Vector2.left; 
        else if (getPosition().x < GameScreen.rightMostColumnX && GameScreen.mouseX > getPosition().x) 
            return Vector2.right; 
        else
            return Vector2.zero;
    }

    private void trackCellOfInput()
    {
        trackColumnOfInput();
        trackRowOfInput();
    }

    private void trackRowOfInput()
    {
        if (getPosition().y > GameScreen.lowestRowY && getPosition().y < GameScreen.highestRowY)
            rgdBody2D.MovePosition(rgdBody2D.position + (getVerticalDirection() * GameScreen.rowSpace));
    }

    private Vector2 getVerticalDirection()
    {
        return GameScreen.mouseX < getPosition().x ? Vector2.left : Vector2.right;
    }

    private void trackInputXOnRows()
    {
        trackRowOfInput();
        trackInputX();
    }

    private void trackInputX()
    {
        rgdBody2D.velocity = getHorizontalDirection() * 2;
    }

    private void trackInput()
    {
        trackInputX();
        rgdBody2D.velocity = rgdBody2D.velocity + getVerticalDirection() * 2;
    }
    private Vector2 getPosition()
    {
        return rgdBody2D.position;
    }

    private void stop()
    {
        switch (GameLogic.level)
        {
            case 1:
                GameLogic.stopScrolling();
                break;
            case 2:
                slideNearestColumn();
                break;
            case 3:
                slideNearestRaw();
                break;
            case 4:
                slideNearestRaw();
                break;
            case 5:
                rgdBody2D.velocity = Vector2.zero;
                break;
            default:
                break;
        }
    }

    private void slideNearestColumn()
    {
        if (GameScreen.isCharacterOnColumn())
            rgdBody2D.velocity = new Vector2(0, rgdBody2D.velocity.y);
    }
    private void slideNearestRaw()
    {
        if (GameScreen.isCharacterOnRow())
            rgdBody2D.velocity = new Vector2(rgdBody2D.velocity.y, 0);
    }

    private bool isTapUp()
    {
        return Input.GetMouseButtonUp(0);
    }
}
