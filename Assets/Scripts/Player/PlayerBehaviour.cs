using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {
	public string _killsDropNamed;

	public string KillsDropNamed {
		get { return _killsDropNamed; }
		set { _killsDropNamed = value; }
	}
}
