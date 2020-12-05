using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndManager : MonoBehaviour
{
    bool MouseDown = false;
    void Start()
    {
        GameObject.Find("GameUI").transform.GetChild(1).gameObject.SetActive(false);
        GameObject.Find("GameUI").transform.GetChild(2).gameObject.SetActive(true);
    }

    void Update()
    {
        if (Input.touchCount >= 1 || Input.GetMouseButtonDown(0) || MouseDown)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
