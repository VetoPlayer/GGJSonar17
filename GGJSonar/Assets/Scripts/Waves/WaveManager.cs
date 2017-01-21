using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : Singleton<WaveManager> {

	protected WaveManager(){}

	public GameObject wave_prefab;

	void Start(){
		ObjectPoolingManager.Instance.CreatePool (wave_prefab, 10, 10);

	}


	public void SpawnWave(Touch newTouch) {
		if (newTouch.phase == TouchPhase.Began || newTouch.phase == TouchPhase.Stationary) {
			Debug.Log("A new touch has been detected");
		}

	}
}
