using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HiredStaffManager : MonoBehaviour {
	
	public List<GameObject> hiredStaffList = new List<GameObject>();
	
	public void AddStaff(GameObject staffObject)
	{
		hiredStaffList.Add (staffObject);
	}
}
