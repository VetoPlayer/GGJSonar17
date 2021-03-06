﻿using System.Collections;
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

	public float yPosition;

    public void SpawnNewMushroom()
    {
        Destroy(currentMushroom);
        Vector3 pos = new Vector3(distanceBetweenMushrooms + Random.Range(minNoise, maxNoise), yPosition, 0f);
        currentMushroom = Instantiate(mushroomPrefab, pos, Quaternion.identity, this.transform);
        currentMushroom.GetComponent<Mover>().enabled = true;
        currentMushroom.GetComponent<SpriteRenderer>().sprite = mushroomSprites[Random.Range(0, mushroomSprites.Length)];
    }
}
