using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                           //UI 관련 라이브러리
using UnityEngine.SceneManagement;              //Scene 관련 라이브러리

public class GameManager : MonoBehaviour
{

    public GameObject gameoverText;             //게임 오버 시 활성화할 텍스트 게임 오브젝트 (TeXtUI)
    public Text timeText;                       //생존 시간을 표시할 텍스트 컴포넌트
    public Text recordText;                     //최고 기록을 표시할 텍스트 컴포넌트

    private float surviveTime;                  //생존 시간
    private bool isGameover;                    //게임오버 상태

    void Start()
    {
        //생존 시간과 게임 오버 상태를 초기화
        surviveTime = 0;
        isGameover = false;
    }

    void Update()
    {
        //게임 오버가 아닌 동안
        if (!isGameover)
        {
            //생존 시간 갱신
            surviveTime += Time.deltaTime;
            //갱신한 생존 시간을 timeText 텍스트 컴포넌트를 이용해 표시
            timeText.text="Time : "+ (int)surviveTime;                  //float -> int 변환 시키면 소수점이 없어져서 보임
        }
        else
        {
            //SampleScene 씬 로드
            SceneManager.LoadScene("MyGameScene");                      //빌드 설정에서 빌드 목록에 등록
        }
    }

    public void EndGame()
    {
        //현재 상태를 게임 오버 상태로 전환
        isGameover = true;

        //게임 오버 텍스트 게임 오브젝트를 활성화
        gameoverText.SetActive(true);

        //BestTime 키로 저장된 이전까지의 최고 기록 가져오기
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        //이전 까지의 최고 기록보다 현재 생존 시간이 더 크다면
        if(surviveTime > bestTime)
        {
            //최고 기록 값을 현재 생존 시간 값으로 변경
            bestTime= surviveTime;

            //변경된 최고 기록을 BestTime 키로 저장
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        //최고 기록을 recordText 텍스트 컴포넌트를 이용하여 표시
        recordText.text = "BestTime : " + (int)bestTime;
    }

    /*public GameObject playerPrefab;                                         //플레이어 프리팹
    public GameObject playingPlayer;                                        //플레이 중인 플레이어 오브젝트

    public float Timer;                                                     //누적 시간 플레이 
    public Text uiTextTimer;                                                //UI Timer 정의

    void SpawnPlayer()
    {
        playingPlayer = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);             //플레이어 프리팹 생성
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

        if (playingPlayer != null)
            Timer += Time.deltaTime;                                             //살아있는 동안 시간 증가

        if (Input.GetKeyDown(KeyCode.Space))                                  //스페이스 누름 감지
        {
            if (playingPlayer == null)                                          //플레이어가 없을 경우 함수 호출로 생성
            {
                SpawnPlayer();
            }
        }
    }*/
}
