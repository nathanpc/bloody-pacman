using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A little utility class to help configure the gameplay and some
/// platform-specific behaviour to tailor the game to each platform.
/// </summary>
[RequireComponent(typeof(GameStateManager))]
public class GameConfigurator : MonoBehaviour {
	protected GameStateManager gameStateManager;

	[Header("Controllers")]
	public DesktopPlayerController desktopController;
	public MobilePlayerController mobileController;

	[Header("Counters and Stuff")]
	public SliderHandler cholesterolCounter;
	public SliderHandler sugarCounter;
	public int maxDrops = 100;

	[Header("Enemies")]
	public EnemyBehaviour hamburger;
	public EnemyBehaviour iceCream;
	public int dropTimer = 1;

	[Header("Player")]
	public PlayerMovement broccoli;
	public PlayerMovement sugarDaddy;
	public float force = 25f;
	public float rotationStep = 0.1f;

	// Start is called before the first frame update
	void Start() {
		gameStateManager = GetComponent<GameStateManager>();

		SetupPlatformAutomatically();
		SetupGame();
	}

	/// <summary>
	/// Determine the optimal configuration based on the runtime platform.
	/// </summary>
	protected void SetupPlatformAutomatically() {
		switch (Application.platform) {
		// Desktop
		case RuntimePlatform.OSXEditor:
		case RuntimePlatform.OSXPlayer:
		case RuntimePlatform.LinuxEditor:
		case RuntimePlatform.LinuxPlayer:
		case RuntimePlatform.WindowsEditor:
		case RuntimePlatform.WindowsPlayer:
			SetupForDesktop();
			break;
		// Mobile
		case RuntimePlatform.IPhonePlayer:
		case RuntimePlatform.Android:
			SetupForMobile();
			break;
		// Others
		default:
			throw new System.Exception("Unsupported platform. Please implement it in " +
				"the PlatformConfigurator.");
		}
	}

	/// <summary>
	/// Actually sets up the game play.
	/// </summary>
	protected void SetupGame() {
		// Setup counters.
		cholesterolCounter.maxValue = maxDrops;
		cholesterolCounter.gameStateManager = gameStateManager;
		sugarCounter.maxValue = maxDrops;
		sugarCounter.gameStateManager = gameStateManager;

		// Setup enemies.
		hamburger.dropSpawnTimer = dropTimer;
		hamburger.GameManager = gameStateManager;
		iceCream.dropSpawnTimer = dropTimer;
		iceCream.GameManager = gameStateManager;

		// Setup player.
		broccoli.force = force;
		broccoli.rotationStep = rotationStep;
		sugarDaddy.force = force;
		sugarDaddy.rotationStep = rotationStep;
	}

	/// <summary>
	/// Sets up everything to run on a desktop.
	/// </summary>
	protected void SetupForDesktop() {
		// Controller.
		broccoli.controller = desktopController;
		sugarDaddy.controller = desktopController;
	}

	/// <summary>
	/// Sets up everything to run on a mobile device.
	/// </summary>
	protected void SetupForMobile() {
		// Controller.
		broccoli.controller = mobileController;
		sugarDaddy.controller = mobileController;
	}
}
