using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8.0f;                  //탄알 이동 속력
    private Rigidbody bulletRigidbody;          //이동에 사용할 리지드바디 컴포넌트

    // Start is called before the first frame update
    void Start()
    {
        //게임 오브젝트에서 Rigidbody 컴포넌트를 찾아서 BulletRigidbody에 할당
        bulletRigidbody = GetComponent<Rigidbody>();

        //리지드바디의 속도 = 앞쪽 방향 * 이동 속력 transform.forward 는 Z축 앞쪽 방향을 이야기한다.
        bulletRigidbody.velocity=transform.forward*speed;

        Destroy(gameObject, 3.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        //충돌한 상대방 게임 오브젝트가 Player 태그를 가진 경우
        if(other.tag=="Player")
        {
            //상대방 게임 오브젝트에서 PlayerController 컴포넌트를 가져온다.
            PlayerController playerController = other.GetComponent<PlayerController>();

            //상대방으로부터 PlayerController 컴포넌트를 가져오는데 성공했다면
            if(playerController != null )
            {
                //상대방 PlayerController 컴포넌트의 메서드를 실행
                playerController.Die();
            }
        }
    }

    private void OnCollisionEnter(Collision collisionr)
    {
        //충돌한 상대방 게임 오브젝트가 Player 태그를 가진 경우
        if (collisionr.gameObject.tag == "Player")
        {
            //상대방 게임 오브젝트에서 PlayerController 컴포넌트를 가져온다.
            PlayerController playerController = collisionr.gameObject.GetComponent<PlayerController>();

            //상대방으로부터 PlayerController 컴포넌트를 가져오는데 성공했다면
            if (playerController != null)
            {
                //상대방 PlayerController 컴포넌트의 메서드를 실행
                playerController.Die();
            }
        }
    }
}
