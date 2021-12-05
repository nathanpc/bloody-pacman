using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour {
	public float force = 200f;
	private Rigidbody rigidBody;

	// Start is called before the first frame update
	void Start() {
		rigidBody = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update() {
		Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		rigidBody.AddForce(direction * force);
	}
}
