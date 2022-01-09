using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the transportation of the player to the other side of the map.
/// </summary>
public class PlayerTransporter : MonoBehaviour {
	public GameObject teleportLocation;

	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {

	}

	void OnTriggerEnter(Collider col) {
		// Check if the player actually collided with us.
		if (col.tag == "Player") {
			// If the player that collided isn't active then ignore it.
			if (!col.gameObject.activeInHierarchy)
				return;

			// Teleport the player.
			col.gameObject.transform.position = teleportLocation.transform.position;
		}
	}
}
