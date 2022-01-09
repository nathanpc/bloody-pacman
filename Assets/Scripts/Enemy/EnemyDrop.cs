using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages a dropped item.
/// </summary>
public class EnemyDrop : MonoBehaviour {
	[Header("General")]
	public new string name;

	[Header("Destroying Animation")]
	public ParticleSystem particles;
	public float dieSpeed = 0.03f;

	private GameObject _pointsText;
	private PointsTracker tracker;
	private bool isDying = false;

	void FixedUpdate() {
		// Check if the drop is dying.
		if (isDying) {
			// Linearly scale down.
			float scale = transform.localScale.x;
			scale -= dieSpeed;

			// Bottom out the scale.
			if (scale < 0)
				scale = 0;

			transform.localScale = new Vector3(scale, scale, scale);
		}
	}

	void OnTriggerEnter(Collider col) {
		// If we are not tracking, then just ignore this.
		if (tracker == null)
			return;

		// Check if the player actually collided with us.
		if (col.tag == "Player") {
			// If the player that collided isn't active then ignore it.
			if (!col.gameObject.activeInHierarchy)
				return;

			// Check if the player that collided is actually supposed to destroy us.
			if (col.GetComponent<PlayerBehaviour>().KillsDropNamed != name)
				return;

			// Count up the score.
			tracker.CountUp();

			// Do a whole dance.
			particles.Play();
			StartCoroutine(WaitToDie());
		}
	}

	/// <summary>
	/// Points tracker label.
	/// </summary>
	public GameObject PointsTextField {
		get { return _pointsText; }
		set {
			_pointsText = value;
			tracker = _pointsText.GetComponent<PointsTracker>();
		}
	}

	/// <summary>
	/// Coroutine function to wait for the particle effect to end before dying.
	/// </summary>
	IEnumerator WaitToDie() {
		isDying = true;

		// Wait for the particle show to stop.
		while (particles.isPlaying)
			yield return new WaitForSeconds(1);
		
		// Die.
		Destroy(gameObject);
	}
}
