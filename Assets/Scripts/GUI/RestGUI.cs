using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestGUI : MonoBehaviour
{
    [SerializeField] Text timeText;
    [SerializeField] Text dayText;
    [SerializeField] Text monthText;
    [SerializeField] Text yearText;

    void OnEnable()
    {
        UpdateGUI();
        GameTime.Paused = true;
    }

    void OnDisable()
    {
        GameTime.Paused = false;
    }

    void UpdateGUI()
    {
        int hours = Mathf.FloorToInt(GameTime.TimeInHours);
        int minutes = Mathf.FloorToInt((GameTime.TimeInHours - hours) * 60);

        Debug.Log("hours = " + hours);
        Debug.Log("GameTime.TimeInHours = " + GameTime.TimeInHours);
        Debug.Log("minutes = " + minutes);

        if (minutes < 10)
        {
            timeText.text = hours.ToString() + ":0" + minutes;
        }
        else
        {
            timeText.text = hours.ToString() + ":" + minutes;
        }

        dayText.text = GameTime.CurrentDay.ToString();
        monthText.text = GameTime.CurrentMonth.ToString();
        yearText.text = GameTime.CurrentYear.ToString();
    }

    public void Wait5Minutes()
    {
        GameTime.Wait5Minutes();

        UpdateGUI();
    }

    public void Wait1Hour()
    {
        GameTime.Wait1Hour();

        UpdateGUI();
    }

    public void WaitUntilDawn()
    {
        GameTime.WaitUntilDawn();

        UpdateGUI();
    }
}
