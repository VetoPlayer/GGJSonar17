using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : Singleton<WaveManager> {

	protected WaveManager(){}

	public GameObject m_wave_prefab;

	void Start(){
		ObjectPoolingManager.Instance.CreatePool (m_wave_prefab, 10, 10);

	}


	public void SpawnWave(Touch newTouch) {
		if (newTouch.phase == TouchPhase.Began) {
			Vector3 touchPosition = Camera.main.ScreenToWorldPoint (newTouch.position);
			SpawnWaveAtPosition(new Vector3(touchPosition.x,touchPosition.y,0));
		}

	}




	private void SpawnWaveAtPosition(Vector3 touchPosition){
		GameObject wave = ObjectPoolingManager.Instance.GetObject (m_wave_prefab.name);
		wave.transform.position = touchPosition;
		wave.transform.rotation = Quaternion.identity;

	}
}
