using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour {

	public float rotationSpeed;

    private GameObject obstacleManager;

	// Use this for initialization
	void Start () {
        obstacleManager = GameObject.FindGameObjectWithTag("ObstacleManager");
    }

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			GameplayManager.Instance.GameOver ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (0f,0f,rotationSpeed * Time.deltaTime));
	}

    void OnBecameInvisible()
    {
        obstacleManager.GetComponent<ObstacleManager>().SpawnNewEnemy();
    }
}
