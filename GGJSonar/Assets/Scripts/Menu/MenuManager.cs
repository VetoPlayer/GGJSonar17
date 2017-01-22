using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : Singleton<MenuManager> {

    public GameObject playBtn;
    public GameObject creditsBtn;

    protected MenuManager() { }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == playBtn.transform)
                    Debug.Log("OK");
            }
        }

    }
    /*if (Input.touchCount > 0)
    {
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // Create a particle if hit
            RaycastHit2D hit = Physics2D.Raycast(Input.GetTouch(0).position, Vector2.zero);

            Debug.Log(hit.collider);
        }
    }*/
}
