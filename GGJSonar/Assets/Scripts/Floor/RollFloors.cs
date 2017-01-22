using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollFloors : MonoBehaviour {

    private Vector3 initialPosition;
    public GameObject otherTile;
    public float floorLength = 49.102f;
    private float posY;

    void Start()
    {
        posY = transform.position.y;
    }

	void OnEnable()
    {
        initialPosition = transform.position;
    }

    void OnBecameInvisible()
    {
        transform.position = otherTile.transform.position + new Vector3(floorLength, 0f, 0f);
    }
}
