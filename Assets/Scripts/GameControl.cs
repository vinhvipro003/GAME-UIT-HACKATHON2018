﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameControl : MonoBehaviour {

    public static GameControl instance;
    public GameObject gameOverText;
    public Text scoreText;
    public bool gameOver = false;
    public float scrollSpeed = 50f;
    private int score = 0;

	// Use this for initialization
	void Awake () {
	    if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (gameOver && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
		
	}

    public void BirdScored()
    {
        if (gameOver)
        {
            return;
        }
        score++;
        scoreText.text = "Score: " + score.ToString();

    }

    public void MainDie()
    {
        //gameOverText.SetActive(true);
        gameOver = true;
    }
}
