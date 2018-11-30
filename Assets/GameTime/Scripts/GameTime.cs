// <summary>
// GameTime.cs
// 
// This class is responsible of keeping track of in game time. It will also rotate the suns and moons in the sky according to the current in game time.
// This class will also change the skybox from the day skybox to the night skybox as time progresses in game.
// </summary>
using UnityEngine;
using UnityEngine.SceneManagement;

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

	public static event System.Action OnDayChanged;

	/// <summary>
	/// Day/night cycle period in real time minutes
	/// </summary>
	public float dayCycleInMinutes = 1;

	public static bool Paused { get; set; }

	float realSecondToIngameSecond;

	public static GameTime Instance { get; private set; }
	private static SceneSettings sceneSettings;
	private static SceneSettings.Settings currentSceneSettings;

    [RuntimeInitializeOnLoadMethod]
	private static void Initialize()
	{
        Instance = Instantiate(Resources.Load<GameTime>("GameTime"));
        DontDestroyOnLoad(Instance);

		sceneSettings = Resources.Load<SceneSettings>("SceneSettings");

		currentSceneSettings = sceneSettings.GetCurrentSettings();

		SceneManager.activeSceneChanged += (oldScene, newScene) =>
		{
			currentSceneSettings = sceneSettings.GetCurrentSettings();
		};
	}

	private void Start()
	{
        realSecondToIngameSecond = 24 * 60 / dayCycleInMinutes;
	}

	private void Update()
	{
		if (!Paused)
		{
			timeInSeconds += Time.deltaTime * realSecondToIngameSecond * currentSceneSettings.timeScale;

			CheckForDayChange();
		}
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