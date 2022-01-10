using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player controller abstraction class for a "normal" computer controller,
/// aka keyboard and mouse.
/// </summary>
public class DesktopPlayerController : MonoBehaviour, IPlayerController {
	public float HorizontalMovement() {
		return Input.GetAxis("Horizontal");
	}

	public float VerticalMovement() {
		return Input.GetAxis("Vertical");
	}

	public bool Escape() {
		return Input.GetButtonDown("Cancel");
	}
}
