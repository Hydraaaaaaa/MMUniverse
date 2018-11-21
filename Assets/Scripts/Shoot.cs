using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
	public GameObject Arrow; //Префаб стрелы/пули
	private float Timer; //таймер который позволяет стрелять
	public float Reload; //время перезарядкы
    public float throwForce;
    public bool Shoot_flag;

    private AudioSource m_AudioSource;
    public AudioClip[] atack_sounds = new AudioClip[2];

    // Use this for initialization
    void Start () {
        m_AudioSource = GetComponent<AudioSource>();
        Shoot_flag = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Temp.current_screen == Temp.screen_name.screen_game)
        {
            Timer -= Time.deltaTime; //таймер перезарядки

            if (Shoot_flag /*Input.GetButtonUp("Fire1")*/ && Timer <= 0)
            { //нажатия ctrl + mouse1
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                GameObject Arrov;
                if (Physics.Raycast(ray, out hit, 20f))
                {
                    //нереализовано: если направлена мышь на монстра рядом, направление стрелы меняется
                    Arrov = (GameObject)Instantiate(Arrow, transform.position, transform.rotation); //Создаем дубликат стрелы в позиции объекта на котором скрипт
                    Arrov.GetComponent<Transform>().rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 90, transform.rotation.eulerAngles.z);
                    //var vector = hit.point;
                    //transform.Translate(vector * Time.deltaTime);
                    Arrov.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(new Vector3(0, 0, throwForce * 1000)));
                    //Vector3 fireDirection = transform.position - hit.point;
                    //Arrov.GetComponent<Rigidbody>().AddForce(fireDirection *1000);
                    //Arrov.GetComponent<Rigidbody>().AddForce(Vector3.Slerp(transform.position, hit.transform.position, Time.deltaTime) * throwForce);

                }
                else
                {
                    Arrov = (GameObject)Instantiate(Arrow, transform.position, transform.rotation); //Создаем дубликат стрелы в позиции объекта на котором скрипт
                    Arrov.GetComponent<Transform>().rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 90, transform.rotation.eulerAngles.z);
                    Arrov.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(new Vector3(0, 0, throwForce * 1000)));
                }
                m_AudioSource.PlayOneShot(atack_sounds[0]);
                Destroy(Arrov, 5.0f);
                Timer = Reload; //устанавливаем таймер например на 2 сек
                Shoot_flag = false;
            }
        }
    }
  
}
