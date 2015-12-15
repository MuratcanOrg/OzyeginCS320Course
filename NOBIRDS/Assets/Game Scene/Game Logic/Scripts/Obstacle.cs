using UnityEngine;
using System.Collections;
using System;

public class Obstacle : MonoBehaviour { 
	public float speed = 3f;
	private Vector2 velocity;
    private Rigidbody2D rgdBody2D;

	void Start () {
        setSize();
        rgdBody2D = GetComponent<Rigidbody2D>();
        ignoreCollisionWithObstacles();
        setVelocity();
	}

    private void setSize()
    {
        gameObject.transform.localScale = gameObject.transform.localScale * GameLogic.hardnessRate;
    }

    private void ignoreCollisionWithObstacles()
    {
        Obstacle[] obstacles = FindObjectsOfType<Obstacle>();
        for (int i = 1; i < obstacles.Length;i++ )
        {
            Transform obstaclePrefab = obstacles[i].transform;
            BoxCollider2D otherCollider = obstaclePrefab.GetComponent<BoxCollider2D>();
            Physics2D.IgnoreCollision(otherCollider, GetComponent<BoxCollider2D>()); 
        } 
    }

    private void setVelocity()
    { 
        speed = 3;
        if (getPosition().x < GameScreen.centralX)
            velocity = Vector2.right * (speed); 
		else
			velocity = Vector2.left * (speed);
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        move();
		if (isObjectDead ()) {
            eraseItself();
        } 
	}
    
    private void move()
    {
        Vector2 v = (GameLogic.isScrolling ? GameLogic.scrollingVelocity : Vector2.zero);
        rgdBody2D.velocity = velocity + v; 
    }

	private bool isObjectDead () {
        return getPosition().x < GameScreen.minX || getPosition().x > GameScreen.maxX ||
            getPosition().y < GameScreen.minY;
	}
    void OnBecameInvisible()
    {
        eraseItself();
    }
    private void eraseItself()
    {
        GameLogic.scored(10); 
        Destroy(gameObject);
    }
    
	private Vector2 getPosition () {
		return gameObject.transform.position;
	}
    
    public void OnCollisionEnter2D(Collision2D collision)
    { 
        if (collision.gameObject.tag == "Character")
        {
           //GameLogic.GameOver();
        }
    }

    private Vector2 getCharacterPosition()
    {
      return  FindObjectOfType<Character>().transform.position;
    }
    
}
