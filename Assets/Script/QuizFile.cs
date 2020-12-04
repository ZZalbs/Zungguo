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
    int hardness=1;
    public GameObject quiztile; // 퀴즈 타일
    public GameObject quiztileLeft; // 퀴즈타일 왼쪽꺼
    public GameObject quiztileRight; // 퀴즈타일 오른쪽꺼
    public Sprite[] images = new Sprite[4];
    SpriteRenderer qs;

    public GameObject player;
    public Text quizText;
    public Text distanceText;
    public GameObject quizSet;

    public bool quizcheck; // true이면 퀴즈 시작 가능한 상태,  false이면 퀴즈 안나오는 상태
    string quiz;
    string mean;
    int res;
    public List<QuizFiletype> spawnList;
    public int spawnIndex;
    public bool spawnEnd;
    string line;

    int a;

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
        a = (quiztile.transform.position.x - player.transform.position.x - 3.8) / 0.196 >= 0 ? (int)((quiztile.transform.position.x - player.transform.position.x -3.8) / 0.196) : 0; // 거리계산식
        distanceText.text =  a.ToString() + "m";
        if(quizcheck)
        {
            distanceText.enabled = true; 
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
                    StartCoroutine("playerTurn", 3);
                    StartCoroutine("sungjo2");
                    break;
                case 3:
                    StartCoroutine("sungjo3");
                    StartCoroutine("playerTurn", -3);
                    break;
                case 4:
                    StartCoroutine("playerTurn", -3);
                    StartCoroutine("sungjo4");
                    break;
            }
        }
        else
        {
            Rigidbody2D rigid = player.GetComponent<Rigidbody2D>();
            Rigidbody2D tileRg = quiztile.GetComponent<Rigidbody2D>();
            rigid.gravityScale = 2.0f;
            tileRg.gravityScale = 2.0f;

        }
    }

    IEnumerator playerTurn(int angle)
    {
        for (int i = 0; i < 15; i++)
        {
            player.transform.Rotate(new Vector3(0, 0, angle));
            yield return new WaitForSeconds(0.001f);
        }
    }

    IEnumerator sungjo2()
    {
        yield return new WaitForSeconds(0.3f);
        quiztileRight.transform.Translate(0, 4f, 0);
        for (int i = 0; i < 50; i++)
        {
            quiztileRight.transform.Translate(0, -0.08f, 0);
            quiztileLeft.transform.Translate(0, -0.08f, 0);
            quiztile.transform.Translate(0,-0.08f,0);
            yield return new WaitForSeconds(0.018f);
        }
        //quiztileRight.transform.Translate(0, 4f, 0);
        StartCoroutine("playerTurn", -3);
        yield return new WaitForSeconds(1f);
        quiztileLeft.transform.localPosition = new Vector3(quiztileLeft.transform.localPosition.x,-1.4f,0);
        quiztile.transform.localPosition = new Vector3(quiztile.transform.localPosition.x, -1.4f, 0);
    }
    IEnumerator sungjo3()
    {
        for (int i = 0; i < 25; i++)
        {
            player.transform.Translate(0, -0.1f, 0,Space.World);
            yield return new WaitForSeconds(0.025f);
        }
        StartCoroutine("playerTurn", 6);
        yield return new WaitForSeconds(0.1f);
        for (int i = 0; i < 25; i++)
        {
            player.transform.Translate(0, 0.1f, 0, Space.World);
            yield return new WaitForSeconds(0.025f);
        }
        StartCoroutine("playerTurn",-3);

    }
    IEnumerator sungjo4()
    {
        yield return new WaitForSeconds(0.4f);
        quiztileRight.transform.Translate(0, -4f, 0);
        for (int i = 0; i < 50; i++)
        {
            quiztileRight.transform.Translate(0, 0.08f, 0);
            quiztileLeft.transform.Translate(0, 0.08f, 0);
            quiztile.transform.Translate(0, 0.08f, 0);
            yield return new WaitForSeconds(0.018f);
        }
        //quiztileRight.transform.Translate(0, 4f, 0);
        StartCoroutine("playerTurn", 3);
        yield return new WaitForSeconds(1f);
        quiztileLeft.transform.localPosition = new Vector3(quiztileLeft.transform.localPosition.x, -1.4f, 0);
        quiztile.transform.localPosition = new Vector3(quiztile.transform.localPosition.x, -1.4f, 0);
    }

}
