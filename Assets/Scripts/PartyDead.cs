using UnityEngine;
using System.Collections;

public class PartyDead : MonoBehaviour {
    private MovieTexture Video;
    public MovieTexture Video_MM6;
    public MovieTexture Video_MM7;
    public MovieTexture Video_MM8;

    private AudioClip audio;
    public AudioClip audioClip_MM6;
    public AudioClip audioClip_MM7;
    public AudioClip audioClip_MM8;

    private int i;
    private int size_x;
    private int size_y;

    // Use this for initialization
    void Start()
    {
        switch (Application.loadedLevelName)
        {
            case "PartyMM6Dead":
                Video = Video_MM6;
                audio = audioClip_MM6;
                break;
            case "PartyMM7Dead":
                Video = Video_MM7;
                audio = audioClip_MM7;
                break;
            case "PartyMM8Dead":
                Video = Video_MM8;
                audio = audioClip_MM8;
                break;
            default:
                Video = Video_MM7;
                audio = audioClip_MM7;
                break;
        }
        i = 1;
        //Cursor.visible = false;
        Video.Play();
        GetComponent<AudioSource>().clip = audio;
        GetComponent<AudioSource>().Play();
        size_x = 640;
        size_y = 480;
    }

    // Update is called once per frame
    void Update()
    {
        if (Video.isPlaying)
        {

        }
        else {
            if (i > 0)
            {
                if (i == 1)
                {
                    i--;
                    Video.Play();
                    GetComponent<AudioSource>().clip = audio;
                    GetComponent<AudioSource>().Play();
                }
            }
            else {
                Cursor.visible = true;
                Application.LoadLevel("GameSelect");
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Application.LoadLevel("GameSelect");
        }
    }
    void OnGUI()
    {
        if (Event.current.type.Equals(EventType.Repaint))
        {
            Graphics.DrawTexture(new Rect((Screen.width / 2) - (size_x / 2), (Screen.height / 2) - (size_y / 2), size_x, size_y), Video);
        }
    }
}
