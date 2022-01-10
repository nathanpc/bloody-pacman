using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player controller abstraction class for a mobile touchscreen controller.
/// </summary>
public class MobilePlayerController : MonoBehaviour, IPlayerController {
	private Vector3 touchStartPosition;
	private float touchSpeedCompensation = 0.005f;

	public float HorizontalMovement() {
		if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch(0);

			switch (touch.phase) {
			case TouchPhase.Began:
				touchStartPosition = touch.position;
				break;
			case TouchPhase.Moved:
				return (touch.position.x - touchStartPosition.x) *
					touchSpeedCompensation;
			case TouchPhase.Ended:
				break;
			}
		}

		return 0f;
	}

	public float VerticalMovement() {
		// Check if this is the first touch.
		if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch(0);

			switch (touch.phase) {
			case TouchPhase.Began:
				touchStartPosition = touch.position;
				break;
			case TouchPhase.Moved:
				return (touch.position.y - touchStartPosition.y) *
					touchSpeedCompensation;
			case TouchPhase.Ended:
				break;
			}
		}

		return 0f;
	}

	public bool Escape() {
		return false;
	}
}
