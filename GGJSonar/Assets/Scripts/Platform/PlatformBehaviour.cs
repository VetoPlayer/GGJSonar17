using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehaviour : MonoBehaviour {


	public float disappearSpeed;

	void Start () {
        StartCoroutine(LateStart());
	}

    private IEnumerator LateStart()
    {
        yield return new WaitForSeconds(2f);
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-disappearSpeed, 0f), ForceMode2D.Force);
    }

    void OnBecameInvisible()
	{
		this.gameObject.SetActive (false);
	}
}
