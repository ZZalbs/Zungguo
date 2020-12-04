using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class QuizFile : MonoBehaviour
{
    int mode = 0;
    int result = 0;
    int score = 0;
    public GameObject quiztile; // 퀴즈 타일
    public GameObject quiztileLeft; // 퀴즈타일 왼쪽꺼
    public Sprite[] images = new Sprite[4];
    SpriteRenderer qs;

    public GameObject player;
    public Text quizText;
    public GameObject quizSet;

    public bool quizcheck; // true이면 퀴즈 시작 가능한 상태,  false이면 퀴즈 안나오는 상태
    string quiz;
    string mean;
    int res;
    public List<QuizFiletype> spawnList;
    public int spawnIndex;
    public bool spawnEnd;
    string line;


    // Start is called before the first frame update
    void Start()
    {
        quizSet.SetActive(false);
        qs = quiztile.GetComponent<SpriteRenderer>();
        quizcheck = true;
        ReadQuizFiletype();
    }

    // Update is called once per frame
    void Update()
    {
        if(quizcheck)
        {
            QuizStart();
            quizcheck = false;
            Debug.Log(res);
        }
    }


    void ReadQuizFiletype()
    {
        //초기화
        spawnList.Clear();
        spawnIndex = 0;
        spawnEnd = false;
        //텍스트파일 읽기
        TextAsset text1 = Resources.Load("source") as TextAsset;
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
            quizData.sungjo = int.Parse(line.Split('/')[1]);
            quizData.meaning = line.Split('/')[2];
            
            spawnList.Add(quizData);
        }
        //파일 닫기
        str.Close();
        //res = spawnList[0].sungjo;
        //1번 스폰 딜레이 적용
    }

    void QuizStart()
    {
        quiz = spawnList[spawnIndex].zungguo;
        mean = spawnList[spawnIndex].meaning;
        res = spawnList[spawnIndex].sungjo;
        quizText.text = quiz;
        quizSet.SetActive(true);
    }




    public void Click1()
    {
        mode = 1;
        qs.sprite = images[0];
        //Debug.Log(mode);
    }
    public void Click2()
    {
        mode = 2;
        qs.sprite = images[1];
        //Debug.Log(mode);
    }
    public void Click3()
    {
        mode = 3;
        qs.sprite = images[2];
        //Debug.Log(mode);
    }

    public void Click4()
    {
        mode = 4;
        qs.sprite = images[3];
        //Debug.Log(mode);
    }

    public void ResultCheck()
    {
        if(res==mode)
        {
            switch(mode)
            {
                case 2:
                    StartCoroutine("sungjo2");
                    break;
                case 3:
                    StartCoroutine("sungjo3");
                    break;
                case 4:
                    StartCoroutine("sungjo4");
                    break;
            }
        }
        else
        {
            Rigidbody2D rigid = player.GetComponent<Rigidbody2D>();
            rigid.gravityScale = 1.0f;
            
            Time.timeScale = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        
    }

}
