using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour {

    public GameObject arcPrefab;
    public Transform spawnPosition;
    public static readonly int maxArcsPerWave = 5;
    public float waitTimeBetweenArcs = 2f; 

    private LinkedList<GameObject> generatedArcs;

    void Awake()
    {
        ObjectPoolingManager.Instance.CreatePool(arcPrefab, GlobalWavesManager.maxArcGenerators * maxArcsPerWave, GlobalWavesManager.maxArcGenerators * maxArcsPerWave);
    }

    // Use this for initialization
    void Start () {
        generatedArcs = new LinkedList<GameObject>();
        
        StartCoroutine(GenerateArcs());
	}

    private IEnumerator GenerateArcs()
    {
        while( true )
        {
            CreateSingleArc();

            yield return new WaitForSeconds(waitTimeBetweenArcs);
        }
    }

    private void CreateSingleArc()
    {
        GameObject arc = ObjectPoolingManager.Instance.GetObject(arcPrefab.name);
        arc.transform.position = spawnPosition.position;
        arc.transform.rotation = Quaternion.identity;
        //arc.transform.parent = gameObject.transform;

        UpdateLinkedList(arc);
    }

    private void UpdateLinkedList(GameObject arc)
    {
        generatedArcs.AddFirst(arc);
        if (generatedArcs.Count >= maxArcsPerWave)
        {
            generatedArcs.Last.Value.gameObject.SetActive(false);
            generatedArcs.RemoveLast();
        }
    }
}
