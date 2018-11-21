using UnityEngine;
using System.Collections;
using System.IO;

public class TextReader : MonoBehaviour {
    public string filePath;
    private string text = " ";

    // Use this for initialization

    void Start()
    {
        LoadFile();
    }

    void LoadFile()
    {
        string name;
        int i = -2;
        StreamReader reader = new StreamReader(filePath);

        while (text != null)
        {
            i++;
            name = gameObject.name;
            text = reader.ReadLine();
            text = text.Substring(2, 7);
            if (text == name)
            {
                text = reader.ReadLine();

                /*numItem = int.Parse(text);

                for (int i = 0; i < numItem; i++)
                {
                    text = reader.ReadLine();

                    planNameOwnImprov[i, 0] = text;
                    planNameOwnImprov[i, 1] = "no";
                    planNameOwnImprov[i, 2] = "poor";
                }*/

                break;
            }
        }
    }
}
