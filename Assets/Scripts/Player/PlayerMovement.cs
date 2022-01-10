using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerBehaviour))]
public class PlayerMovement : MonoBehaviour {
	[Header("Speed")]
	public float force = 200f;
	public float rotationStep = 1.0f;

	[Header("Camera Movement")]
	public bool moveCamera = false;
	public float cameraMovementIntensity = 0.05f;

	public IPlayerController controller;

	private Rigidbody rigidBody;
	private new Camera camera;
	private Quaternion originalCameraRotation;

	// Start is called before the first frame update
	void Start() {
		// Set simple stuff up.
		camera = Camera.main;
		originalCameraRotation = camera.transform.localRotation;
		rigidBody = GetComponent<Rigidbody>();
	}

	void FixedUpdate() {
		// Move the player with physics.
		Vector3 direction = new Vector3(controller.HorizontalMovement(), 0,
			controller.VerticalMovement());
		rigidBody.AddForce(direction * force);

		// Should we move the camera?
		if (moveCamera) {
			Quaternion cameraTilt = originalCameraRotation;
			cameraTilt.y += controller.HorizontalMovement() *
				cameraMovementIntensity;
			cameraTilt.x += controller.VerticalMovement() *
				(cameraMovementIntensity * -1);

			camera.transform.localRotation = Quaternion.Lerp(
				camera.transform.localRotation, cameraTilt, rotationStep);
		}
	}
}
