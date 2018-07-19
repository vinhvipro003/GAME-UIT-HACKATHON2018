using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour {

    private static GM instance;
    public static GM Instance { get { return instance; } }

    public double point = 0;
    public int coinCollected = 0;
    public bool isGameOver = false;
    public int highScore = 0;
    public GameObject HealthPanel;

    private void Start()
    {
        instance = this;
        if (PlayerPrefs.HasKey("highScore"))
        {
            highScore = PlayerPrefs.GetInt("highScore");
        }
        if (PlayerPrefs.HasKey("coin"))
        {
            coinCollected = PlayerPrefs.GetInt("coin");
        }
        StartGame();
    }


    public void StartGame()
    {
        point = 0;
        coinCollected = 0;
        PlayerController.health = 3;
        isGameOver = false;
    }

    public void GameOver()
    {
        //Set Gameover
        isGameOver = true;
        //Set Deactive Player
        PlayerController.player.gameObject.SetActive(false);
        //Show Game over menu
        SceneManager.LoadScene(2);
        if((int)point > highScore)
        {
            PlayerPrefs.SetInt("highScore", (int)point);
            highScore = (int)point;
            
        }
        PlayerPrefs.SetInt("coin", coinCollected);
        PlayerPrefs.SetInt("PreScore", (int)point);
    }

}
