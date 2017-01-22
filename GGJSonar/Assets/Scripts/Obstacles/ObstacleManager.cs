using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

public class ObstacleManager : MonoBehaviour {

    public GameObject currentEnemy;
    public GameObject enemyPrefab;

    public Sprite[] enemySprites;

    public float distanceBetweenEnemies = 10f;

    public float xMin, xMax;
    public float yMin, yMax;

    public void SpawnNewEnemy()
    {
        Destroy(currentEnemy);
        Vector3 pos = GetEnemyPosition();
        currentEnemy = Instantiate(enemyPrefab, pos, Quaternion.identity, this.transform);
        currentEnemy.GetComponent<Mover>().enabled = true;
        currentEnemy.GetComponent<SpriteRenderer>().sprite = enemySprites[Random.Range(0, enemySprites.Length)];
    }

    private Vector3 GetEnemyPosition()
    {
        float w = Screen.width;
        float h = Screen.height;

        Vector3 pixelEnemyCoords = new Vector3(0f, Random.Range(yMin * h, yMax * h), 0f);
        Vector3 worldEnemyCoords = Camera.main.ScreenToWorldPoint(pixelEnemyCoords);
        worldEnemyCoords.x = distanceBetweenEnemies + Random.Range(xMin, xMax);
        worldEnemyCoords.z = 0f;

        return worldEnemyCoords;
    }
}
