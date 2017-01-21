using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcExpander : MonoBehaviour {

    public float expandSpeed = 1f;
    public float moveYSpeed = 1f;

	// Update is called once per frame
	void Update ()
    {
        Rescale();
        MoveArc();
    }

    private void MoveArc()
    {
        transform.position = 
            new Vector3(transform.position.x, transform.position.y + moveYSpeed * Time.deltaTime, transform.position.z);
    }

    private void Rescale()
    {
        Vector3 scale = transform.localScale;
        scale.x += expandSpeed * Time.deltaTime;
        scale.y += expandSpeed * Time.deltaTime;

        transform.localScale = scale;
    }
}
