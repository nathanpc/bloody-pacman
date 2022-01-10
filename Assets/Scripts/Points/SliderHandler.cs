using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles the drop slider counter UI elements.
/// </summary>
public class SliderHandler : MonoBehaviour, ICounter {
	[Header("UI Elements")]
	public Slider slider;
	public Image fill;

	[Header("Counter")]
	public int maxValue = 100;
	private int counter = 0;

	[Header("Misc.")]
	public GameStateManager gameStateManager;

	/// <summary>
	/// Updates the slider control.
	/// </summary>
	public void UpdateSlider() {
		// Calculate the percentage value.
		float value = (float)counter / (float)maxValue;

		// Make sure there's a ceilling for the value.
		if (value > 0.98f)
			value = 1f;

		// Update the UI elements.
		slider.value = value;
		fill.fillAmount = value;

		// Check if we are over.
		if (value == 1f)
			gameStateManager.GameOver();
	}

	public void CountUp() {
		counter++;
		UpdateSlider();
	}

	public void CountDown() {
		// Only count down if we actually can.
		if (counter > 0)
			counter--;

		// Update the slider.
		UpdateSlider();
	}
}
