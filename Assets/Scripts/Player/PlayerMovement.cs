using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour {
	[Header("Speed")]
	public float movementSpeed = 5f;
	public float rotationSpeed = 3f;

	public IPlayerController controller;
	private Rigidbody rigidBody;

	// Start is called before the first frame update
	void Start() {
		// Set simple stuff up.
		rigidBody = GetComponent<Rigidbody>();
	}

	void FixedUpdate() {
		/*
		// Determine the player's cardinal direction.
		if (controller.HorizontalMovement() < 0f) {
			transform.localEulerAngles = new Vector3(0, -90, 0);
		} else if (controller.HorizontalMovement() > 0f) {
			transform.localEulerAngles = new Vector3(0, 90, 0);
		} else if (controller.VerticalMovement() < 0f) {
			transform.localEulerAngles = new Vector3(0, -180, 0);
		} else if (controller.VerticalMovement() > 0f) {
			transform.localEulerAngles = new Vector3(0, 0, 0);
		}
		*/
		
		// Rotate around.
		transform.Rotate(0, controller.HorizontalMovement() * rotationSpeed, 0);

		// Keep the player moving forward.
		Vector3 forward = transform.TransformDirection(Vector3.forward) * controller.VerticalMovement();
		rigidBody.AddForce(forward * movementSpeed, ForceMode.VelocityChange);

		/*
		// Move the player with physics.
		Vector3 direction = new Vector3(controller.HorizontalMovement(), 0,
			controller.VerticalMovement());
		rigidBody.AddForce(direction * movementSpeed, ForceMode.VelocityChange);
		*/
	}
}
