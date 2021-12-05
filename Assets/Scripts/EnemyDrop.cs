using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrop : MonoBehaviour {
	private GameObject _pointsText;
	private PointsTracker tracker;

	// Start is called before the first frame update
	void Start() {
	}

	// Update is called once per frame
	void Update() {

	}

	void OnTriggerEnter(Collider col) {
		if (tracker == null)
			return;

		if (col.tag == "Player") {
			tracker.CountUp();
			Destroy(gameObject);
		}
	}

	public GameObject PointsTextField {
		get { return _pointsText; }
		set {
			_pointsText = value;
			tracker = _pointsText.GetComponent<PointsTracker>();
		}
	}
}
