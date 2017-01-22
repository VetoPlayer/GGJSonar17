using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKicker : MonoBehaviour {

	public float kickForce;


	// Use this for initialization
	void Start () {
        StartCoroutine(LateStart());
	}

    private IEnumerator LateStart()
    {
        yield return new WaitForSeconds(0.1f);

        this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, kickForce), ForceMode2D.Force);
    }
}
