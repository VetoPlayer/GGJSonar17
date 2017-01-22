using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : Singleton<GameplayManager> {

	protected GameplayManager(){}

	public float tutoredGameplayTime= 15f;

	private GameState currentState = GameState.START;

	void Start(){
		StartCoroutine(TutoredGameplayTimer(tutoredGameplayTime));
	}

	IEnumerator TutoredGameplayTimer(float time){
		yield return new WaitForSeconds (time);
		NextState (GameState.RANDOM);
		ObstacleManager.Instance.SpawnNewEnemy ();
		Debug.Log ("PassedToTheNextState");
	}



	public void NextState(GameState state){
		currentState = state;
	
	}


	public GameState getGameState(){
		return currentState;
	}

	public void GameOver(){
        SceneManager.LoadScene ("GameOver");
	}



	

}
