using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsTracker : MonoBehaviour {
	private Text textField;
	private int counter = 0;

	// Start is called before the first frame update
	void Start() {
		textField = GetComponent<Text>();
		UpdateCounterText();
	}

	public void CountUp() {
		counter++;
		UpdateCounterText();
	}

	public void CountDown() {
		if (counter > 0)
			counter--;

		UpdateCounterText();
	}

	private void UpdateCounterText() {
		textField.text = counter.ToString();
	}
}
