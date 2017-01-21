﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalWavesManager : Singleton<GlobalWavesManager> {

	protected GlobalWavesManager(){}

    [Header("Maximum number of allowed Waves at time")]
    [Range(1, 6)]
    public static readonly int maxArcGenerators = 6;

    [Header("Prefabs")]
	public GameObject wavePrefab;
    public GameObject arcPrefab;

    private LinkedList<GameObject> wavesInPlay;

    public bool arePoolsReady = false;

    void Awake()
    {
        ObjectPoolingManager.Instance.CreatePool(wavePrefab, maxArcGenerators, maxArcGenerators);
        ObjectPoolingManager.Instance.CreatePool(arcPrefab, GlobalWavesManager.maxArcGenerators * WaveManager.maxArcsPerWave,
            GlobalWavesManager.maxArcGenerators * WaveManager.maxArcsPerWave);

        arePoolsReady = true;
    }

    void Start()
    {
        wavesInPlay = new LinkedList<GameObject>();
    }

    public void SpawnWave(Touch newTouch) {
		if (newTouch.phase == TouchPhase.Began) {
			Vector3 touchPosition = Camera.main.ScreenToWorldPoint (newTouch.position);
			SpawnWaveAtPosition(new Vector3(touchPosition.x,touchPosition.y,0));
		}
	}

    private void SpawnWaveAtPosition(Vector3 touchPosition)
    {
        GameObject wave = ObjectPoolingManager.Instance.GetObject(wavePrefab.name);
        ResetWave(touchPosition, wave);
        UpdateLinkedList(wave);
    }

    private static void ResetWave(Vector3 touchPosition, GameObject wave)
    {
        wave.SetActive(false);
        wave.transform.position = touchPosition;
        wave.transform.rotation = Quaternion.identity;
        wave.SetActive(true);
    }

    private void UpdateLinkedList(GameObject wave){
		wavesInPlay.AddFirst (wave);
		if(wavesInPlay.Count >= maxArcGenerators){
			wavesInPlay.Last.Value.gameObject.SetActive (false);
			wavesInPlay.RemoveLast();
		}
	}
}
