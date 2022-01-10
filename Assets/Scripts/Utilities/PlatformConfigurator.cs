using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A little utility class to help configure some platform-specific behaviour
/// and tailor the game to each platform.
/// </summary>
public class PlatformConfigurator : MonoBehaviour {
	[Header("Controllers")]
	public DesktopPlayerController desktopController;
	public MobilePlayerController mobileController;

	[Header("Player")]
	public PlayerMovement broccoli;
	public PlayerMovement sugarDaddy;

	// Start is called before the first frame update
	void Start() {
		// Determine the optimal configuration based on the runtime platform.
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
	/// Sets up everything to run on a desktop.
	/// </summary>
	public void SetupForDesktop() {
		// Controller.
		broccoli.controller = desktopController;
		sugarDaddy.controller = desktopController;
	}

	/// <summary>
	/// Sets up everything to run on a mobile device.
	/// </summary>
	public void SetupForMobile() {
		// Controller.
		broccoli.controller = mobileController;
		sugarDaddy.controller = mobileController;
	}
}
