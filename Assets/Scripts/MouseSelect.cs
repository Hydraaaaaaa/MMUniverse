using UnityEngine;
using System.Collections;


public class MouseSelect : MonoBehaviour
{
    [SerializeField]
    private AudioClip Chest_sound;
    public AudioClip Enter_sound;

    public bool mouse_select_reset = false;

    public bool chest_flag = false;
    public bool wall_flag = false;
    public bool bonfire_flag = false;
    public bool weaponsmith_door_flag = false;
    public bool armor_door_flag = false;
    public bool tavern_door_flag = false;
    public bool home1_door_flag = false;
    public bool home2_door_flag = false;
    public bool home3_door_flag = false;
    public bool home4_door_flag = false;
    public bool home5_door_flag = false;
    public bool LordMarhem_door_flag = false;
    public bool doctor_door_flag = false;
    public bool training_door_flag = false;
    public bool spirit_door_flag = false;
    public bool water_door_flag = false;
    public bool air_door_flag = false;
    public bool alchimist_door_flag = false;
    public bool body_door_flag = false;
    public bool fire_door_flag = false;
    public bool mage_door_flag = false;
    public bool moon_door_flag = false;
    public bool dragon_door_flag = false;
    public bool boat_door_flag = false;
    public bool menu_flag = false;
    public bool Dangeon_door_flag = false;
    // При запуске
    void Start()
    {
        Cursor.visible = true;
    }

