using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the player transformations.
/// </summary>
public class PlayerTransformer : MonoBehaviour {
	[Header("Animation")]
	public float animationSpeed = 3f;
	public float animationHeight = 0.2f;
	private Vector3 originalPosition;

	[Header("Player")]
	public GameObject targetPlayer;
	private Rigidbody targetRigidBody;

	// Start is called before the first frame update
	void Start() {
		originalPosition = transform.position;
		targetRigidBody = targetPlayer.GetComponent<Rigidbody>();
	}

	void FixedUpdate() {
		// Do the nice animation.
		DoFloatAnimation();
	}

	void OnTriggerEnter(Collider col) {
		// Has the player collided with us?
		if (col.tag == "Player")
			TransformPlayer(col.gameObject);
	}

	/// <summary>
	/// Does a pretty cool floating animation.
	/// </summary>
	void DoFloatAnimation() {
		Vector3 position = transform.position;
		position.y = originalPosition.y +
			(Mathf.Sin(Time.time * animationSpeed) * animationHeight);

		transform.position = position;
	}

	/// <summary>
	/// Transform the player into the target.
	/// </summary>
	/// <param name="player">Player that will be disabled.</param>
	void TransformPlayer(GameObject player) {
		// Ignore the transformation if we already did.
		if (player == targetPlayer)
			return;

		// Get the current player's RigidBody.
		Rigidbody playerRigidBody = player.GetComponent<Rigidbody>();

		// Setup the position of the target player.
		Vector3 position = player.transform.position;
		position.y = targetPlayer.transform.position.y;
		targetPlayer.transform.position = position;

		// Reset the physics of the target player.
		targetRigidBody.velocity = playerRigidBody.velocity;
		targetRigidBody.angularVelocity = playerRigidBody.angularVelocity;

		// Actually switch.
		player.SetActive(false);
		targetPlayer.SetActive(true);
	}
}
