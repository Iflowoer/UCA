using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{       
    public GameObject playerPrefab;                                         //플레이어 프리팹
    public GameObject playingPlayer;                                        //플레이 중인 플레이어 오브젝트

    public float Timer;                                                     //누적 시간 플레이 
    public Text uiTextTimer;                                                //UI Timer 정의

    void SpawnPlayer()
    {
        playingPlayer=Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);             //플레이어 프리팹 생성
        Timer = 0.0f;                                                       //타이머 초기화
    }


    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        uiTextTimer.text = Timer.ToString("F1");                            //소수점 1번째 자리까지만 float 값을 string 값으로 변경

        if(playingPlayer!=null)
            Timer += Time.deltaTime;                                             //살아있는 동안 시간 증가

        if(Input.GetKeyDown(KeyCode.Space))                                  //스페이스 누름 감지
        {
            if(playingPlayer==null)                                          //플레이어가 없을 경우 함수 호출로 생성
            {
                SpawnPlayer();
            }
        }
    }
}
