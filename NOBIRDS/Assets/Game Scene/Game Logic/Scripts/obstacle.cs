using UnityEngine;
using System.Collections;

public class obstacle : MonoBehaviour {
	public float speed = 3f;
	private Vector3 velocity; 
	// Use this for initialization
	void Start () { 
		speed = 3f;
		if (getPosition ().x < GameScreen.centralX) 
			velocity = Vector3.right * (speed) * Time.deltaTime; 
		else
			velocity = Vector3.left * (speed) * Time.deltaTime;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		gameObject.transform.Translate (velocity + GameLogic.scrollingVelocity);
		if (isObjectDead ()) {
			Destroy (gameObject);
        GameLogic.scored(10);
		}
	}

	private bool isObjectDead () {
		return Vector2.Distance (getPosition (), GameScreen.getPositionOfCharacter ()) < 0.1f || 
			getPosition ().x < GameScreen.minX || getPosition ().x > GameScreen.maxX;
	}

	private Vector3 getPosition () {
		return gameObject.transform.position;
	}
    
}
