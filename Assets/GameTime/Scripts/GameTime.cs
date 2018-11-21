// <summary>
// GameTime.cs
// 
// This class is responsible of keeping track of in game time. It will also rotate the suns and moons in the sky according to the current in game time.
// This class will also change the skybox from the day skybox to the night skybox as time progresses in game.
// </summary>
using UnityEngine;

[AddComponentMenu("Day-Night Cycle/GameTime")]
public class GameTime : MonoBehaviour
{
	public const float MINUTE = 60; // constant for how many seconds in a minute
	public const float HOUR = 60 * MINUTE; // constant for how many seconds in an hour
	public const float DAY = 24 * HOUR; // constant for how many seconds in a day
	
	public const int STARTING_YEAR = 1168;

    public static int CurrentDay { get { return currentDay; } }
    public static int CurrentMonth { get { return currentMonth; } }
    public static int CurrentYear { get { return currentYear; } }

	private static int currentDay = 1;
	private static int currentMonth = 1;
	private static int currentYear = STARTING_YEAR;

	public EnvironmentState currentEnvironmentState { get; private set; }
	private TimeOfDayTransition currentTransition;
	private EnvironmentState sourceEnvironmentState;

	private Light sunLight;

	/// <summary>
	/// Current time in seconds
	/// </summary>
	public static float TimeInSeconds
	{
		get { return timeInSeconds; }
		set { timeInSeconds = value; CheckForDayChange(); }
	}

	private static float timeInSeconds;

	/// <summary>
	/// Current time in hours
	/// </summary>
	public static float TimeInHours
	{
		get { return timeInSeconds / HOUR; }
		set { timeInSeconds = value * HOUR; CheckForDayChange(); }
	}

	public Camera playerCamera;
	public Transform attachedTo;

	public Transform sun;
	public Transform moon;

	public static event System.Action OnDayChanged;

	public TimeOfDayTransition[] timeOfDayTransitions;
	public int InitialStateIndex;

	/// <summary>
	/// Day/night cycle period in real time minutes
	/// </summary>
	public float dayCycleInMinutes = 1;

	public static bool Paused { get; set; }

	float realSecondToIngameSecond;

	private void Start()
	{
		sunLight = sun.GetComponentInChildren<Light>();

		if (InitialStateIndex >= 0 && InitialStateIndex < timeOfDayTransitions.Length)
		{
			currentTransition = timeOfDayTransitions[InitialStateIndex];
		}
		else
		{
			currentTransition = timeOfDayTransitions[0];
		}

		sourceEnvironmentState = GetEnvironmentStateFromTransition(currentTransition);
		ApplyEnvironmentState(sourceEnvironmentState);

        realSecondToIngameSecond = 24 * 60 / dayCycleInMinutes;
	}

	private EnvironmentState ReadEnvironmentState()
	{
		var env = new EnvironmentState
		          {
		          		ambientLight = RenderSettings.ambientLight,
                        moonTintColor = moon.gameObject.GetComponent<Renderer>().material.GetColor("_Color"),
		          		fogColor = RenderSettings.fogColor,
		          		fogDensity = RenderSettings.fogDensity,
		          		sunColor = sunLight.color,
		          		sunIntensity = sunLight.intensity,
                        sunTintColor = sun.gameObject.GetComponent<Renderer>().material.GetColor("_TintColor"),
		          		skyboxBlendValue = RenderSettings.skybox.GetFloat("_Blend"),
		          		skyboxTintColor = RenderSettings.skybox.GetColor("_Tint"),
		          };

		if (currentEnvironmentState != null)
		{
			env.auxColor1 = currentEnvironmentState.auxColor1;
			env.auxColor2 = currentEnvironmentState.auxColor2;
		}
		else
		{
			env.auxColor1 = Color.black;
			env.auxColor2 = Color.black;
		}

		return env;
	}

	private void ApplyEnvironmentState(EnvironmentState env)
	{
		RenderSettings.ambientLight = env.ambientLight;

        moon.gameObject.GetComponent<Renderer>().material.SetColor("_Color", env.moonTintColor);

		RenderSettings.fogColor = env.fogColor;
		RenderSettings.fogDensity = env.fogDensity;
		RenderSettings.fog = Mathf.Abs(env.fogDensity) > Mathf.Epsilon;

		RenderSettings.skybox.SetFloat("_Blend", env.skyboxBlendValue);
		RenderSettings.skybox.SetColor("_Tint", env.skyboxTintColor);

		sunLight.color = env.sunColor;
		sunLight.intensity = env.sunIntensity;
        sun.gameObject.GetComponent<Renderer>().material.SetColor("_TintColor", env.sunTintColor);

		currentEnvironmentState = env;
	}

