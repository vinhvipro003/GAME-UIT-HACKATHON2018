using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private Rigidbody rb;
    private GameObject player;
    private Vector2 offset;
    // Use this for initialization
    void Start () { 
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        offset = this.transform.position - player.transform.position;
        
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (!GM.Instance.isGameOver)
            this.transform.position = new Vector3(0, player.transform.position.y + offset.y, -30);
        else
            rb.velocity = new Vector3(0, 2);
    }


}
