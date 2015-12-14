using UnityEngine;
using System.Collections; 

public class ObstacleCreator : ObjectCreator
{
    public GameObject[] obstacles; 
    
    protected void FixedUpdate () { 
		base.FixedUpdate ();
	}

	protected override void createObject () {
        Vector2 vec2fromLeft = GameScreen.getRandomVec3FromLeft();
        Vector2 vec2fromRight = GameScreen.getRandomVec3FromRight(); 
        GameObject obstacleFromLeft = (GameObject)Instantiate(obstacles[0],vec2fromLeft, Quaternion.identity); 
		GameObject obstacleFromRight = (GameObject)Instantiate(obstacles[0], vec2fromRight, Quaternion.identity); 
    }
}
