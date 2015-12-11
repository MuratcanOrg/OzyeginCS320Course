using UnityEngine;
using System.Collections; 

public class ObstacleCreator : ObjectCreator {

    public static ArrayList fromLeft = new ArrayList();
    public static ArrayList fromRight = new ArrayList();
    

    protected void FixedUpdate () { 
		base.FixedUpdate ();
	}

	protected override void createObject () {
        Vector2 vec2fromLeft = GameScreen.getRandomVec3FromLeft();
        Vector2 vec2fromRight = GameScreen.getRandomVec3FromRight();

        for (int i = 0; i < fromLeft.Count; i++)
        {

            GameObject objectRight = ((GameObject)fromRight[i]);
            if(objectRight != null)
            {
                float objectvec = (objectRight).transform.position.y;
                while (objectvec <= vec2fromLeft.y + 4 && objectvec >= vec2fromLeft.y - 4)
                {
                    vec2fromLeft = GameScreen.getRandomVec3FromLeft();
                }
            }
            GameObject objectLeft = ((GameObject)fromLeft[i]);
            if (objectLeft != null)
            {
                float objectvec2 = (objectLeft).transform.position.y;
                while (objectvec2 <= vec2fromRight.y + 4 && objectvec2 >= vec2fromRight.y - 4)
                {
                    vec2fromRight = GameScreen.getRandomVec3FromRight();
                }
            }
        }
        GameObject obstacleFromLeft = (GameObject)Instantiate(obstacles[0],vec2fromLeft, Quaternion.identity); 
		GameObject obstacleFromRight = (GameObject)Instantiate(obstacles[0], vec2fromRight, Quaternion.identity);
        fromLeft.Add(obstacleFromLeft);
        fromRight.Add(obstacleFromRight);
    }
}
