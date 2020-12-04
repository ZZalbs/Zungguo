using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public QuizFile qf;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "quizStart") {
            qf.ResultCheck();
            qf.quizSet.SetActive(false);
        }
        if (collision.gameObject.tag == "quizStop")
        {
            
            qf.quizSet.SetActive(true);
            qf.spawnIndex++;
            qf.quizcheck = true;
            
        }

        if(collision.gameObject.tag == "Die")
        {
            Time.timeScale = 0;
        }
    }


}
