using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomSpawner : Singleton<MushroomSpawner> {

	protected MushroomSpawner() {}


	[Header("Mushroom Data")]
	public GameObject mushroomPrefab;

	public Sprite [] mushroomSprites;

	public float distanceBetweenMushrooms = 10f;

	public float minNoise;

	public float maxNoise;

	public GameObject currentMushroom;


	// Use this for initialization
	void Awake () {
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 normalizedCoords = Camera.main.WorldToViewportPoint (currentMushroom.transform.position);
		if(normalizedCoords.x < 0) {
			Destroy(currentMushroom);
			Vector3 pos = new Vector3 (distanceBetweenMushrooms + Random.Range(minNoise,maxNoise), 0f,0f);
			currentMushroom = Instantiate(mushroomPrefab,pos,Quaternion.identity,this.transform);
			currentMushroom.GetComponent<Mover> ().enabled = true;
		}
				
	}
}
