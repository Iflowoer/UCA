using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8.0f;                  //ź�� �̵� �ӷ�
    private Rigidbody bulletRigidbody;          //�̵��� ����� ������ٵ� ������Ʈ

    // Start is called before the first frame update
    void Start()
    {
        //���� ������Ʈ���� Rigidbody ������Ʈ�� ã�Ƽ� BulletRigidbody�� �Ҵ�
        bulletRigidbody = GetComponent<Rigidbody>();

        //������ٵ��� �ӵ� = ���� ���� * �̵� �ӷ� transform.forward �� Z�� ���� ������ �̾߱��Ѵ�.
        bulletRigidbody.velocity=transform.forward*speed;

        Destroy(gameObject, 3.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        //�浹�� ���� ���� ������Ʈ�� Player �±׸� ���� ���
        if(other.tag=="Player")
        {
            //���� ���� ������Ʈ���� PlayerController ������Ʈ�� �����´�.
            PlayerController playerController = other.GetComponent<PlayerController>();

            //�������κ��� PlayerController ������Ʈ�� �������µ� �����ߴٸ�
            if(playerController != null )
            {
                //���� PlayerController ������Ʈ�� �޼��带 ����
                playerController.Die();
            }
        }
    }

    private void OnCollisionEnter(Collision collisionr)
    {
        //�浹�� ���� ���� ������Ʈ�� Player �±׸� ���� ���
        if (collisionr.gameObject.tag == "Player")
        {
            //���� ���� ������Ʈ���� PlayerController ������Ʈ�� �����´�.
            PlayerController playerController = collisionr.gameObject.GetComponent<PlayerController>();

            //�������κ��� PlayerController ������Ʈ�� �������µ� �����ߴٸ�
            if (playerController != null)
            {
                //���� PlayerController ������Ʈ�� �޼��带 ����
                playerController.Die();
            }
        }
    }
}
