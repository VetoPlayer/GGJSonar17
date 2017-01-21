using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour {

	public Transform arcContainer;

    public GameObject arcPrefab;
    public Transform spawnPosition;
    public static readonly int maxArcsPerWave = 5;
    public float waitTimeBetweenArcs = 2f; 
	public float disableTime= 2f;

    private LinkedList<GameObject> generatedArcs;
    private bool canGenerateArcs = true;

    void OnEnable()
    {
        canGenerateArcs = true;
        generatedArcs = new LinkedList<GameObject>();
        StartCoroutine(GenerateArcs());
    }

    private IEnumerator GenerateArcs()
    {
        while (!GlobalWavesManager.Instance.arePoolsReady)
            yield return new WaitForSeconds(0.1f);

        while(canGenerateArcs)
        {
            CreateSingleArc();

            yield return new WaitForSeconds(waitTimeBetweenArcs);
        }
    }

    private void CreateSingleArc()
    {
        GameObject arc = ObjectPoolingManager.Instance.GetObject(arcPrefab.name);
        ResetArc(arc);
		StartCoroutine (DisableTimer(arc));

        UpdateLinkedList(arc);
    }


	IEnumerator DisableTimer(GameObject arc){
		yield return new WaitForSeconds (disableTime);
		arc.SetActive (false);
		generatedArcs.RemoveFirst ();

	}

    private void ResetArc(GameObject arc)
    {
		arc.SetActive (false);
		arc.transform.parent = arcContainer;
        arc.transform.position = spawnPosition.position;
        arc.transform.rotation = Quaternion.identity;
        arc.transform.localScale = Vector3.one;
		arc.SetActive (true);
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

    public bool GetCanGenerateArcs()
    {
        return canGenerateArcs;
    }

    public void SetCanGenerate(bool value)
    {
        canGenerateArcs = value;
    }

    private void OnDisable()
    {
        if (generatedArcs == null)
            return;

        foreach (var arc in generatedArcs)
        {
            arc.SetActive(false);
        }
    }

}
