using UnityEngine;
using System.Collections;

public class GameScreen : MonoBehaviour {
    public Camera mainCamera;
	public static float minimumXOfScreen = 0f; 
	public static float maximumXOfScreen = 6f; 
	public static float minimumYOfScreen = 0f; 
	public static float maximumYOfScreen = 10f; 
	public static float groundZ = 0f; 
	
	private static float creationSpace = 1f; 
	
	public static float minX = minimumXOfScreen - creationSpace; 
	public static float maxX = maximumXOfScreen + creationSpace; 
	public static float minY = minimumYOfScreen - creationSpace; 
	public static float maxY = maximumYOfScreen + creationSpace; 
	
	public static float centralX = minimumXOfScreen + (maximumXOfScreen - minimumXOfScreen) / 2f; 
	public static float centralY = minimumYOfScreen + (maximumYOfScreen - minimumYOfScreen) / 2f;
    public float mouseX;
    public float mouseY;
     
    void FixedUpdate()
    {
        mouseX = mainCamera.ScreenToWorldPoint(Input.mousePosition).x - GameScreen.centralX;
        mouseY = mainCamera.ScreenToWorldPoint(Input.mousePosition).z - GameScreen.centralY;
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
	
	public static Vector3 getPositionOfCharacter () {
		return FindObjectOfType <Character>().transform.position;
	}
}
