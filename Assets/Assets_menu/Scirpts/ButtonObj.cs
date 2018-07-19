using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonObj : MonoBehaviour
{

    public GameObject btn1;
    public GameObject btn2;
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
            btn1.SetActive(true);
            btn2.SetActive(true);
        }
    }
}
