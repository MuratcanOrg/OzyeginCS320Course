using UnityEngine;
using System.Collections; 

public class ObstacleCreator : ObjectCreator {

	protected void FixedUpdate () { 
		base.FixedUpdate ();
	}

	protected override void createObject () {
		GameObject obstacleFromLeft = (GameObject)Instantiate(obstacles[0], GameScreen.getRandomVec3FromLeft (), Quaternion.identity); 
		GameObject obstacleFromRight = (GameObject)Instantiate(obstacles[0], GameScreen.getRandomVec3FromRight (), Quaternion.identity); 
	}

}
