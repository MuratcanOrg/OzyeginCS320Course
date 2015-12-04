using UnityEngine;
using System.Collections;

public class GUIController : MonoBehaviour {
    private GameGUI view; 
	// Use this for initialization
	void Start () {
        view = gameObject.GetComponent<GameGUI>();  
    }
	
	// Update is called once per frame
	void Update ()
    {
      
    }

    public void playButtonClicked()
    {
		Application.LoadLevel("Game Scene");
    }

    public void hotToPlayButtonClicked()
    {
        view.showHowToPlay();
    }

    public void highScoresButtonClicked()
    {
        view.showHighScores();
    }

    public void aboutUsButtonClicked()
    {
        view.showAboutUs();
    }

    public void okButtonClicked()
    {
        view.showMainMenu();
    }

    public void pauseButtonClicked()
    {
        GameLogic.setPaused(!GameLogic.pause);
    }

    public void muteButtonClicked()
    {
        GameLogic.setMuted(!GameLogic.mute);
    }
     
    public void highScoreNameEntered() 
    {
        GameLogic.recordHighScore(view.highScoreNameText.text);
        view.showMainMenu();
    }

}
