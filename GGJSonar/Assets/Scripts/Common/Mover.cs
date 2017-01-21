using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

	private Transform tr;

	[Header("Speed")]
	public float speed = 2.0f;

	// Use this for initialization
	void Awake () {
		tr = this.gameObject.GetComponent<Transform> ();

	}
	
	// Update is called once per frame
	void Update () {
		tr.position = tr.position + Vector3.left * Time.deltaTime * speed;
	}
}
