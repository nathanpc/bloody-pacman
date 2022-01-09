using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A common interface for counting things.
/// </summary>
public interface ICounter {
	/// <summary>
	/// Count points up.
	/// </summary>
	public void CountUp();

	/// <summary>
	/// Decrease the points.
	/// </summary>
	public void CountDown();
}