	private void Update()
	{
		// Update time
		if (!Paused)
		{
			timeInSeconds += Time.deltaTime * realSecondToIngameSecond;

			CheckForDayChange();
		}

		// Update Sun and Moon position
		transform.rotation = Quaternion.Euler(new Vector3(360 / DAY * timeInSeconds, 0, 0));

		if (playerCamera != null)
		{
			transform.position = attachedTo.position;

			var ambient = sunLight.color * sunLight.intensity;
			playerCamera.backgroundColor = ambient;
		}

		// Update environment state
		if (currentTransition == null)
		{
			currentTransition = FindActiveTransition(timeInSeconds);
			if (currentTransition != null)
			{
				sourceEnvironmentState = ReadEnvironmentState();
			}
		}

		if (currentTransition != null)
		{
			ApplyCurrentTransition();
		}
	}

	private static EnvironmentState GetEnvironmentStateFromTransition(TimeOfDayTransition t)
	{
		var env = new EnvironmentState
		          {
		          		ambientLight = t.ambientLight,
		          		moonTintColor = t.moonTintColor,
		          		sunColor = t.sunColor,
		          		sunIntensity = t.sunIntensity,
		          		sunTintColor = t.sunTintColor,
		          		fogColor = t.fogColor,
		          		fogDensity = t.fogDensity,
		          		skyboxBlendValue = t.skyboxBlendValue,
		          		skyboxTintColor = t.skyboxTintColor,
		          		auxColor1 = t.auxColor1,
		          		auxColor2 = t.auxColor2,
		          };
		return env;
	}

	private void ApplyCurrentTransition()
	{
		var s = sourceEnvironmentState;
		var t = currentTransition;

		var currentTime = TimeInHours;
		if (currentTime - t.startHour < 0)
		{
			currentTime += 24;
		}

		var x = (currentTime - t.startHour) / t.durationInHours;
		if (x > 1)
		{
			x = 1;

			currentTransition = null;
		}

		//Debug.Log(x);

		var env = new EnvironmentState
		          {
		          		ambientLight = Color.Lerp(s.ambientLight, t.ambientLight, x),
		          		moonTintColor = Color.Lerp(s.moonTintColor, t.moonTintColor, x),
		          		sunColor = Color.Lerp(s.sunColor, t.sunColor, x),
		          		sunIntensity = Mathf.Lerp(s.sunIntensity, t.sunIntensity, x),
		          		sunTintColor = Color.Lerp(s.sunTintColor, t.sunTintColor, x),
		          		fogColor = Color.Lerp(s.fogColor, t.fogColor, x),
		          		fogDensity = Mathf.Lerp(s.fogDensity, t.fogDensity, x),
		          		skyboxBlendValue = Mathf.Lerp(s.skyboxBlendValue, t.skyboxBlendValue, x),
		          		skyboxTintColor = Color.Lerp(s.skyboxTintColor, t.skyboxTintColor, x),
		          		auxColor1 = Color.Lerp(s.auxColor1, t.auxColor1, x),
		          		auxColor2 = Color.Lerp(s.auxColor2, t.auxColor2, x),
		          };

		ApplyEnvironmentState(env);
	}

	private TimeOfDayTransition FindActiveTransition(float seconds)
	{
		var hours = seconds / HOUR;
		foreach (var transition in timeOfDayTransitions)
		{
			if (transition.enabled
			    && hours > transition.startHour
			    && (hours - transition.startHour) < transition.durationInHours)
			{
				return transition;
			}
		}

		return null;
	}

	static void CheckForDayChange()
	{
		if (timeInSeconds >= DAY)
		{
			ChangeDay();
		}
	}

	static void ChangeDay()
	{
        timeInSeconds -= DAY;
        currentDay++;

        if (currentDay > 30)
        {
            currentDay = 1;
            currentMonth++;
        }

        if (currentMonth > 12)
        {
            currentMonth = 1;
            currentYear++;
        }

        OnDayChanged?.Invoke();
	}
}