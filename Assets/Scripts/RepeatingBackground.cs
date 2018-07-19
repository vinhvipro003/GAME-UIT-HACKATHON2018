using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {
    private BoxCollider2D groundCollider;
    private float groundVerticalLength;
    private GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        groundCollider = GetComponent<BoxCollider2D>();
        groundVerticalLength = 91.5f;
	}
	
	// Update is called once per frame
	void Update () {
        if (player.transform.position.y > transform.position.y + groundVerticalLength)
        {
            repositionBackground();
        }
	}

    private void repositionBackground()
    {
        Vector2 groundOffset = new Vector2(0, groundVerticalLength* 2);
        transform.position = (Vector2)transform.position + groundOffset;
    }
}
