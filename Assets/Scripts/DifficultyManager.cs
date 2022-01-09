using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the game difficulty.
/// </summary>
public class DifficultyManager : MonoBehaviour {
	[Header("Counters and Stuff")]
	public SliderHandler cholesterolCounter;
	public SliderHandler sugarCounter;
	public int maxDrops = 100;

	[Header("Enemies")]
	public EnemyBehaviour hamburger;
	public EnemyBehaviour iceCream;
	public int dropTimer = 2;

	[Header("Player")]
	public PlayerMovement broccoli;
	public PlayerMovement sugarDaddy;
	public float force = 25f;
	public float rotationStep = 0.1f;

	void Start() {
		// Setup counters.
		cholesterolCounter.maxValue = maxDrops;
		sugarCounter.maxValue = maxDrops;

		// Setup enemies.
		hamburger.dropSpawnTimer = dropTimer;
		iceCream.dropSpawnTimer = dropTimer;

		// Setup player.
		broccoli.force = force;
		broccoli.rotationStep = rotationStep;
		sugarDaddy.force = force;
		sugarDaddy.rotationStep = rotationStep;
	}
}
