using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsDisplayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int points =GameplayManager.Instance.getPoints ();
		GetComponent<Text>().text = "" + points + "";
	}

}
