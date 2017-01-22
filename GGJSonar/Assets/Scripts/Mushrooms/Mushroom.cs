using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour {

    public enum MushroomType
    {
        BACK = 0,
        FRONT = 1,
    };

    GameObject mushroomManager;
    public MushroomType type;

    void Start()
    {
        mushroomManager = GameObject.FindGameObjectWithTag("MushroomManager");
    }

	void OnBecameInvisible()
    {
        mushroomManager.GetComponents<MushroomSpawner>()[(int)type].SpawnNewMushroom();
    }
}
