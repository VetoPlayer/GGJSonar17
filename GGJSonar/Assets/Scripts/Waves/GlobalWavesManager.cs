using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalWavesManager : Singleton<GlobalWavesManager> {

	protected GlobalWavesManager(){}


	[Header("Container")]
	public GameObject container;


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
		SfxManager.Instance.Play ("sfx_wave_gen");
		if (newTouch.phase == TouchPhase.Began) {
            DisablePreviousWaveGeneration();

			Vector3 touchPosition = Camera.main.ScreenToWorldPoint (newTouch.position);
			SpawnWaveAtPosition(new Vector3(touchPosition.x,touchPosition.y,0));
		} else if ( newTouch.phase == TouchPhase.Ended )
        {
            DisableCurrentWaveGeneration();
        }
	}

    private void DisableCurrentWaveGeneration()
    {
        if (wavesInPlay.Count == 0)
            return;

        wavesInPlay.First.Value.GetComponent<WaveManager>().SetCanGenerate(false);
    }

    private void DisablePreviousWaveGeneration()
    {
        // first wave ever!
        if (wavesInPlay.Count == 0)
            return;

        LinkedListNode<GameObject> current = wavesInPlay.First;
        while (current.Next != null && current.Next.Value.GetComponent<WaveManager>().GetCanGenerateArcs() == true)
            continue;

        current.Value.GetComponent<WaveManager>().SetCanGenerate(false);
    }

    private void SpawnWaveAtPosition(Vector3 touchPosition)
    {
        GameObject wave = ObjectPoolingManager.Instance.GetObject(wavePrefab.name);
        ResetWave(touchPosition, wave);
        UpdateLinkedList(wave);
    }

    private void ResetWave(Vector3 touchPosition, GameObject wave)
    {
        wave.SetActive(false);
        wave.transform.position = touchPosition;
        wave.transform.rotation = Quaternion.identity;
		wave.transform.parent = container.transform;
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
