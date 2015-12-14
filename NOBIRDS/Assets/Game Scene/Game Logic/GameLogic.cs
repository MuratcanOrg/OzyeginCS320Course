using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class GameLogic : MonoBehaviour
{
    public static bool pause = false;
    public static bool mute = false;
    public static bool gameOver = false;
    public static bool isScrolling = true;
    public static int score = 0;
    public static int level = 3;
    public static float hardnessRate = 1f;
    public static float scrollingSpeed = 3f;
    private static float fixedScrollingSpeed = scrollingSpeed;
    public static Vector2 scrollingVelocity;

    public static string getCurrentScene()
    {
        return Application.loadedLevel == 0 ? "GUI" : "Game Scene";
    }
 
    void Start () {
        Time.timeScale = 1;
        Physics2D.gravity =  Vector2.zero;
        scrollingVelocity = Vector3.down * (scrollingSpeed);
	}
     
    void FixedUpdate () {
        hardnessRate = 1f + (score / 1500f);
        //level = score / 500;
        if (score >= 10000)
            GameOver(); 
    }

    public static void setPaused(bool paused)
    {
        pause = paused;
        Time.timeScale = pause ? 0 : 1;
    }

    public static void setMuted(bool muted)
    {
        mute = !muted;
    }
     
    public static void startGame()
    {
        gameOver = false;
        score = 0;
        Time.timeScale = 1;
        Application.LoadLevel("Game Scene");
    }

    public static void GameOver()
    {
        gameOver = true;
        Application.LoadLevel("GUI");
    }

    public static void scored(int point)
    {
        score += point;
    }

    public static void recordHighScore(string playerName)
    { 
        DataManager.recordPlayer(score, playerName); 
    }

    public static void startScrolling()
    {
        isScrolling = true;
    }

    public static void stopScrolling()
    {
        isScrolling = false;
    }

    public static void bonusToken()
    {
        isScrolling = false;
    }
}
