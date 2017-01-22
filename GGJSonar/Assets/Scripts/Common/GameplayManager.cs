using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : Singleton<GameplayManager> {

	protected GameplayManager(){}

	public float tutoredGameplayTime= 15f;

	private int player_points=0;

    public int pointsSpeed = 100;

	private GameState currentState = GameState.START;

    public bool canUpdateScore = true;

	void Start(){
		StartCoroutine(TutoredGameplayTimer(tutoredGameplayTime));
        player_points = 0;
	}


	void Update()
    {
        if(canUpdateScore)
            player_points += (int)(pointsSpeed * Time.deltaTime);
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

        MusicManagerXXX.Instance.PlayGameOver();
        SceneManager.LoadScene ("GameOver");
	}

	public int getPoints (){
		return player_points;
	}

	

}
