using UnityEngine;
using System.Collections;

public class Hire : MonoBehaviour {
	
	private StaffList _staffList;
	private HiredStaffManager _hiredList;
	
	/// <summary>
	/// Staff refresh handler.
	/// </summary>
	public delegate void StaffRefreshHandler(StaffType staffType);
	public static event StaffRefreshHandler refreshStaffButtons;
	
	void Awake()
	{
		_staffList = HospitalPrefabs.ScriptsObject.GetComponent<StaffList>();
		_hiredList = HospitalPrefabs.ScriptsObject.GetComponent<HiredStaffManager>();
	}
	
	void OnClick()
	{
		///grab the ref to the current chosen staff
		CurrentStaffPick hireStaffMember =(CurrentStaffPick) transform.parent.GetComponent<CurrentStaffPick>();	
		
		///grab a ref to the gameResorces
		GameResources gr = (GameResources) HospitalPrefabs.ScriptsObject.GetComponent<GameResources>();
	
		
		//instauiate the new staff member
		switch (hireStaffMember.staffType)
		{
		case StaffType.Cthuluburse:
			GameObject newStaff1 = (GameObject)Instantiate(HospitalPrefabs.Cthuluburse, new Vector3(20,0.1f,20), Quaternion.identity);///spawns the gameobject
			newStaff1.GetComponent<StaffPersistantData>().staffData = _staffList.GrabCtuluburse (hireStaffMember.staffListPosition);///copy data from the StaffList
			
			///minus the cost
			gr.Glitter -= _staffList.GrabCtuluburse (hireStaffMember.staffListPosition).cost;
			
			_staffList.RemoveCthuluburse(hireStaffMember.staffListPosition);///removes the data from the staFF LIST
			
			//Add the GameObject to the HiredSTaffList
			_hiredList.AddStaff(newStaff1);
			
			
			break;
		case StaffType.Octodoctor:
				GameObject newStaff2 = (GameObject)Instantiate(HospitalPrefabs.Octodoctor, new Vector3(20,0.1f,20), Quaternion.identity);
				newStaff2.GetComponent<StaffPersistantData>().staffData = _staffList.GrabOctodoctor(hireStaffMember.staffListPosition);
			
				///minus the cost
				gr.Glitter -= _staffList.GrabOctodoctor(hireStaffMember.staffListPosition).cost;
			
				_staffList.RemoveOctodoctor(hireStaffMember.staffListPosition);
			
				_hiredList.AddStaff(newStaff2);	
			
			break;
		case StaffType.Yetitor:
			GameObject newStaff3 = (GameObject) Instantiate(HospitalPrefabs.Yetitor, new Vector3(0,0,0), Quaternion.identity);
			newStaff3.GetComponent<StaffPersistantData>().staffData = _staffList.GrabYetitor(hireStaffMember.staffListPosition);
			
			//minus the cost
			gr.Glitter  -= _staffList.GrabYetitor(hireStaffMember.staffListPosition).cost;
			
			_staffList.RemoveYetitor(hireStaffMember.staffListPosition);
			
			_hiredList.AddStaff(newStaff3);
			
			break;
		}
		
		///refesh the list with a delegate
		if(refreshStaffButtons != null)
			refreshStaffButtons(hireStaffMember.staffType);
	}
	
	void OnTooltip(bool show)
	{
		
		if(show)
			UITooltip.ShowText("Hire this person" );	
		else
			UITooltip.ShowText(null);	
	}
}
