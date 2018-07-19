using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialControl : MonoBehaviour {

    public void PlayButtonClick()
    {
        SceneManager.LoadScene(3);
    }
}
