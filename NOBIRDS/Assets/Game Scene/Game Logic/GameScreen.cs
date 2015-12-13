using UnityEngine;
using System.Collections;

public class GameScreen : MonoBehaviour {
    public Camera mainCamera;
    public static Vector3 screenVector;
	public static float minimumXOfScreen = 0f; 
	public static float maximumXOfScreen = 6f; 
	public static float minimumYOfScreen = 0f; 
	public static float maximumYOfScreen = 10f;
    public static float width = maximumXOfScreen - minimumXOfScreen;
    public static float height = maximumYOfScreen - minimumYOfScreen;
    public static float groundZ = 0f; 
	
	private static float creationSpace = 1f; 
	
	public static float minX = minimumXOfScreen - creationSpace; 
	public static float maxX = maximumXOfScreen + creationSpace; 
	public static float minY = minimumYOfScreen - creationSpace; 
	public static float maxY = maximumYOfScreen + creationSpace; 
	
	public static float centralX = width / 2f; 
	public static float centralY = height / 2f;
    public static float mouseX;
    public static float mouseY;

    public static int columnNumber = 3;
    public static float columnBound = 1f;
    public static float columnSpace = (width - columnBound) / (columnNumber - 1);
    public static float leftMostColumnX = minimumXOfScreen + columnBound / 2f;
    public static float rightMostColumnX = maximumXOfScreen - columnBound / 2f;

    public static int rowNumber = 4;
    public static float rowBound = 2f;
    public static float rowSpace = (height - rowBound) / (rowNumber - 1);
    public static float lowestRowY = minimumYOfScreen + rowBound / 2f; 
    public static float highestRowY = maximumYOfScreen - rowBound / 2f;

    void Start()
    {
        Debug.Log(leftMostColumnX);
        Debug.Log(rightMostColumnX);
        Debug.Log(columnSpace);
    }

    void FixedUpdate()
    {
        mouseX = mainCamera.ScreenToWorldPoint(Input.mousePosition).x;
        mouseY = mainCamera.ScreenToWorldPoint(Input.mousePosition).z;
        screenVector = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, -10));
        maximumXOfScreen = screenVector.x;
        maximumYOfScreen = screenVector.y;

    }

    public static float getSolutionWidth()
    {
        return 480;
    }

    public static float getSolutionHeight()
    {
        return 854;
    }

    public static float getWidth () { 
		return maxX - minX;
	}
	
	public static float getHeight () {
		return maxY - minY;
	}

	public static Vector3 getRandomVec3FromLeft () {
		return new Vector3 (minX, getRandomY (), groundZ); 
	}
	
	public static Vector3 getRandomVec3FromRight () {
		return new Vector3 (maxX, getRandomY (), groundZ); 
	}
	
	public static float getRandomX () {
		return Random.Range (minX, maxX);
	}
	
	public static float getRandomY () {
		return Random.Range (minY, maxY);
    }

    public static bool isCharacterOnColumn()
    {
        for (float x = leftMostColumnX; x <= rightMostColumnX; x += columnSpace)
        {
            Debug.Log(x);
            if (Mathf.Abs(x - getPositionOfCharacter().x) < 0.01f)
            {
                return true;
            }
        }
        return false;
    }

    public static bool isCharacterOnRow()
    {
        for (float y = lowestRowY; y <= highestRowY; y += rowSpace)
        {
            if (Mathf.Abs(y - getPositionOfCharacter().y) < 0.01f)
            {
                return true;
            }
        }
        return false;
    }

    public static Vector2 getPositionOfCharacter () {
		return FindObjectOfType <Character>().rgdBody2D.position;
	}
}
