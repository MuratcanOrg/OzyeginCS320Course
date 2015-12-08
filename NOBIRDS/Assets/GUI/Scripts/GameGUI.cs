using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameGUI : MonoBehaviour { 
    public Text pauseButonText;
    public Text muteButonText;
    public Text scoreText;
    public Text highScoreNameText;
    public Text[] rankings = new Text[5];
    public RectTransform MAIN_MENU_PANEL;
    public RectTransform HOWTOPLAY_PANEL;
    public RectTransform HIGHSCORES_PANEL; 
    public RectTransform ABOUT_US_PANEL;
    public RectTransform GAME_OVER_PANEL;
    private RectTransform CURRENT_PANEL;
    private float jumpingLength;
    // Use this for initialization
    void Start ()
    {
        if (GameLogic.getCurrentScene() == "GUI")
        {
            jumpingLength = GameScreen.getSolutionHeight() * 4;
            CURRENT_PANEL = MAIN_MENU_PANEL; 
            setCurrentPanel(GameLogic.gameOver ? GAME_OVER_PANEL : MAIN_MENU_PANEL);
            GAME_OVER_PANEL.transform.Translate(Vector3.down * jumpingLength);
            HOWTOPLAY_PANEL.transform.Translate(Vector3.down * jumpingLength);
            HIGHSCORES_PANEL.transform.Translate(Vector3.down * jumpingLength);
            ABOUT_US_PANEL.transform.Translate(Vector3.down * jumpingLength); 
        }
        
    }

    private void showPanel( RectTransform panel)
    {
        panel.transform.Translate(Vector3.up * jumpingLength);
    }

    // Update is called once per frame
    void Update()
    {

    }

    
    public void showMainMenu()
    { 
        setCurrentPanel(MAIN_MENU_PANEL);
    }
	
	public void setCurrentPanel(RectTransform panel) {
        CURRENT_PANEL.transform.Translate(Vector3.down * jumpingLength);
        CURRENT_PANEL = panel;
        showPanel(CURRENT_PANEL);
	}
    
    public void showGameOver()
    { 
        setCurrentPanel(GAME_OVER_PANEL);
    }

    public void showHowToPlay()
    { 
        setCurrentPanel(HOWTOPLAY_PANEL);
    }
	
	public void showHighScores() {
        showHighScorePlayers();
        setCurrentPanel(HIGHSCORES_PANEL);
    }

    private void showHighScorePlayers()
    {
        string[] playerTexts = DataManager.getPlayerTexts();
        for (int ranking = 0; ranking < rankings.Length; ranking++)
        {
            playerTexts[ranking] = playerTexts[ranking] == null ? "" : playerTexts[ranking];
            rankings[ranking].text = playerTexts[ranking]; 
        }
        try
        {

        }
        catch (ArgumentOutOfRangeException)
        {
            Debug.Log("of");
            throw;
        }
    } 

    public void showAboutUs() {
        setCurrentPanel(ABOUT_US_PANEL);
    }
	
}
