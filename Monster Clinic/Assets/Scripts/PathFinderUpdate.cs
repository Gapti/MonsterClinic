using UnityEngine;
using System.Collections;
using Pathfinding;

/// <summary>
/// Path finder update.
/// </summary>//
public static class PathFinderUpdate{
	
	/// <summary>
	/// Adds the bounds to the pathfinder.
	/// </summary>
	/// <param name='t'>
	/// T.
	/// </param>
	public static void AddBounds(Transform t)
	{
		//Debug.Log (t.name);
		Bounds b = t.collider.bounds;
		GraphUpdateObject guo = new GraphUpdateObject(b);
		AstarPath.active.UpdateGraphs (guo);
	}

}
