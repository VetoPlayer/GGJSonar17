using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {

    public float playerSpeed = 5f;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(playerSpeed, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
