using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartManager : MonoBehaviour
{
    private void Start()
    {
        GameObject.Find("BackGround").GetComponent<ScrollManager>().enabled = false;
        GameObject.Find("floorManager").GetComponent<ScrollManager>().enabled = false;
        GameObject.Find("QuizManager").GetComponent<QuizFile>().enabled = false;
        GameObject.Find("GameUI").transform.GetChild(1).gameObject.SetActive(false);
        GameObject.Find("GameUI").transform.GetChild(2).gameObject.SetActive(false);
    }




}
