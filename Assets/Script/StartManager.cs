﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    bool MouseDown = false;
    float timeCount = 4;
    public Sprite[] TimeLeftSprites;
    public Text touchToStart;
    float colorcheck = 0;

    private void Start()
    {
        GameObject.Find("BackGround").GetComponent<ScrollManager>().enabled = false;
        GameObject.Find("floorManager").GetComponent<ScrollManager>().enabled = false;
        GameObject.Find("QuizManager").GetComponent<QuizFile>().enabled = false;
        GameObject.Find("GameUI").transform.GetChild(1).gameObject.SetActive(false);
        GameObject.Find("GameUI").transform.GetChild(2).gameObject.SetActive(false);
        StartCoroutine("colorChange");
        gameObject.GetComponent<EndManager>().enabled = false;
    }

    private void Update()
    {

        if (Input.touchCount >= 1 || Input.GetMouseButtonDown(0) || MouseDown)
        {
            GameObject.Find("GameUI").transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
            GameObject.Find("GameUI").transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
            GameObject.Find("GameUI").transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
            MouseDown = true;
            timeCount -= Time.deltaTime;
            GameObject.Find("GameUI").transform.Find("StartMenuUI").Find("timeLeft").GetComponent<SpriteRenderer>().sprite = TimeLeftSprites[(int)timeCount % 4];
            if((int)timeCount%4 == 0)
            {
                GameObject.Find("GameUI").transform.Find("StartMenuUI").Find("timeLeft").transform.localScale = new Vector3(58, 52, 42.2f);
            }
            if(timeCount <= 0.5)
            {
                GameObject.Find("BackGround").GetComponent<ScrollManager>().enabled = true;
                GameObject.Find("floorManager").GetComponent<ScrollManager>().enabled = true;
                GameObject.Find("QuizManager").GetComponent<QuizFile>().enabled = true;
                GameObject.Find("GameUI").transform.GetChild(1).gameObject.SetActive(true);
                GameObject.Find("GameUI").transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }

    IEnumerator colorChange()
    {
        while (true) {
            for (int i = 0; i < 50; i++) {
                colorcheck += 0.02f;
                touchToStart.color = new Color(touchToStart.color.r, touchToStart.color.g, touchToStart.color.b, colorcheck);
                yield return new WaitForSeconds(0.01f);
            }
            for (int i = 0; i < 50; i++)
            {
                colorcheck -= 0.02f;
                touchToStart.color = new Color(touchToStart.color.r, touchToStart.color.g, touchToStart.color.b, colorcheck);
                yield return new WaitForSeconds(0.01f);
            }


        }
    }


}
