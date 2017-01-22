using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuManager : Singleton<MenuManager> {

    protected MenuManager() { }

    void Update()
    {
        if( Input.touchCount == 1 )
        {
            var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero);

            if( hit.collider.CompareTag("PlayBtn") )
            {
                SceneManager.LoadScene("Main");
            } else if( hit.collider.CompareTag("OptionsBtn") )
            {
                Debug.Log("Options");
            } else
            {
                return;
            }
        }
    }
}
