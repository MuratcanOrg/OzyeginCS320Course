using UnityEngine;
using System.Collections;

public class obstacle : MonoBehaviour {
	public float speed = 3f;
	private Vector2 velocity;
    private Rigidbody2D rgdBody2D;

	void Start () {
        speed = 3;
        rgdBody2D = GetComponent<Rigidbody2D>();
		if (getPosition ().x < GameScreen.centralX) 
			velocity = Vector2.right * (speed); 
		else
			velocity = Vector2.left * (speed);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector2 v = (GameLogic.isScrolling ? GameLogic.scrollingVelocity : Vector2.zero);
        rgdBody2D.velocity = velocity + v;
		if (isObjectDead ()) {
			Destroy (gameObject);
        GameLogic.scored(10);
		}
        if (isHit())
        {
            //GameLogic.GameOver();
        }
	}

	private bool isObjectDead () {
		return getPosition ().x < GameScreen.minX || getPosition ().x > GameScreen.maxX;
	}

	private Vector2 getPosition () {
		return gameObject.transform.position;
	}

    private bool isHit()
    {
        return Vector2.Distance(getPosition(), getCharacterPosition() )< 1f;
    }
    //int a = 0;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Character")
        {
           // Debug.Log(a++);
           GameLogic.GameOver();
        }
    }

    private Vector2 getCharacterPosition()
    {
      return  FindObjectOfType<Character>().transform.position;
    }
    
}