    // во время игры
    void Update()
    {
        if (Temp.current_screen == Temp.screen_name.screen_game) {
            MouseUp();
            if (mouse_select_reset)
                MS_reset();
        }
    }
    public void MS_reset()
    {
        chest_flag = false;
        wall_flag = false;
        bonfire_flag = false;
        weaponsmith_door_flag = false;
        armor_door_flag = false;
        tavern_door_flag = false;
        home1_door_flag = false;
        home2_door_flag = false;
        home3_door_flag = false;
        home4_door_flag = false;
        home5_door_flag = false;
        LordMarhem_door_flag = false;
        doctor_door_flag = false;
        training_door_flag = false;
        spirit_door_flag = false;
        water_door_flag = false;
        air_door_flag = false;
        alchimist_door_flag = false;
        body_door_flag = false;
        fire_door_flag = false;
        mage_door_flag = false;
        moon_door_flag = false;
        dragon_door_flag = false;
        boat_door_flag = false;
        menu_flag = false;
        mouse_select_reset = false;
    }
    //На что нажали мыщью
    void MouseUp()
    { 
        //не реагировать на панель персонажей
        if ((Input.mousePosition.x > (Screen.width / 2) - 234 && Input.mousePosition.x < (Screen.width / 2) + 234) && (Input.mousePosition.y > 0 && Input.mousePosition.y < 128))
            return;
        //не реагировать на правую панель 
        if ((Input.mousePosition.x > Screen.width - 173 && Input.mousePosition.x < Screen.width) && (Input.mousePosition.y > 0 && Input.mousePosition.y < 480))
            return;
        //Проверка попадания луча от мыши
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 10f))
        {

            //проверка куда попал луч
            if (hit.collider.tag == "Chest" && !chest_flag && !menu_flag)
            {//на ящик
                if (Input.GetMouseButtonUp(0))
                {                           //нажата ли правая кнопка мыши
                    chest_flag = true;
                    hit.collider.GetComponent<Chest>().Chest_open_flag = true;
                    Temp.current_screen = Temp.screen_name.screen_chest;
                    //GetComponent<AudioSource>().PlayOneShot(Chest_sound);
                }
            }
            if (hit.collider.tag == "wall" && !wall_flag && !menu_flag)
            {//на ящик
                if (Input.GetMouseButtonUp(0))
                {                           //нажата ли правая кнопка мыши
                    wall_flag = true;
                    hit.collider.GetComponent<Wall_event>().wall_state = Wall_event.Wall_state.Wall_performed;
                    //GetComponent<AudioSource>().PlayOneShot(Chest_sound);
                }
            }
            else if (hit.collider.tag == "bonfire" && !bonfire_flag && !menu_flag)
            {//на костер
                if (Input.GetMouseButtonUp(0))
                {                           //нажата ли правая кнопка мыши
                    bonfire_flag = true;
                    hit.collider.GetComponent<Bonfire_event>().BF_state = Bonfire_event.BF_STATE.BF_performed;
                    //GetComponent<AudioSource>().PlayOneShot(Chest_sound);
                }
            }
            else if (hit.collider.tag == "weaponsmith_door" && !weaponsmith_door_flag && !menu_flag)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    weaponsmith_door_flag = true;
                    Temp.current_screen = Temp.screen_name.screen_house;
                    Temp.current_house_tag = hit.collider.tag;
                    GetComponent<AudioSource>().PlayOneShot(Enter_sound);
                    if (hit.collider.GetComponent<house_data>().Greeting != null)
                    {
                        hit.collider.GetComponent<AudioSource>().clip = hit.collider.GetComponent<house_data>().Greeting;
                        hit.collider.GetComponent<AudioSource>().Play();
                        hit.collider.GetComponent<AudioSource>().loop = false;
                        hit.collider.GetComponent<AudioSource>().volume = 0.8f;
                    }
                }
            }
            else if (hit.collider.tag == "doctor_door" && !doctor_door_flag && !menu_flag)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    doctor_door_flag = true;
                    Temp.current_screen = Temp.screen_name.screen_house;
                    Temp.current_house_tag = hit.collider.tag;
                    GetComponent<AudioSource>().PlayOneShot(Enter_sound);
                    if (hit.collider.GetComponent<house_data>().Greeting != null)
                    {
                        hit.collider.GetComponent<AudioSource>().clip = hit.collider.GetComponent<house_data>().Greeting;
                        hit.collider.GetComponent<AudioSource>().Play();
                        hit.collider.GetComponent<AudioSource>().loop = false;
                        hit.collider.GetComponent<AudioSource>().volume = 0.8f;
                    }
                }
            }

            else if (hit.collider.tag == "armor_door" && !armor_door_flag && !menu_flag)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    armor_door_flag = true;
                    Temp.current_screen = Temp.screen_name.screen_house;
                    Temp.current_house_tag = hit.collider.tag;
                    GetComponent<AudioSource>().PlayOneShot(Enter_sound);
                    if (hit.collider.GetComponent<house_data>().Greeting != null)
                    {
                        hit.collider.GetComponent<AudioSource>().clip = hit.collider.GetComponent<house_data>().Greeting;
                        hit.collider.GetComponent<AudioSource>().Play();
                        hit.collider.GetComponent<AudioSource>().loop = false;
                        hit.collider.GetComponent<AudioSource>().volume = 0.8f;
                    }
                }
            }
            else if (hit.collider.tag == "tavern_door" && !tavern_door_flag && !menu_flag)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    tavern_door_flag = true;
                    Temp.current_screen = Temp.screen_name.screen_house;
                    Temp.current_house_tag = hit.collider.tag;
                    GetComponent<AudioSource>().PlayOneShot(Enter_sound);
                    if (hit.collider.GetComponent<house_data>().Greeting != null)
                    {
                        hit.collider.GetComponent<AudioSource>().clip = hit.collider.GetComponent<house_data>().Greeting;
                        hit.collider.GetComponent<AudioSource>().Play();
                        hit.collider.GetComponent<AudioSource>().loop = false;
                        hit.collider.GetComponent<AudioSource>().volume = 0.8f;
                    }
                }
            }
            else if (hit.collider.tag == "home1_door" && !home1_door_flag && !menu_flag)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    home1_door_flag = true;
                    Temp.current_screen = Temp.screen_name.screen_house;
                    Temp.current_house_tag = hit.collider.tag;
                    GetComponent<AudioSource>().PlayOneShot(Enter_sound);
                    if (hit.collider.GetComponent<house_data>().Greeting != null)
                    {
                        hit.collider.GetComponent<AudioSource>().clip = hit.collider.GetComponent<house_data>().Greeting;
                        hit.collider.GetComponent<AudioSource>().Play();
                        hit.collider.GetComponent<AudioSource>().loop = false;
                        hit.collider.GetComponent<AudioSource>().volume = 0.8f;
                    }
                }
            }
            else if (hit.collider.tag == "home2_door" && !home2_door_flag && !menu_flag)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    home2_door_flag = true;
                    Temp.current_screen = Temp.screen_name.screen_house;
                    Temp.current_house_tag = hit.collider.tag;
                    GetComponent<AudioSource>().PlayOneShot(Enter_sound);
                    if (hit.collider.GetComponent<house_data>().Greeting != null)
                    {
                        hit.collider.GetComponent<AudioSource>().clip = hit.collider.GetComponent<house_data>().Greeting;
                        hit.collider.GetComponent<AudioSource>().Play();
                        hit.collider.GetComponent<AudioSource>().loop = false;
                        hit.collider.GetComponent<AudioSource>().volume = 0.8f;
                    }
                }
            }
            else if (hit.collider.tag == "home3_door" && !home3_door_flag && !menu_flag)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    home3_door_flag = true;
                    Temp.current_screen = Temp.screen_name.screen_house;
                    Temp.current_house_tag = hit.collider.tag;
                    GetComponent<AudioSource>().PlayOneShot(Enter_sound);
                    if (hit.collider.GetComponent<house_data>().Greeting != null)
                    {
                        hit.collider.GetComponent<AudioSource>().clip = hit.collider.GetComponent<house_data>().Greeting;
                        hit.collider.GetComponent<AudioSource>().Play();
                        hit.collider.GetComponent<AudioSource>().loop = false;
                        hit.collider.GetComponent<AudioSource>().volume = 0.8f;
                    }
                }
            }
            else if (hit.collider.tag == "home2_door" && !home4_door_flag && !menu_flag)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    home4_door_flag = true;
                    Temp.current_screen = Temp.screen_name.screen_house;
                    Temp.current_house_tag = hit.collider.tag;
                    GetComponent<AudioSource>().PlayOneShot(Enter_sound);
                    if (hit.collider.GetComponent<house_data>().Greeting != null)
                    {
                        hit.collider.GetComponent<AudioSource>().clip = hit.collider.GetComponent<house_data>().Greeting;
                        hit.collider.GetComponent<AudioSource>().Play();
                        hit.collider.GetComponent<AudioSource>().loop = false;
                        hit.collider.GetComponent<AudioSource>().volume = 0.8f;
                    }
                }
            }
            else if (hit.collider.tag == "home5_door" && !home5_door_flag && !menu_flag)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    home5_door_flag = true;
                    Temp.current_screen = Temp.screen_name.screen_house;
                    Temp.current_house_tag = hit.collider.tag;
                    GetComponent<AudioSource>().PlayOneShot(Enter_sound);
                    if (hit.collider.GetComponent<house_data>().Greeting != null)
                    {
                        hit.collider.GetComponent<AudioSource>().clip = hit.collider.GetComponent<house_data>().Greeting;
                        hit.collider.GetComponent<AudioSource>().Play();
                        hit.collider.GetComponent<AudioSource>().loop = false;
                        hit.collider.GetComponent<AudioSource>().volume = 0.8f;
                    }
                }
            }
            else if (hit.collider.tag == "training_door" && !training_door_flag && !menu_flag)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    training_door_flag = true;
                    Temp.current_screen = Temp.screen_name.screen_house;
                    Temp.current_house_tag = hit.collider.tag;
                    GetComponent<AudioSource>().PlayOneShot(Enter_sound);
                    if (hit.collider.GetComponent<house_data>().Greeting != null)
                    {
                        hit.collider.GetComponent<AudioSource>().clip = hit.collider.GetComponent<house_data>().Greeting;
                        hit.collider.GetComponent<AudioSource>().Play();
                        hit.collider.GetComponent<AudioSource>().loop = false;
                        hit.collider.GetComponent<AudioSource>().volume = 0.8f;
                    }
                }
            }
            else if (hit.collider.tag == "spirit_door" && !spirit_door_flag && !menu_flag)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    spirit_door_flag = true;
                    Temp.current_screen = Temp.screen_name.screen_house;
                    Temp.current_house_tag = hit.collider.tag;
                    GetComponent<AudioSource>().PlayOneShot(Enter_sound);
                    if (hit.collider.GetComponent<house_data>().Greeting != null)
                    {
                        hit.collider.GetComponent<AudioSource>().clip = hit.collider.GetComponent<house_data>().Greeting;
                        hit.collider.GetComponent<AudioSource>().Play();
                        hit.collider.GetComponent<AudioSource>().loop = false;
                        hit.collider.GetComponent<AudioSource>().volume = 0.8f;
                    }
                }
            }
            else if (hit.collider.tag == "air_door" && !air_door_flag && !menu_flag)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    air_door_flag = true;
                    Temp.current_screen = Temp.screen_name.screen_house;
                    Temp.current_house_tag = hit.collider.tag;
                    GetComponent<AudioSource>().PlayOneShot(Enter_sound);
                    if (hit.collider.GetComponent<house_data>().Greeting != null)
                    {
                        hit.collider.GetComponent<AudioSource>().clip = hit.collider.GetComponent<house_data>().Greeting;
                        hit.collider.GetComponent<AudioSource>().Play();
                        hit.collider.GetComponent<AudioSource>().loop = false;
                        hit.collider.GetComponent<AudioSource>().volume = 0.8f;
                    }
                }
            }
            else if (hit.collider.tag == "mage_door" && !mage_door_flag && !menu_flag)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    mage_door_flag = true;
                    Temp.current_screen = Temp.screen_name.screen_house;
                    Temp.current_house_tag = hit.collider.tag;
                    GetComponent<AudioSource>().PlayOneShot(Enter_sound);
                    if (hit.collider.GetComponent<house_data>().Greeting != null)
                    {
                        hit.collider.GetComponent<AudioSource>().clip = hit.collider.GetComponent<house_data>().Greeting;
                        hit.collider.GetComponent<AudioSource>().Play();
                        hit.collider.GetComponent<AudioSource>().loop = false;
                        hit.collider.GetComponent<AudioSource>().volume = 0.8f;
                    }
                }
            }
            else if (hit.collider.tag == "fire_door" && !fire_door_flag && !menu_flag)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    fire_door_flag = true;
                    Temp.current_screen = Temp.screen_name.screen_house;
                    Temp.current_house_tag = hit.collider.tag;
                    GetComponent<AudioSource>().PlayOneShot(Enter_sound);
                    if (hit.collider.GetComponent<house_data>().Greeting != null)
                    {
                        hit.collider.GetComponent<AudioSource>().clip = hit.collider.GetComponent<house_data>().Greeting;
                        hit.collider.GetComponent<AudioSource>().Play();
                        hit.collider.GetComponent<AudioSource>().loop = false;
                        hit.collider.GetComponent<AudioSource>().volume = 0.8f;
                    }
                }
            }
            else if (hit.collider.tag == "alchimist_door" && !alchimist_door_flag && !menu_flag)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    alchimist_door_flag = true;
                    Temp.current_screen = Temp.screen_name.screen_house;
                    Temp.current_house_tag = hit.collider.tag;
                    GetComponent<AudioSource>().PlayOneShot(Enter_sound);
                    if (hit.collider.GetComponent<house_data>().Greeting != null)
                    {
                        hit.collider.GetComponent<AudioSource>().clip = hit.collider.GetComponent<house_data>().Greeting;
                        hit.collider.GetComponent<AudioSource>().Play();
                        hit.collider.GetComponent<AudioSource>().loop = false;
                        hit.collider.GetComponent<AudioSource>().volume = 0.8f;
                    }
                }
            }
            else if (hit.collider.tag == "body_door" && !body_door_flag && !menu_flag)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    body_door_flag = true;
                    Temp.current_screen = Temp.screen_name.screen_house;
                    Temp.current_house_tag = hit.collider.tag;
                    GetComponent<AudioSource>().PlayOneShot(Enter_sound);
                    if (hit.collider.GetComponent<house_data>().Greeting != null)
                    {
                        hit.collider.GetComponent<AudioSource>().clip = hit.collider.GetComponent<house_data>().Greeting;
                        hit.collider.GetComponent<AudioSource>().Play();
                        hit.collider.GetComponent<AudioSource>().loop = false;
                        hit.collider.GetComponent<AudioSource>().volume = 0.8f;
                    }
                }
            }
            else if (hit.collider.tag == "boat_door" && !boat_door_flag && !menu_flag)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    boat_door_flag = true;
                    Temp.current_screen = Temp.screen_name.screen_house;
                    Temp.current_house_tag = hit.collider.tag;
                    GetComponent<AudioSource>().PlayOneShot(Enter_sound);
                    if (hit.collider.GetComponent<house_data>().Greeting != null)
                    {
                        hit.collider.GetComponent<AudioSource>().clip = hit.collider.GetComponent<house_data>().Greeting;
                        hit.collider.GetComponent<AudioSource>().Play();
                        hit.collider.GetComponent<AudioSource>().loop = false;
                        hit.collider.GetComponent<AudioSource>().volume = 0.8f;
                    }
                }
            }
            else if (hit.collider.tag == "LordMarhem_door" && !LordMarhem_door_flag && !menu_flag)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    LordMarhem_door_flag = true;
                    Temp.current_screen = Temp.screen_name.screen_house;
                    Temp.current_house_tag = hit.collider.tag;
                    GetComponent<AudioSource>().PlayOneShot(Enter_sound);
                    if (hit.collider.GetComponent<house_data>().Greeting != null)
                    {
                        hit.collider.GetComponent<AudioSource>().clip = hit.collider.GetComponent<house_data>().Greeting;
                        hit.collider.GetComponent<AudioSource>().Play();
                        hit.collider.GetComponent<AudioSource>().loop = false;
                        hit.collider.GetComponent<AudioSource>().volume = 0.8f;
                    }
                }
            }
            else if (hit.collider.tag == "cave_door" && !dragon_door_flag && !menu_flag)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    dragon_door_flag = true;
                    Temp.current_screen = Temp.screen_name.screen_house;
                    Temp.current_house_tag = hit.collider.tag;
                    Dangeon_door_flag = true;
                    Temp.CurrentMapName = "emerald_01";
                    Temp.NextMapName = "dragon_cave";
                    Temp.NextLevelID = 2;
                    GameObject.Find("for_events").GetComponent<Video_Player>().video_number = hit.collider.GetComponent<house_data>().video_num;
                    //Application.LoadLevel("Load");
                    //Application.LoadLevel("dragon_cave");
                }
            }
            else if (hit.collider.tag == "moon_door" && !moon_door_flag && !menu_flag)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    moon_door_flag = true;
                    Temp.current_screen = Temp.screen_name.screen_house;
                    Temp.current_house_tag = hit.collider.tag;
                    Dangeon_door_flag = true;
                    Temp.CurrentMapName = "emerald_01";
                    Temp.NextMapName = "Tample_of_moon";
                    Temp.NextLevelID = 8;
                    GameObject.Find("for_events").GetComponent<Video_Player>().video_number = hit.collider.GetComponent<house_data>().video_num;
                    //Application.LoadLevel("Load");
                    //Application.LoadLevel("Tample_of_moon");
                }
            }
            else if (hit.collider.tag == "Item" && !dragon_door_flag && !menu_flag)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    GameObject.Find(hit.collider.name).GetComponent<SpriteRenderer>().enabled = false;
                    uint item_id = 0;
                    switch (hit.collider.name)
                    {
                        case "item001":
                            item_id = 0;
                            break;
                        case "item002":
                            item_id = 1;
                            break;
                        case "item003":
                            item_id = 2;
                            break;
                        case "item004":
                            item_id = 3;
                            break;
                        case "item005":
                            item_id = 4;
                            break;
                        case "item006":
                            item_id = 5;
                            break;
                        case "item007":
                            item_id = 6;
                            break;
                        case "item008":
                            item_id = 7;
                            break;
                        case "item009":
                            item_id = 8;
                            break;
                        case "item010":
                            item_id = 9;
                            break;
                        case "item011":
                            item_id = 10;
                            break;
                        case "item012":
                            item_id = 11;
                            break;
                        case "item013":
                            item_id = 12;
                            break;
                        case "item014":
                            item_id = 13;
                            break;
                        case "item015":
                            item_id = 14;
                            break;
                        case "item016":
                            item_id = 15;
                            break;
                        case "item017":
                            item_id = 16;
                            break;
                        case "item018":
                            item_id = 17;
                            break;
                        case "item019":
                            item_id = 18;
                            break;
                        case "item020":
                            item_id = 19;
                            break;
                        case "item021":
                            item_id = 20;
                            break;
                        case "item022":
                            item_id = 21;
                            break;
                        case "item023":
                            item_id = 22;
                            break;
                        case "item024":
                            item_id = 23;
                            break;
                        case "item025":
                            item_id = 24;
                            break;
                        case "item026":
                            item_id = 25;
                            break;
                        case "item027":
                            item_id = 26;
                            break;
                        case "item028":
                            item_id = 27;
                            break;
                        case "item029":
                            item_id = 28;
                            break;
                        case "item030":
                            item_id = 29;
                            break;
                        case "item031":
                            item_id = 30;
                            break;
                        case "item032":
                            item_id = 31;
                            break;
                        case "item033":
                            item_id = 32;
                            break;
                        case "item034":
                            item_id = 33;
                            break;
                        case "item035":
                            item_id = 34;
                            break;
                        case "item036":
                            item_id = 35;
                            break;
                        case "item037":
                            item_id = 36;
                            break;
                        case "item038":
                            item_id = 37;
                            break;
                        case "item039":
                            item_id = 38;
                            break;
                        case "item040":
                            item_id = 39;
                            break;
                        case "item041":
                            item_id = 40;
                            break;
                        case "item042":
                            item_id = 41;
                            break;
                        case "item043":
                            item_id = 42;
                            break;
                        case "item044":
                            item_id = 43;
                            break;
                        case "item045":
                            item_id = 44;
                            break;
                        case "item046":
                            item_id = 45;
                            break;
                        case "item047":
                            item_id = 46;
                            break;
                        case "item048":
                            item_id = 47;
                            break;
                        case "item049":
                            item_id = 48;
                            break;
                        case "item050":
                            item_id = 49;
                            break;
                        case "item051":
                            item_id = 50;
                            break;
                        case "item052":
                            item_id = 51;
                            break;
                        case "item053":
                            item_id = 52;
                            break;
                        case "item054":
                            item_id = 53;
                            break;
                        case "item055":
                            item_id = 54;
                            break;
                        case "item056":
                            item_id = 55;
                            break;
                        case "item057":
                            item_id = 56;
                            break;
                        case "item058":
                            item_id = 57;
                            break;
                        case "item059":
                            item_id = 38;
                            break;
                        case "item060":
                            item_id = 59;
                            break;
                        case "item061":
                            item_id = 60;
                            break;
                        case "item062":
                            item_id = 61;
                            break;
                        case "item063":
                            item_id = 62;
                            break;
                        case "item064":
                            item_id = 63;
                            break;
                        case "item065":
                            item_id = 64;
                            break;
                        case "item066":
                            item_id = 65;
                            break;
                        case "item067":
                            item_id = 66;
                            break;
                        case "item068":
                            item_id = 67;
                            break;
                        case "item069":
                            item_id = 68;
                            break;
                        case "item070":
                            item_id = 69;
                            break;
                        case "item071":
                            item_id = 70;
                            break;
                        case "item072":
                            item_id = 71;
                            break;
                        case "item073":
                            item_id = 72;
                            break;
                        case "item074":
                            item_id = 73;
                            break;
                        case "item075":
                            item_id = 74;
                            break;
                        case "item076":
                            item_id = 75;
                            break;
                        case "item077":
                            item_id = 76;
                            break;
                        case "item078":
                            item_id = 77;
                            break;
                        case "item079":
                            item_id = 78;
                            break;
                        case "item080":
                            item_id = 79;
                            break;
                        case "item081":
                            item_id = 80;
                            break;
                        case "item082":
                            item_id = 81;
                            break;
                        case "item083":
                            item_id = 82;
                            break;
                        case "item084":
                            item_id = 83;
                            break;
                        case "item085":
                            item_id = 84;
                            break;
                        case "item086":
                            item_id = 85;
                            break;
                        case "item087":
                            item_id = 86;
                            break;
                        case "item088":
                            item_id = 87;
                            break;
                        case "item089":
                            item_id = 88;
                            break;
                        case "item090":
                            item_id = 89;
                            break;
                        case "item091":
                            item_id = 90;
                            break;
                        case "item092":
                            item_id = 91;
                            break;
                        case "item093":
                            item_id = 92;
                            break;
                        case "item094":
                            item_id = 93;
                            break;
                        case "item095":
                            item_id = 94;
                            break;
                        case "item096":
                            item_id = 95;
                            break;
                        case "item097":
                            item_id = 96;
                            break;
                        case "item098":
                            item_id = 97;
                            break;
                        case "item099":
                            item_id = 98;
                            break;
                        case "item100":
                            item_id = 99;
                            break;
                        case "item101":
                            item_id = 100;
                            break;
                        case "item102":
                            item_id = 101;
                            break;
                        case "item103":
                            item_id = 102;
                            break;
                        case "item104":
                            item_id = 103;
                            break;
                        case "item105":
                            item_id = 104;
                            break;
                        case "item106":
                            item_id = 105;
                            break;
                        case "item107":
                            item_id = 106;
                            break;
                        case "item108":
                            item_id = 107;
                            break;
                        case "item109":
                            item_id = 108;
                            break;
                        case "item110":
                            item_id = 109;
                            break;
                        case "item111":
                            item_id = 110;
                            break;
                        case "item112":
                            item_id = 111;
                            break;
                        case "item113":
                            item_id = 112;
                            break;
                        case "item114":
                            item_id = 113;
                            break;
                        case "item115":
                            item_id = 114;
                            break;
                        case "item116":
                            item_id = 115;
                            break;
                        case "item117":
                            item_id = 116;
                            break;
                        case "item118":
                            item_id = 117;
                            break;
                        case "item119":
                            item_id = 118;
                            break;
                        case "item120":
                            item_id = 119;
                            break;
                        case "item121":
                            item_id = 120;
                            break;
                        case "item122":
                            item_id = 121;
                            break;
                        case "item123":
                            item_id = 122;
                            break;
                        case "item124":
                            item_id = 123;
                            break;
                        case "ite125":
                            item_id = 124;
                            break;
                        case "item126":
                            item_id = 125;
                            break;
                        case "item127":
                            item_id = 126;
                            break;
                        case "item128":
                            item_id = 127;
                            break;
                        case "item129":
                            item_id = 128;
                            break;
                        case "item130":
                            item_id = 129;
                            break;
                        case "item131":
                            item_id = 130;
                            break;
                        case "item132":
                            item_id = 131;
                            break;
                        case "item133":
                            item_id = 132;
                            break;
                        case "item134":
                            item_id = 133;
                            break;
                        case "ite135":
                            item_id = 134;
                            break;
                        case "item136":
                            item_id = 135;
                            break;
                        case "item137":
                            item_id = 136;
                            break;
                        case "item138":
                            item_id = 137;
                            break;
                        case "item139":
                            item_id = 138;
                            break;
                        case "item140":
                            item_id = 139;
                            break;
                        case "item141":
                            item_id = 140;
                            break;
                        case "item142":
                            item_id = 141;
                            break;
                        case "item143":
                            item_id = 142;
                            break;
                        case "item144":
                            item_id = 143;
                            break;
                        case "ite145":
                            item_id = 144;
                            break;
                        case "item146":
                            item_id = 145;
                            break;
                        case "item147":
                            item_id = 146;
                            break;
                        case "item148":
                            item_id = 147;
                            break;
                        case "item149":
                            item_id = 148;
                            break;
                        case "item150":
                            item_id = 149;
                            break;
                        case "item151":
                            item_id = 150;
                            break;
                        case "item152":
                            item_id = 151;
                            break;
                        case "item153":
                            item_id = 152;
                            break;
                        case "item154":
                            item_id = 153;
                            break;
                        case "ite155":
                            item_id = 154;
                            break;
                        case "item156":
                            item_id = 155;
                            break;
                        case "item157":
                            item_id = 156;
                            break;
                        case "item158":
                            item_id = 157;
                            break;
                        case "item159":
                            item_id = 158;
                            break;
                        case "item160":
                            item_id = 159;
                            break;
                        case "item161":
                            item_id = 160;
                            break;
                        case "item162":
                            item_id = 161;
                            break;
                        case "item163":
                            item_id = 162;
                            break;
                        case "item164":
                            item_id = 163;
                            break;
                        case "ite165":
                            item_id = 164;
                            break;
                        case "item166":
                            item_id = 165;
                            break;
                        case "item167":
                            item_id = 166;
                            break;
                        case "item168":
                            item_id = 167;
                            break;
                        case "item169":
                            item_id = 168;
                            break;
                        case "item170":
                            item_id = 169;
                            break;
                        case "item171":
                            item_id = 170;
                            break;
                        case "item172":
                            item_id = 171;
                            break;
                        case "item173":
                            item_id = 172;
                            break;
                        case "item174":
                            item_id = 173;
                            break;
                        case "ite175":
                            item_id = 174;
                            break;
                        case "item176":
                            item_id = 175;
                            break;
                        case "item177":
                            item_id = 176;
                            break;
                        case "item178":
                            item_id = 177;
                            break;
                        case "item179":
                            item_id = 178;
                            break;
                        case "item180":
                            item_id = 179;
                            break;
                        case "item181":
                            item_id = 180;
                            break;
                        case "item182":
                            item_id = 181;
                            break;
                        case "item183":
                            item_id = 182;
                            break;
                        case "item184":
                            item_id = 183;
                            break;
                        case "ite185":
                            item_id = 184;
                            break;
                        case "item186":
                            item_id = 185;
                            break;
                        case "item187":
                            item_id = 186;
                            break;
                        case "item188":
                            item_id = 187;
                            break;
                        case "item189":
                            item_id = 188;
                            break;
                        case "item190":
                            item_id = 189;
                            break;
                        case "item191":
                            item_id = 190;
                            break;
                        case "item192":
                            item_id = 191;
                            break;
                        case "item193":
                            item_id = 192;
                            break;
                        case "item194":
                            item_id = 193;
                            break;
                        case "ite195":
                            item_id = 194;
                            break;
                        case "item196":
                            item_id = 195;
                            break;
                        case "item197":
                            item_id = 196;
                            break;
                        case "item198":
                            item_id = 197;
                            break;
                        case "item199":
                            item_id = 198;
                            break;
                        case "item200":
                            item_id = 199;
                            break;
                        case "item201":
                            item_id = 200;
                            break;
                        case "item202":
                            item_id = 201;
                            break;
                        case "item203":
                            item_id = 202;
                            break;
                        case "item204":
                            item_id = 203;
                            break;
                        case "ite205":
                            item_id = 204;
                            break;
                        case "item206":
                            item_id = 205;
                            break;
                        case "item207":
                            item_id = 206;
                            break;
                        case "item208":
                            item_id = 207;
                            break;
                        case "item209":
                            item_id = 208;
                            break;
                        case "item210":
                            item_id = 209;
                            break;
                        case "item211":
                            item_id = 210;
                            break;
                        case "item212":
                            item_id = 211;
                            break;
                        case "item213":
                            item_id = 212;
                            break;
                        case "item214":
                            item_id = 213;
                            break;
                        case "ite215":
                            item_id = 214;
                            break;
                        case "item216":
                            item_id = 215;
                            break;
                        case "item217":
                            item_id = 216;
                            break;
                        case "item218":
                            item_id = 217;
                            break;
                        case "item219":
                            item_id = 218;
                            break;
                        case "item220":
                            item_id = 219;
                            break;
                        case "item221":
                            item_id = 220;
                            break;
                        case "item222":
                            item_id = 221;
                            break;
                        case "item223":
                            item_id = 222;
                            break;
                        case "item224":
                            item_id = 223;
                            break;
                        case "ite225":
                            item_id = 224;
                            break;
                        case "item226":
                            item_id = 225;
                            break;
                        case "item227":
                            item_id = 226;
                            break;
                        case "item228":
                            item_id = 227;
                            break;
                        case "item229":
                            item_id = 228;
                            break;
                        case "item230":
                            item_id = 229;
                            break;
                        case "item231":
                            item_id = 230;
                            break;
                        case "item232":
                            item_id = 231;
                            break;
                        case "item233":
                            item_id = 232;
                            break;
                        case "item234":
                            item_id = 233;
                            break;
                        case "ite235":
                            item_id = 234;
                            break;
                        case "item236":
                            item_id = 235;
                            break;
                        case "item237":
                            item_id = 236;
                            break;
                        case "item238":
                            item_id = 237;
                            break;
                        case "item239":
                            item_id = 238;
                            break;
                        case "item240":
                            item_id = 239;
                            break;
                        case "item241":
                            item_id = 240;
                            break;
                        case "item242":
                            item_id = 241;
                            break;
                        case "item243":
                            item_id = 242;
                            break;
                        case "item244":
                            item_id = 243;
                            break;
                        case "ite245":
                            item_id = 244;
                            break;
                        case "item246":
                            item_id = 245;
                            break;
                        case "item247":
                            item_id = 246;
                            break;
                        case "item248":
                            item_id = 247;
                            break;
                        case "item249":
                            item_id = 248;
                            break;
                        case "item250":
                            item_id = 249;
                            break;
                        case "item251":
                            item_id = 250;
                            break;
                        case "item252":
                            item_id = 251;
                            break;
                        case "item253":
                            item_id = 252;
                            break;
                        case "item254":
                            item_id = 253;
                            break;
                        case "ite255":
                            item_id = 254;
                            break;
                        case "item256":
                            item_id = 255;
                            break;
                        case "item257":
                            item_id = 256;
                            break;
                        case "item258":
                            item_id = 257;
                            break;
                        case "item259":
                            item_id = 258;
                            break;
                        case "item260":
                            item_id = 259;
                            break;
                        case "item261":
                            item_id = 260;
                            break;
                        case "item262":
                            item_id = 261;
                            break;
                        case "item263":
                            item_id = 262;
                            break;
                        case "item264":
                            item_id = 263;
                            break;
                        case "ite265":
                            item_id = 264;
                            break;
                        case "item266":
                            item_id = 265;
                            break;
                        case "item267":
                            item_id = 266;
                            break;
                        case "item268":
                            item_id = 267;
                            break;
                        case "item269":
                            item_id = 268;
                            break;
                        case "item270":
                            item_id = 269;
                            break;
                        case "item271":
                            item_id = 270;
                            break;
                        case "item272":
                            item_id = 271;
                            break;
                        case "item273":
                            item_id = 272;
                            break;
                        case "item274":
                            item_id = 273;
                            break;
                        case "ite275":
                            item_id = 274;
                            break;
                        case "item276":
                            item_id = 275;
                            break;
                        case "item277":
                            item_id = 276;
                            break;
                        case "item278":
                            item_id = 277;
                            break;
                        case "item279":
                            item_id = 278;
                            break;
                        case "item280":
                            item_id = 279;
                            break;
                        case "item281":
                            item_id = 280;
                            break;
                        case "item282":
                            item_id = 281;
                            break;
                        case "item283":
                            item_id = 282;
                            break;
                        case "item284":
                            item_id = 283;
                            break;
                        case "ite285":
                            item_id = 284;
                            break;
                        case "item286":
                            item_id = 285;
                            break;
                        case "item287":
                            item_id = 286;
                            break;
                        case "item288":
                            item_id = 287;
                            break;
                        case "item289":
                            item_id = 288;
                            break;
                        case "item290":
                            item_id = 289;
                            break;
                        case "item291":
                            item_id = 290;
                            break;
                        case "item292":
                            item_id = 291;
                            break;
                        case "item293":
                            item_id = 292;
                            break;
                        case "item294":
                            item_id = 293;
                            break;
                        case "ite295":
                            item_id = 294;
                            break;
                        case "item296":
                            item_id = 295;
                            break;
                        case "item297":
                            item_id = 296;
                            break;
                        case "item298":
                            item_id = 297;
                            break;
                        case "item299":
                            item_id = 298;
                            break;
                        case "item300":
                            item_id = 299;
                            break;
                        case "item301":
                            item_id = 300;
                            break;
                        case "item302":
                            item_id = 301;
                            break;
                        case "item303":
                            item_id = 302;
                            break;
                        case "item304":
                            item_id = 303;
                            break;
                        case "ite305":
                            item_id = 304;
                            break;
                        case "item306":
                            item_id = 305;
                            break;
                        case "item307":
                            item_id = 306;
                            break;
                        case "item308":
                            item_id = 307;
                            break;
                        case "item309":
                            item_id = 308;
                            break;
                        case "item310":
                            item_id = 309;
                            break;
                        case "item311":
                            item_id = 310;
                            break;
                        case "item312":
                            item_id = 311;
                            break;
                        case "item313":
                            item_id = 312;
                            break;
                        case "item314":
                            item_id = 313;
                            break;
                        case "ite315":
                            item_id = 314;
                            break;
                        case "item316":
                            item_id = 315;
                            break;
                        case "item317":
                            item_id = 316;
                            break;
                        case "item318":
                            item_id = 317;
                            break;
                        case "item319":
                            item_id = 318;
                            break;
                        case "item320":
                            item_id = 319;
                            break;
                        case "item321":
                            item_id = 320;
                            break;
                        case "item322":
                            item_id = 321;
                            break;
                        case "item323":
                            item_id = 322;
                            break;
                        case "item324":
                            item_id = 323;
                            break;
                        case "ite325":
                            item_id = 324;
                            break;
                        case "item326":
                            item_id = 325;
                            break;
                        case "item327":
                            item_id = 326;
                            break;
                        case "item328":
                            item_id = 327;
                            break;
                        case "item329":
                            item_id = 328;
                            break;
                        case "item330":
                            item_id = 329;
                            break;
                        case "item331":
                            item_id = 330;
                            break;
                        case "item332":
                            item_id = 331;
                            break;
                        case "item333":
                            item_id = 332;
                            break;
                        case "item334":
                            item_id = 333;
                            break;
                        case "ite335":
                            item_id = 334;
                            break;
                        case "item336":
                            item_id = 335;
                            break;
                        case "item337":
                            item_id = 336;
                            break;
                        case "item338":
                            item_id = 337;
                            break;
                        case "item339":
                            item_id = 338;
                            break;
                        case "item340":
                            item_id = 339;
                            break;
                        case "item341":
                            item_id = 340;
                            break;
                        case "item342":
                            item_id = 341;
                            break;
                        case "item343":
                            item_id = 342;
                            break;
                        case "item344":
                            item_id = 343;
                            break;
                        case "ite345":
                            item_id = 344;
                            break;
                        case "item346":
                            item_id = 345;
                            break;
                        case "item347":
                            item_id = 346;
                            break;
                        case "item348":
                            item_id = 347;
                            break;
                        case "item349":
                            item_id = 348;
                            break;
                        case "item350":
                            item_id = 349;
                            break;
                        case "item351":
                            item_id = 350;
                            break;
                        case "item352":
                            item_id = 351;
                            break;
                        case "item353":
                            item_id = 352;
                            break;
                        case "item354":
                            item_id = 353;
                            break;
                        case "ite355":
                            item_id = 354;
                            break;
                        case "item356":
                            item_id = 355;
                            break;
                        case "item357":
                            item_id = 356;
                            break;
                        case "item358":
                            item_id = 357;
                            break;
                        case "item359":
                            item_id = 358;
                            break;
                        case "item360":
                            item_id = 359;
                            break;
                        case "item361":
                            item_id = 360;
                            break;
                        case "item362":
                            item_id = 361;
                            break;
                        case "item363":
                            item_id = 362;
                            break;
                        case "item364":
                            item_id = 363;
                            break;
                        case "ite365":
                            item_id = 364;
                            break;
                        case "item366":
                            item_id = 365;
                            break;
                        case "item367":
                            item_id = 366;
                            break;
                        case "item368":
                            item_id = 367;
                            break;
                        case "item369":
                            item_id = 368;
                            break;
                        case "item370":
                            item_id = 369;
                            break;
                        case "item371":
                            item_id = 370;
                            break;
                        case "item372":
                            item_id = 371;
                            break;
                        case "item373":
                            item_id = 372;
                            break;
                        case "item374":
                            item_id = 373;
                            break;
                        case "ite375":
                            item_id = 374;
                            break;
                        case "item376":
                            item_id = 375;
                            break;
                        case "item377":
                            item_id = 376;
                            break;
                        case "item378":
                            item_id = 377;
                            break;
                        case "item379":
                            item_id = 378;
                            break;
                        case "item380":
                            item_id = 379;
                            break;
                        case "item381":
                            item_id = 380;
                            break;
                        case "item382":
                            item_id = 381;
                            break;
                        case "item383":
                            item_id = 382;
                            break;
                        case "item384":
                            item_id = 383;
                            break;
                        case "ite385":
                            item_id = 384;
                            break;
                        case "item386":
                            item_id = 385;
                            break;
                        case "item387":
                            item_id = 386;
                            break;
                        case "item388":
                            item_id = 387;
                            break;
                        case "item389":
                            item_id = 388;
                            break;
                        case "item390":
                            item_id = 389;
                            break;
                        case "item391":
                            item_id = 390;
                            break;
                        case "item392":
                            item_id = 391;
                            break;
                        case "item393":
                            item_id = 392;
                            break;
                        case "item394":
                            item_id = 393;
                            break;
                        case "ite395":
                            item_id = 394;
                            break;
                        case "item396":
                            item_id = 395;
                            break;
                        case "item397":
                            item_id = 396;
                            break;
                        case "item398":
                            item_id = 397;
                            break;
                        case "item399":
                            item_id = 398;
                            break;
                        case "item400":
                            item_id = 399;
                            break;
                        case "item401":
                            item_id = 400;
                            break;
                        case "item402":
                            item_id = 401;
                            break;
                        case "item403":
                            item_id = 402;
                            break;
                        case "item404":
                            item_id = 403;
                            break;
                        case "ite405":
                            item_id = 404;
                            break;

                    }
                    item_id = item_id + 1;
                    int item;
                    switch (Temp.ActiveCharacter)
                    {
                        case 1:
                            item = GameObject.Find("Player0").GetComponent<Inventory>().AddItem(Temp.ActiveCharacter, -1, item_id);
                            break;
                        case 2:
                            item = GameObject.Find("Player1").GetComponent<Inventory>().AddItem(Temp.ActiveCharacter, -1, item_id);
                            break;
                        case 3:
                            item = GameObject.Find("Player2").GetComponent<Inventory>().AddItem(Temp.ActiveCharacter, -1, item_id);
                            break;
                        case 4:
                            item = GameObject.Find("Player3").GetComponent<Inventory>().AddItem(Temp.ActiveCharacter, -1, item_id);
                            break;
                        default:
                            Debug.Log("Error in MouseSelect line 101");
                            break;
                    }
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}
