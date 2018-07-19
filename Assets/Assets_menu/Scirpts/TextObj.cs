using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextObj : MonoBehaviour {

    public GameObject textObj;
    public GameObject slogan;
    float TmStart;
    public float TmLen;

    // Use this for initialization
    void Start()
    {
        TmStart = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > TmStart + TmLen)
        {
            slogan.SetActive(false);
            textObj.SetActive(true);
        }
    }
}
