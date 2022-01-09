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
	public int dropSpawnTimer = 2;
	public int randomSeed;

	[Header("Counters")]
	public PointsTracker pointsCounter;
	public SliderHandler dropsCounter;

	private NavMeshAgent agent;
	private int dropTimer;
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

		// Reset the drop timer.
		dropTimer = 0;

		// Make sure the counter is initialized even if inactive.
		pointsCounter.Initialize();
	}

	// Update is called once per frame
	void Update() {
		// Cycle through the waypoints.
		if (IsAtWaypoint())
			GoToNextWaypoint();
	}

	private void FixedUpdate() {
		// Check if its time to start spawning drops.
		if (dropTimer > (dropSpawnTimer * 30))
			RandomlySpawnDrop();

		// Advance the drop timer.
		dropTimer++;
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
		// Randomly spawn shit.
		if (random.Next(20) > 10) {
			// Spawn drop.
			GameObject cholesterol = Instantiate(dropPrefab, transform.position,
				transform.rotation);
			EnemyDrop drop = cholesterol.GetComponent<EnemyDrop>();

			// Count one for the team.
			dropsCounter.CountUp();

			// Assign counters.
			drop.PointsCounter = pointsCounter;
			drop.DropsCounter = dropsCounter;
		}

		// Reset the drop timer.
		dropTimer = 0;
	}
}
