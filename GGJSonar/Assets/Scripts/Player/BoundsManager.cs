using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsManager : MonoBehaviour {

    public float minY = 0.2f;
    public float maxY = 0.8f;

/*    // Update is called once per frame
    void OnBecameInvisible() { 
        GameplayManager.Instance.GameOver();
    }*/

    void Update()
    {
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);

        if( viewportPosition.y >= 0.95f || viewportPosition.y <= -0.1f )
        {
            GameplayManager.Instance.GameOver();
        }
    }
}
