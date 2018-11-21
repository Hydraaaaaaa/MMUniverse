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

    [SerializeField] float waitDayDurationInSeconds = 3;

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
        StartCoroutine(Wait(GameTime.MINUTE * 5));

        UpdateGUI();
    }

    public void Wait1Hour()
    {
        StartCoroutine(Wait(GameTime.HOUR));

        UpdateGUI();
    }

    public void WaitUntilDawn()
    {
        float duration = (GameTime.HOUR * 5) - GameTime.TimeInSeconds + 0.1f;

        if (duration <= 0)
        {
            duration += GameTime.DAY;
        }

        StartCoroutine(Wait(duration));

        UpdateGUI();
    }

    IEnumerator Wait(float seconds)
    {
        while (seconds > 0)
        {
            float change = Time.deltaTime * GameTime.DAY / waitDayDurationInSeconds;

            if (change > seconds)
            {
                change = seconds;
            }

            seconds -= change;
            GameTime.TimeInSeconds += change;

            UpdateGUI();

            yield return null;
        }
    }
}
