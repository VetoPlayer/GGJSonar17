using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager> {

	protected InputManager(){}

	private static int MAX_NUM_TOUCHES=1;

	// Update is called once per frame
	void Update () {
		if (Input.touches.Length == MAX_NUM_TOUCHES) {
			GlobalWavesManager.Instance.SpawnWave(Input.GetTouch(0));
		}
	
	}
		
}
