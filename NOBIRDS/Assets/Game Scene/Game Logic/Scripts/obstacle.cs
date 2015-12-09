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
        Vector3 v = (GameLogic.isScrolling ? GameLogic.scrollingVelocity : Vector3.zero);
        gameObject.transform.Translate (velocity + v);
		if (isObjectDead ()) {
			Destroy (gameObject);
        GameLogic.scored(10);
		}
        if (isHit())
        {
            GameLogic.GameOver();
        }
	}

	private bool isObjectDead () {
		return getPosition ().x < GameScreen.minX || getPosition ().x > GameScreen.maxX;
	}



	private Vector3 getPosition () {
		return gameObject.transform.position;
	}
    private bool isHit()
    {
        return Vector3.Distance(getPosition(), getCharacterPosition() )< 1f;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("aqaq");
        if (collision.collider.tag == "Character")
        {
            
            GameLogic.GameOver();
        }
    }
    private Vector3 getCharacterPosition()
    {
      return  FindObjectOfType<Character>().transform.position;
    }
    
}
