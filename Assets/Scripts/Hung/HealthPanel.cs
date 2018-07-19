using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPanel : MonoBehaviour {

    private static GameObject[] hearths;

    private void Start()
    {
        hearths = new GameObject[3];
        for(int i = 0; i < 3; i++)
        {
            hearths[i] = gameObject.transform.GetChild(i).gameObject;
        }
    }

    public static void deleteHearth(int i)
    {
        hearths[i].transform.GetChild(1).gameObject.SetActive(true);
    }
    public static void addHearth(int i)
    {
        hearths[i].transform.GetChild(1).gameObject.SetActive(false);
    }
}
