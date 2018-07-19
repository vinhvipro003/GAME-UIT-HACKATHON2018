using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreText : MonoBehaviour {

    GM gm;
    private int score;
    private UnityEngine.UI.Text textObj;
	// Use this for initialization
	void Start () {
        score = 0;
        textObj = GetComponent<UnityEngine.UI.Text>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(GM.Instance.point - score >= 1)
        {
            score = Mathf.CeilToInt((float)GM.Instance.point);
            textObj.text = score.ToString();
        }

	}

}
