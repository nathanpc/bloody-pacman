using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Abstraction interface to allow us to control the player with a whole
/// plethora of controller types.
/// </summary>
public interface IPlayerController {
	/// <summary>
	/// Amount of horizontal lean the player wants.
	/// </summary>
	/// <returns>Horizontal lean magnitude from -1.0 to +1.0.</returns>
	public float HorizontalMovement();

	/// <summary>
	/// Amount of vertical lean the player wants.
	/// </summary>
	/// <returns>Vertical lean magnitude from -1.0 to +1.0.</returns>
	public float VerticalMovement();

	/// <summary>
	/// Well, are we done yet?
	/// </summary>
	/// <returns>True if we are done with this shit.</returns>
	public bool Escape();
}
