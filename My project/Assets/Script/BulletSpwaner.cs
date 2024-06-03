using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpwaner : MonoBehaviour
{
    public GameObject bullerPrefabs;                //������ ź���� ���� ������
    public float spawnRateMin = 0.5f;               //ź�� �ּ� ���� �ֱ�
    public float spwanRateMax = 3.0f;               //ź�� �ִ� ���� �ֱ�

    private Transform target;                       //�߻��� ��� (Transform)
    private float spawnRate;                        //���� �ֱ� (���� ���� ������ ����)
    private float timeAfterSpawn;                   //�ֱ� ���� �������� ���� �ð� (Ÿ�̸Ӹ� ǥ���ϴ� ����)

    public float findTargetTime;                    //Target���� ã�� �ð� �߰�

    // Start is called before the first frame update
    void Start()
    {
        //�ֱ� ���� ������ ���� �ð��� 0���� �ʱ�ȭ
        timeAfterSpawn = 0f;
        //ź�� ���� ������ spawnRateMin�� spawnRateMax ���̿� ���� ����
        spawnRate = Random.Range(spawnRateMin, spwanRateMax);
        //PlayerController ������Ʈ�� ���� ���� ������Ʈ�� ã�Ƽ� ���� ������� ����
        target=FindObjectOfType<PlayerController>().transform;  //Target�� (Transform) ,
                                                                //FindObjectOfType<PlayerController>() (GameObject)�̱� ������ 
                                                                //.transform���� ���� ������ ������ ����� �ش�.
        //���� ������Ʈ�� ã�� ��� (Scene)
        //FindObjectOfType : ������Ʈ�� ã�´�.
        //FindWithTag : Tag �� ���� ������Ʈ�� ã�´�. -> GameObject.FindWithTag("Respawn");
    }

    // Update is called once per frame
    void Update()
    {
        if (findTargetTime >= 1.0f)                                         //Ÿ���� ���� �ð��� 1�ʰ� �Ѿ� ���� ��
        {
            GameObject findTarget = GameObject.FindWithTag("Player");
            if (findTarget != null)
            {
                target = findTarget.transform;
            }

            //target=FindObjectOfType<PlayerController>().transform; //Target ������Ʈ�� ã�´�.

            findTargetTime = 0.0f;                                          //ã�� �ð��� �ʱ�ȭ �����ش�.
        }
        if(target==null)                                //Ÿ���� ���� ���
        {
            findTargetTime = Time.deltaTime;            //Ÿ���� ���� ��� ���� �ð��� ����ؼ�
            return;                                     //Update�� ����������.
        }

        //timerAfterSpawn ����
        timeAfterSpawn += Time.deltaTime;               //�ش� ������ �ʸ� �׾Ƽ� timeAfterSpawn�� �ݿ�

        //�ֱ� ���� �������� ���� �������� �ð��� ���� �ֱ⺸�� ũ��
        if(timeAfterSpawn >= spawnRate) 
        {
            timeAfterSpawn = 0f;

            //bulletPrefab�� �������� ����
            //transform.position ��ġ�� transform.rotation ȸ������ ����
            GameObject bullet
                = Instantiate(bullerPrefabs, transform.transform.position, transform.rotation);

            //������ bullet ���� ������Ʈ�� ���� ������ target�� ���ϵ��� ȸ��
            bullet.transform.LookAt(target);

            //������ ���� ������ spawnRateMin, spawnRateMax ���̿��� ������ ����
            spawnRate = Random.Range(spawnRateMin, spwanRateMax);
        }
    }
}
