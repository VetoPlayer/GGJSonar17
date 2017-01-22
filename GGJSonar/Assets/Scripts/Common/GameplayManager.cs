using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : Singleton<GameplayManager> {

	protected GameplayManager(){}

	public float tutoredGameplayTime= 15f;

	private int player_points=0;

	private GameState currentState = GameState.START;

	void Start(){
		StartCoroutine(TutoredGameplayTimer(tutoredGameplayTime));
		StartCoroutine(TrackPoints());
	}


	IEnumerator TrackPoints(){
		yield return new WaitForSeconds(5f);
		player_points = player_points + 200;
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

	public int getPoints (){
		return player_points;
	}

	

}
