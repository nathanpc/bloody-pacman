using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyBehaviour : MonoBehaviour {
	public GameObject waypointContainer;
	public GameObject cholesterolPrefab;
	public GameObject pointsText;
	public int cholesterolSpawnTimer = 2;
	private NavMeshAgent agent;
	private int timer;

	// Start is called before the first frame update
	void Start() {
		if (waypointContainer == null)
			throw new Exception("Waypoint container is required");

		agent = GetComponent<NavMeshAgent>();
		agent.SetDestination(waypointContainer.transform.position);

		timer = 0;
	}

	// Update is called once per frame
	void Update() {
		if (IsAtWaypoint())
			GoToNextWaypoint();
	}

	private void FixedUpdate() {
		if (timer > (cholesterolSpawnTimer * 30))
			RandomlySpawnCholesterol();

		timer++;
	}

	private void GoToNextWaypoint() {
		int index = new System.Random().Next(waypointContainer.transform.childCount - 1);
		agent.SetDestination(waypointContainer.transform.GetChild(index).position);
	}

	private bool IsAtWaypoint() {
		return Vector3.Distance(transform.position, agent.destination) < 1.0f;
	}

	private void RandomlySpawnCholesterol() {
		if (new System.Random().Next(20) > 18) {
			GameObject cholesterol = Instantiate(cholesterolPrefab, transform.position, transform.rotation);
			cholesterol.GetComponent<EnemyDrop>().PointsTextField = pointsText;
		}
	}
}
