using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : Singleton<WaveManager> {

	protected WaveManager(){}

	[Header("Maximum number of allowed Waves at time")]
	[Range(1,30)]
	public static int MAXIMUM_WAVES=6;

	private LinkedList<GameObject> waves_in_play;

	public GameObject m_wave_prefab;

	void Start(){
		ObjectPoolingManager.Instance.CreatePool (m_wave_prefab, 10, 10);
		waves_in_play = new LinkedList<GameObject> ();

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
		UpdateLinkedList (wave);

	}



	private void UpdateLinkedList(GameObject wave){
		waves_in_play.AddFirst (wave);
		if(waves_in_play.Count >= MAXIMUM_WAVES){
			waves_in_play.Last.Value.gameObject.SetActive (false);
			waves_in_play.RemoveLast ();
		}


	}







}
