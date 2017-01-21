﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour {

    public GameObject arcPrefab;
    public Transform spawnPosition;
    public static readonly int maxArcsPerWave = 5;
    public float waitTimeBetweenArcs = 2f; 

    private LinkedList<GameObject> generatedArcs;

    void OnEnable()
    {
        generatedArcs = new LinkedList<GameObject>();
        StartCoroutine(GenerateArcs());
    }

    private IEnumerator GenerateArcs()
    {
        while (!GlobalWavesManager.Instance.arePoolsReady)
            yield return new WaitForSeconds(0.1f);

        while(true)
        {
            CreateSingleArc();

            yield return new WaitForSeconds(waitTimeBetweenArcs);
        }
    }

    private void CreateSingleArc()
    {
        GameObject arc = ObjectPoolingManager.Instance.GetObject(arcPrefab.name);
        ResetArc(arc);

        UpdateLinkedList(arc);
    }

    private void ResetArc(GameObject arc)
    {
        arc.transform.position = spawnPosition.position;
        arc.transform.rotation = Quaternion.identity;
        arc.transform.localScale = Vector3.one;
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

    private void OnDisable()
    {
        if (generatedArcs == null)
            return;

        foreach (var arc in generatedArcs)
        {
            arc.gameObject.SetActive(false);
        }
    }
}
