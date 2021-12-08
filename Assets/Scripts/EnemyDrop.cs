using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrop : MonoBehaviour {
	public ParticleSystem particles;
	public float dieSpeed = 0.03f;
	private GameObject _pointsText;
	private PointsTracker tracker;
	private bool isDying = false;

	void FixedUpdate() {
		if (isDying) {
			float scale = transform.localScale.x;
			scale -= dieSpeed;

			if (scale < 0)
				scale = 0;

			transform.localScale = new Vector3(scale, scale, scale);
		}
	}

	void OnTriggerEnter(Collider col) {
		if (tracker == null)
			return;

		if (col.tag == "Player") {
			tracker.CountUp();
			particles.Play();
			StartCoroutine(WaitToDie());
		}
	}

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
