using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HiredStaffManager : MonoBehaviour {
	
	public List<GameObject> hiredStatffList = new List<GameObject>();
	
	public void AddStaff(GameObject staffObject)
	{
		hiredStatffList.Add (staffObject);
		
		///just for a test
		//print (hiredStatffList[0].GetComponent<StaffPersistantData>().staffData.name);
	}
}
