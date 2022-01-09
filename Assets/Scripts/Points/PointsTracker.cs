using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Keeps track of points.
/// </summary>
public class PointsTracker : MonoBehaviour, ICounter {
	private Text textField;
	private int counter = 0;

	// Start is called before the first frame update
	void Start() {
		Initialize();
	}

	/// <summary>
	/// Makes sure things are properly initialized.
	/// </summary>
	public void Initialize() {
		textField = GetComponent<Text>();
		UpdateCounterText();
	}

	/// <summary>
	/// Updates the counter label.
	/// </summary>
	private void UpdateCounterText() {
		textField.text = counter.ToString();
	}

	public void CountUp() {
		counter++;
		UpdateCounterText();
	}

	public void CountDown() {
		// Only count down if we actually can.
		if (counter > 0)
			counter--;

		// Update the label.
		UpdateCounterText();
	}
}
