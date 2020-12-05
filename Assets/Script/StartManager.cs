using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartManager : MonoBehaviour
{
    bool MouseDown = false;
    float timeCount = 4;
    public Sprite[] TimeLeftSprites;

    private void Start()
    {
        GameObject.Find("BackGround").GetComponent<ScrollManager>().enabled = false;
        GameObject.Find("floorManager").GetComponent<ScrollManager>().enabled = false;
        GameObject.Find("QuizManager").GetComponent<QuizFile>().enabled = false;
        GameObject.Find("GameUI").transform.GetChild(1).gameObject.SetActive(false);
        GameObject.Find("GameUI").transform.GetChild(2).gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.touchCount >= 1 || Input.GetMouseButtonDown(0) || MouseDown)
        {
            MouseDown = true;
            timeCount -= Time.deltaTime;
            GameObject.Find("GameUI").transform.Find("StartMenuUI").Find("TimeLeft").GetComponent<SpriteRenderer>().sprite = TimeLeftSprites[(int)timeCount % 4];
            if(timeCount <= 0)
            {
                GameObject.Find("BackGround").GetComponent<ScrollManager>().enabled = true;
                GameObject.Find("floorManager").GetComponent<ScrollManager>().enabled = true;
                GameObject.Find("QuizManager").GetComponent<QuizFile>().enabled = true;
                GameObject.Find("GameUI").transform.GetChild(1).gameObject.SetActive(true);
                GameObject.Find("GameUI").transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }


}
