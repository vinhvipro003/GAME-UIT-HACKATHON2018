using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{

    UnityEngine.UI.Text highscoreText;
    UnityEngine.UI.Text curScoreText;

    private void Start()
    {
        curScoreText = gameObject.transform.GetChild(3).gameObject.GetComponent<UnityEngine.UI.Text>();
        highscoreText = gameObject.transform.GetChild(4).gameObject.GetComponent<UnityEngine.UI.Text>();

        curScoreText.text = PlayerPrefs.GetInt("PreScore").ToString();
        highscoreText.text = PlayerPrefs.GetInt("highScore").ToString();
    }


    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
