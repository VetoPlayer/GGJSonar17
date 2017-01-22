using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsDisplayer : MonoBehaviour {

    private int points = 0;

    void Start()
    {
        points = GameplayManager.Instance.getPoints();
        GetComponent<Text>().text = "" + points + "";
    }


}
