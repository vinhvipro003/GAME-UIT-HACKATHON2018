using UnityEngine;
using System.Collections;

public class Icon : MonoBehaviour
{

    public Texture2D icon;
    public int x, y, w, h;

    void OnGUI()
    {
        if (GUI.Button(new Rect(x, y, w, h), icon))
        {
            print("you clicked the icon");
        }

        /*if (GUI.Button(new Rect(10, 70, 100, 20), "This is text"))
        {
            print("you clicked the text button");
        }*/
    }

}