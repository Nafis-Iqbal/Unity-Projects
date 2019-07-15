using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {

    public Text highscoreText;

    void Start()
    {
        if (!PlayerPrefs.HasKey("Score"))
        {
            PlayerPrefs.SetInt("Score", 0);
        }
        else
        {
            int Hscore = PlayerPrefs.GetInt("Score");
            highscoreText.text = Hscore.ToString();
        }
    }

    void Update()
    {
        int highScore = PlayerPrefs.GetInt("Score");
        if (GameplayController.score > highScore)
        {
            PlayerPrefs.SetInt("Score", highScore);
            highscoreText.text = GameplayController.score.ToString();
        }    
    }

    public void PlayGame() {
		Application.LoadLevel ("Gameplay");
	}

}
