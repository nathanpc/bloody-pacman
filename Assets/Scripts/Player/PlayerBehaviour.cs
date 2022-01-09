using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the player behavior and what they can kill.
/// </summary>
public class PlayerBehaviour : MonoBehaviour {
	[SerializeField] private string _killsDropNamed;

	/// <summary>
	/// This player kills which kind of drops?
	/// </summary>
	public string KillsDropNamed {
		get { return _killsDropNamed; }
		set { _killsDropNamed = value; }
	}
}
