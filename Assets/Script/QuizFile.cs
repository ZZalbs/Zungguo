using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class QuizFile : MonoBehaviour
{
    int mode = 0;
    int result = 0;
    public GameObject quiztile;
    public Sprite[] images = new Sprite[4];
    SpriteRenderer qs;
    public List<QuizFiletype> spawnList;
    public int spawnIndex;
    public bool spawnEnd;
    string line;


    // Start is called before the first frame update
    void Start()
    {
        qs = quiztile.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void ReadQuizFiletype()
    {
        //초기화
        spawnList.Clear();
        spawnIndex = 0;
        spawnEnd = false;
        //텍스트파일 읽기
        TextAsset text1 = Resources.Load("source.txt") as TextAsset;
        StringReader str = new StringReader(text1.text);

        while (str != null)
        {
            //텍스트파일 읽기2
            line = str.ReadLine();
            if (line == null)
                break;

            //읽은 값 리스트에 넣기
            QuizFiletype quizData = new QuizFiletype();
            quizData.zungguo = line.Split('/')[0];
            quizData.meaning = line.Split('/')[1];
            quizData.sungjo = int.Parse(line.Split('/')[2]);
            spawnList.Add(quizData);
        }
        //파일 닫기
        str.Close();

        //1번 스폰 딜레이 적용

    }

    public void Click1()
    {
        mode = 1;
        qs.sprite = images[0];
        Debug.Log(mode);
    }
    public void Click2()
    {
        mode = 2;
        qs.sprite = images[1];
        Debug.Log(mode);
    }
    public void Click3()
    {
        mode = 3;
        qs.sprite = images[2];
        Debug.Log(mode);
    }

    public void Click4()
    {
        mode = 4;
        qs.sprite = images[3];
        Debug.Log(mode);
    }

    void ResultCheck()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" )
        {
            ResultCheck();
        }
    }

}
