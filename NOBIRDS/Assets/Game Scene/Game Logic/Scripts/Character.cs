using UnityEngine;
using System.Collections;
using System;

public class Character : MonoBehaviour {
    private Vector3 firstScale = new Vector3(0.07948507f, 0.1149426f, 1); 
    private float currentColumn;
    private float currentRow;
    private Vector2 direction;
    private Vector2 size;
    public Rigidbody2D rgdBody2D; 

    void Start () {
        rgdBody2D = GetComponent<Rigidbody2D>();
        size = ((BoxCollider2D)GetComponent<BoxCollider2D>()).size;
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
        rgdBody2D.velocity = direction * 6;
        //Debug.Log(direction); 
        if (isTapDown()) 
            move(); 
        else 
            stop(); 
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
                //trackColumnOfInput();
                isOnColumn();
                setHorizontalDirection();
                break;
            case 3:
                //trackCellOfInput();
                trackInput();
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
        if (isOnColumn()) {Debug.Log(currentColumn);
            setHorizontalDirection(); }
        
    }

    private void setHorizontalDirection()
    {
        
        if (currentColumn > 0 && GameScreen.mouseX < getLeftBorderX())  
            direction.x = Vector2.left.x;
        else if (currentColumn < GameScreen.columnNumber-1 && GameScreen.mouseX > getRightBorderX())
            direction.x = Vector2.right.x; 
        else
            direction.x = Vector2.zero.x;
    }

    private float getLeftBorderX()
    {
        return rgdBody2D.position.x - 3 * size.x / 2;
    }

    private float getRightBorderX()
    {
        return rgdBody2D.position.x + 3 * size.x / 2;
    }

    private void trackCellOfInput()
    {
        trackColumnOfInput();
        trackRowOfInput();
    }

    private void trackRowOfInput()
    {
        if (isOnRow())
            setVerticalDirection();
    }

    private void setVerticalDirection()
    {
        if (currentRow > 0 && GameScreen.mouseY < getLowerBorderY())
            direction.y = Vector2.down.y;
        else if (currentRow < GameScreen.rowNumber - 2 && GameScreen.mouseY > getUpperBorderY())
            direction.y = Vector2.up.y;
        else
            direction.y = Vector2.zero.y;
    }

    private float getUpperBorderY()
    {
        return rgdBody2D.position.y + 3 * size.y / 2;
    }

    private float getLowerBorderY()
    {
        return rgdBody2D.position.y - 3 * size.y / 2;
    }

    private void trackInputXOnRows()
    {
        isOnColumn();
        setHorizontalDirection();
        trackRowOfInput();
    } 

    private void trackInput()
    {
        isOnColumn();
        isOnRow();
        setHorizontalDirection();
        setVerticalDirection();
    }

    private Vector2 getPosition()
    {
        return rgdBody2D.position;
    }

    private void stop()
    {
        GameLogic.startScrolling();

        switch (GameLogic.level)
        {
            case 1:
                GameLogic.startScrolling();
                break;
            case 2:
                //slideNearestColumn();
                direction.x = Vector2.zero.x;
                    break;
            case 3:
                //slideNearestColumn();
                direction = Vector2.zero;
                //lideNearestRow();
                break;
            case 4:
                //direction.x = Vector2.zero.x;
                slideNearestRow();
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
            direction.x = Vector2.zero.x;
    }

    public bool isOnColumn()
    {
        currentColumn =((rgdBody2D.position.x - GameScreen.columnBound / 2) / GameScreen.columnSpace);
        return Mathf.Abs(currentColumn - Mathf.Round(currentColumn)) < 0.01f;
        
        //for (float x = GameScreen.leftMostColumnX; x <= GameScreen.rightMostColumnX; x += GameScreen.columnSpace)
        //{
        //    float catchScale = size.x / 5f;
        //    Debug.Log(Mathf.Abs(x - getPosition().x));
        //    if (Mathf.Abs(x - getPosition().x) < 0.05f)
        //    {
                
        //        return true;
        //    }
       // }
        //return false;
    }

    private void slideNearestRow()
    {
        if (isOnRow())
            direction.y = Vector2.zero.y;
    }

    public bool isOnRow()
    {
        for (float y = GameScreen.lowestRowY; y <= GameScreen.highestRowY; y += GameScreen.rowSpace)
        {
            float catchScale = size.y / 3;
            if (Mathf.Abs(y - getPosition().y) < catchScale)
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
