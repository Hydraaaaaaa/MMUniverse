using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

	//скрипт стрелы, баллистическая траектория+застревание в цели.
	
	
	void Start () {
		//смещение центра тяжести по оси z
		GetComponent<Rigidbody>().centerOfMass = new Vector3 (0, 0, 5);
		//GetComponent<Transform>().rotation = new Quaternion(0,180,0,0);

	}
	// функция проверки столкновения
	void OnCollisionEnter (Collision Info) {
        if (Info.gameObject.tag == "Explosions")
        {
            // отключение физики стрелы включение кинематики
            GetComponent<Rigidbody>().isKinematic = true;
            // координаты стрелы присоединяются к координатам объекта столкновения.
            transform.parent = Info.transform;
        }
        else if (Info.gameObject.tag == "Actor")
        {
            GetComponent<Rigidbody>().isKinematic = true;
            // координаты стрелы присоединяются к координатам объекта столкновения.
            transform.parent = Info.transform;
            int hp = Info.gameObject.GetComponentInParent<Actors>().sCurrentHP;
            if (Info.gameObject.GetComponentInParent<Actors>().sCurrentHP > 0)
            {
                Info.gameObject.GetComponentInParent<Actors>().sCurrentHP -= 5;
                Info.gameObject.GetComponentInParent<MonsterAI>().uHostilityType = MonsterAI.HostilityRadius.Hostility_Short;
            }
        }
    }


}
