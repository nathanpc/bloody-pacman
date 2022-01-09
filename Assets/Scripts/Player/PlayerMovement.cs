using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerBehaviour))]
public class PlayerMovement : MonoBehaviour {
	public float force = 200f;
	public float rotationStep = 1.0f;
	private Rigidbody rigidBody;
	private new Camera camera;
	private Quaternion originalCameraRotation;

	// Start is called before the first frame update
	void Start() {
		camera = Camera.main;
		originalCameraRotation = camera.transform.localRotation;

		rigidBody = GetComponent<Rigidbody>();
	}

	void FixedUpdate() {
		Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0,
			Input.GetAxis("Vertical"));
		rigidBody.AddForce(direction * force);

		Quaternion cameraTilt = originalCameraRotation;
		cameraTilt.y += Input.GetAxis("Horizontal") * 0.05f;
		cameraTilt.x += Input.GetAxis("Vertical") * -0.05f;

		camera.transform.localRotation = Quaternion.Lerp(
			camera.transform.localRotation, cameraTilt, rotationStep);
	}
}
