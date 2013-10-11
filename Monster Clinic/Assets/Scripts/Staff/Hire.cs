using UnityEngine;
using System.Collections;

public class Hire : MonoBehaviour {
	
	public StaffList staffList;
	public HiredStaffManager hiredList;
	
	
	/// <summary>
	/// Staff refresh handler.
	/// </summary>
	public delegate void StaffRefreshHandler(StaffType staffType);
	public static event StaffRefreshHandler refreshStaffButtons;
	
	void OnClick()
	{
		///grab the ref to the current chosen staff
		CurrentStaffPick hireStaffMember =(CurrentStaffPick) transform.parent.GetComponent<CurrentStaffPick>();	
		
		//instauiate the new staff member
		switch (hireStaffMember.staffType)
		{
		case StaffType.Cthuluburse:
			GameObject newStaff1 = (GameObject)Instantiate(HospitalPrefabs.Cthuluburse, new Vector3(0,0,0), Quaternion.identity);///spawns the gameobject
			newStaff1.GetComponent<StaffPersistantData>().staffData = staffList.GrabCtuluburse (hireStaffMember.staffListPosition);///copy data from the StaffList
			staffList.RemoveCthuluburse(hireStaffMember.staffListPosition);///removes the data from the staFF LIST
			
			//Add the GameObject to the HiredSTaffList
			hiredList.AddStaff(newStaff1);
			
			break;
		case StaffType.Octodoctor:
				GameObject newStaff2 = (GameObject)Instantiate(HospitalPrefabs.Octodoctor, new Vector3(0,0,0), Quaternion.identity);
				newStaff2.GetComponent<StaffPersistantData>().staffData = staffList.GrabOctodoctor(hireStaffMember.staffListPosition);
				staffList.RemoveOctodoctor(hireStaffMember.staffListPosition);
			
				hiredList.AddStaff(newStaff2);	
			
			break;
		case StaffType.Yetitor:
			GameObject newStaff3 = (GameObject) Instantiate(HospitalPrefabs.Yetitor, new Vector3(0,0,0), Quaternion.identity);
			newStaff3.GetComponent<StaffPersistantData>().staffData = staffList.GrabYetitor(hireStaffMember.staffListPosition);
			staffList.RemoveYetitor(hireStaffMember.staffListPosition);
			
			hiredList.AddStaff(newStaff3);
			
			break;
		}
		
		///refesh the list with a delegate
		if(refreshStaffButtons != null)
			refreshStaffButtons(hireStaffMember.staffType);
	}
}
