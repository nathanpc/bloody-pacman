using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyBehaviour : MonoBehaviour {
	[Header("Waypoints")]
	public GameObject waypointContainer;

	[Header("Drops")]
	public GameObject dropPrefab;
	public GameObject pointsText;
	public int dropSpawnTimer = 2;
	public int randomSeed;

	private NavMeshAgent agent;
	private int startupTimer;
	private System.Random random;

	// Start is called before the first frame update
	void Start() {
		// Do we actually have waypoints?
		if (waypointContainer == null)
			throw new Exception("Waypoint container is required");

		// Grab and set various static things.
		random = new System.Random(randomSeed);
		agent = GetComponent<NavMeshAgent>();
		agent.SetDestination(waypointContainer.transform.position);

		// Reset the startup timer.
		startupTimer = 0;
	}

	// Update is called once per frame
	void Update() {
		// Cycle through the waypoints.
		if (IsAtWaypoint())
			GoToNextWaypoint();
	}

	private void FixedUpdate() {
		// Check if its time to start spawning drops.
		if (startupTimer > (dropSpawnTimer * 30)) {
			RandomlySpawnDrop();
		} else {
			// Advance the startup timer.
			startupTimer++;
		}
	}

	/// <summary>
	/// Make the object go somewhere.
	/// </summary>
	private void GoToNextWaypoint() {
		// Go places randomly.
		int index = random.Next(waypointContainer.transform.childCount - 1);
		agent.SetDestination(waypointContainer.transform.GetChild(index).position);
	}

	/// <summary>
	/// Check if we have already arrived at the currently set waypoint.
	/// </summary>
	/// <returns>Are we there yet?</returns>
	private bool IsAtWaypoint() {
		return Vector3.Distance(transform.position, agent.destination) < 1.0f;
	}

	/// <summary>
	/// Randomly spawns drops.
	/// </summary>
	private void RandomlySpawnDrop() {
		if (random.Next(20) > 18) {
			GameObject cholesterol = Instantiate(dropPrefab, transform.position, transform.rotation);
			cholesterol.GetComponent<EnemyDrop>().PointsTextField = pointsText;
		}
	}
}
