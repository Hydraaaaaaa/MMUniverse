using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyDataC : MonoBehaviour
{
    [System.Serializable]
    public class Body
    {
        public int face_id;
        public enum sex
        {
            Male = 0,
            Women = 1,
        }
        public sex SexType;
        public enum race
        {
            Man = 0,
            Dwarf = 1,
            Elf = 3,
            Goblin = 4,
        }
        public race RaceType;
        public Texture2D[] Body_parts = new Texture2D[6];
    }

    [System.Serializable]
    public class Aqualang
    {
        public enum sex
        {
            Male = 0,
            Women = 1,
        }
        public sex SexType;
        public Texture2D[] Aqualang_parts = new Texture2D[6];
    }
    public Body[] Bodies = new Body[24];
    public Aqualang[] Aqualangs = new Aqualang[4];
}
