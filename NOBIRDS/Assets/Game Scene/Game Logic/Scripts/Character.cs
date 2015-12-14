using UnityEngine;
using System.Collections;
using System;

public class Character : MonoBehaviour {
    private Vector3 firstScale = new Vector3(1, 1, 1); 
    private int currentColumn;
    private int currentRow; 
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
        if (isOnColumn()) 
            rgdBody2D.velocity = getHorizontalDirection(); 
        
    }

    private Vector2 getHorizontalDirection()
    {
        if (currentColumn != 0 && GameScreen.mouseX < getLeftBorderX()) 
            return Vector2.left; 
        else if (currentColumn != GameScreen.columnNumber-1 && GameScreen.mouseX > getRightBorderX()) 
            return Vector2.right; 
        else
            return Vector2.zero;
    }

    private float getLeftBorderX()
    {
        return rgdBody2D.position.x - transform.localScale.x / 2 - 0.05f;
    }

    private float getRightBorderX()
    {
        return rgdBody2D.position.x + transform.localScale.x / 2 + 0.05f;
    }

    private void trackCellOfInput()
    {
        trackColumnOfInput();
        trackRowOfInput();
    }

    private void trackRowOfInput()
    {
        if (isOnColumn())
            rgdBody2D.velocity = getHorizontalDirection();
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
        if (isOnColumn())
            rgdBody2D.velocity = new Vector2(0, rgdBody2D.velocity.y);
    }

    public bool isOnColumn()
    {
        for (float x = GameScreen.leftMostColumnX; x <= GameScreen.rightMostColumnX; x += GameScreen.columnSpace)
        { 
            if (Mathf.Abs(x - getPosition().x) < 0.01f)
            {
                currentColumn = (int)((x - GameScreen.columnBound / 2) / GameScreen.columnSpace);
                return true;
            }
        }
        return false;
    }

    private void slideNearestRaw()
    {
        if (isOnRow())
            rgdBody2D.velocity = new Vector2(rgdBody2D.velocity.y, 0);
    }
    public bool isOnRow()
    {
        for (float y = GameScreen.lowestRowY; y <= GameScreen.highestRowY; y += GameScreen.rowSpace)
        {
            if (Mathf.Abs(y - getPosition().y) < 0.01f)
            {
                currentRow = (int)((y - GameScreen.rowBound / 2) / GameScreen.rowSpace);
                return true;
            }
        }
        return false;
    }


    private bool isTapUp()
    {
        return Input.GetMouseButtonUp(0);
    }
}
