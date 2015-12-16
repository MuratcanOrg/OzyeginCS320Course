using UnityEngine;
using System.Collections; 

public class ObstacleCreator : ObjectCreator
{
    public GameObject[] obstacles;
    private int counter;
    protected void FixedUpdate () { 
		base.FixedUpdate ();
	}

	protected override void createObject () {
        Vector2 vec2fromLeft = GameScreen.getRandomVec3FromLeft();
        Vector2 vec2fromRight = GameScreen.getRandomVec3FromRight();
        Vector2 vec2fromUp = GameScreen.getRandomVec3FromUp();
        GameObject obstacleFromLeft = (GameObject)Instantiate(obstacles[0],vec2fromLeft, Quaternion.identity); 
		GameObject obstacleFromRight = (GameObject)Instantiate(obstacles[1], vec2fromRight, Quaternion.identity);
        if (GameLogic.score > 500 && counter > 10)
        { GameObject obstacleFromUp = (GameObject)Instantiate(obstacles[2], vec2fromUp, Quaternion.identity); }
        if (counter ++ > 10)
        {
            counter = 0;
        }
        Debug.Log(counter);
    }
}
