using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : Singleton<GameplayManager> {

	protected GameplayManager(){}

	public void GameOver(){
        Debug.Log("die!");
		//SceneManager.LoadScene ("GameOver");
	}
	

}
