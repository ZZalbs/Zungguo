using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollManager: MonoBehaviour
{
    public QuizFile qf;
    public float speed;
    public int rightTile;// 현재꺼 인덱스, (제일처음 시작시 마지막 인덱스)
    public int leftTile;//제일 먼저나오는거 인덱스
    public Transform[] sprites;


    int quizNum; // 문제 타일 번호 (=총 타일 개수-1)
    

    Vector3 curPos, nextPos; // 현위치, 다음위치
    Vector3 rightSpritePos,leftSpritePos; // 오른배경, 왼배경
    public float viewHeight; // 카메라 크기or 이동단위

    void Awake()
    {
        quizNum = rightTile;
        //viewHeight = 26.0f-6.8f;//sprites[0].position.x * 2;        
    }

    void Update()
    {
        Move();
        Scroll();
    }

    void Move()
    {
        curPos = transform.position;
        nextPos = Vector2.left * speed * qf.hardness* Time.deltaTime;
        transform.position = curPos + nextPos;

    }
    void Scroll()
    {
        if (sprites[leftTile].position.x < (-1) * viewHeight)
        {
            //스프라이트 재사용
            //로컬포지션 쓰는 이유 : 포지션은 다른 오브젝트의 자식일 경우에 위치값이 계속 바뀜
            rightSpritePos = sprites[rightTile].localPosition;  // 가장 오른쪽의 타일 로컬포지션값
            leftSpritePos = sprites[leftTile].localPosition;  // 가장 왼쪽의 타일 로컬포지션값
            sprites[leftTile].transform.localPosition = rightSpritePos + Vector3.right * viewHeight; // 왼쪽 끝에 오면 오른쪽 끝까지 보냄
            //Transform leftPos = sprites[leftTile].transform;
            //leftPos.Translate(new Vector3(viewHeight*sprites.Length,0,0)); // 왼쪽 끝에 오면 오른쪽 끝까지 보냄
            //Debug.Log(Vector3.right * viewHeight * (sprites.Length));

            //스프라이트 인덱스 정리
            
            rightTile = (rightTile + 1 == sprites.Length) ? 0 : rightTile + 1;
            int tmp = rightTile;
            leftTile = (tmp +1 == sprites.Length) ? 0 : tmp + 1;  // 배열범위 넘어가는값 예외처리

        }
    }
}
