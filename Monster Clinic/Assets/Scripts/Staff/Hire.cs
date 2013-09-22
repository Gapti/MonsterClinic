using UnityEngine;
using System.Collections;

public class Hire : MonoBehaviour {
	
	public delegate void hireHandler (Staff staff);
	public static event hireHandler hire;
	
	
	void OnClick()
	{
		if(hire != null)
		{
			hire(transform.parent.GetComponent<StaffInfoPanel>().staff);
			print (transform.parent.GetComponent<StaffInfoPanel>().staff.name);
		}
	}
}
