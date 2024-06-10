using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                           //UI ���� ���̺귯��
using UnityEngine.SceneManagement;              //Scene ���� ���̺귯��

public class GameManager : MonoBehaviour
{

    public GameObject gameoverText;             //���� ���� �� Ȱ��ȭ�� �ؽ�Ʈ ���� ������Ʈ (TeXtUI)
    public Text timeText;                       //���� �ð��� ǥ���� �ؽ�Ʈ ������Ʈ
    public Text recordText;                     //�ְ� ����� ǥ���� �ؽ�Ʈ ������Ʈ

    private float surviveTime;                  //���� �ð�
    private bool isGameover;                    //���ӿ��� ����

    void Start()
    {
        //���� �ð��� ���� ���� ���¸� �ʱ�ȭ
        surviveTime = 0;
        isGameover = false;
    }

    void Update()
    {
        //���� ������ �ƴ� ����
        if (!isGameover)
        {
            //���� �ð� ����
            surviveTime += Time.deltaTime;
            //������ ���� �ð��� timeText �ؽ�Ʈ ������Ʈ�� �̿��� ǥ��
            timeText.text="Time : "+ (int)surviveTime;                  //float -> int ��ȯ ��Ű�� �Ҽ����� �������� ����
        }
        else
        {
            //SampleScene �� �ε�
            SceneManager.LoadScene("MyGameScene");                      //���� �������� ���� ��Ͽ� ���
        }
    }

    public void EndGame()
    {
        //���� ���¸� ���� ���� ���·� ��ȯ
        isGameover = true;

        //���� ���� �ؽ�Ʈ ���� ������Ʈ�� Ȱ��ȭ
        gameoverText.SetActive(true);

        //BestTime Ű�� ����� ���������� �ְ� ��� ��������
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        //���� ������ �ְ� ��Ϻ��� ���� ���� �ð��� �� ũ�ٸ�
        if(surviveTime > bestTime)
        {
            //�ְ� ��� ���� ���� ���� �ð� ������ ����
            bestTime= surviveTime;

            //����� �ְ� ����� BestTime Ű�� ����
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        //�ְ� ����� recordText �ؽ�Ʈ ������Ʈ�� �̿��Ͽ� ǥ��
        recordText.text = "BestTime : " + (int)bestTime;
    }

    /*public GameObject playerPrefab;                                         //�÷��̾� ������
    public GameObject playingPlayer;                                        //�÷��� ���� �÷��̾� ������Ʈ

    public float Timer;                                                     //���� �ð� �÷��� 
    public Text uiTextTimer;                                                //UI Timer ����

    void SpawnPlayer()
    {
        playingPlayer = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);             //�÷��̾� ������ ����
        Timer = 0.0f;                                                       //Ÿ�̸� �ʱ�ȭ
    }


    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        uiTextTimer.text = Timer.ToString("F1");                            //�Ҽ��� 1��° �ڸ������� float ���� string ������ ����

        if (playingPlayer != null)
            Timer += Time.deltaTime;                                             //����ִ� ���� �ð� ����

        if (Input.GetKeyDown(KeyCode.Space))                                  //�����̽� ���� ����
        {
            if (playingPlayer == null)                                          //�÷��̾ ���� ��� �Լ� ȣ��� ����
            {
                SpawnPlayer();
            }
        }
    }*/
}
