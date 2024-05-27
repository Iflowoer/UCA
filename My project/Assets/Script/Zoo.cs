using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Animal tom = new Animal();                      //Class Animal 을 이름을 tom 이라고 선언
        tom.name = "톰";                                //tom 내부 변수 Name 에 접근하기 위해서 Dot(.) 사용 후 name 에 접근
        tom.sound = "냐옹!";

        tom.PlaySound();                                //PlaySound 에는 Debug.Log 를 사용하여 name 과 sound 를 출력

        Animal jerry = new Animal();
        jerry.name = "제리";
        jerry.sound = "찍찍!";

        jerry.PlaySound();

        Animal[] animals = new Animal[10];              //커스텀 클래스 배열화

        for(int i=0; i<animals.Length; i++)
        {
            animals[i] = new Animal();
            animals[i].name = i.ToString() + " 번째 동물 ";
            animals[i].sound = i.ToString() + " 번째 동물 울음 소리 ";
            animals[i].PlaySound();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
