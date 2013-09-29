using UnityEngine;
using System.Collections;

public class StaffLabel : MonoBehaviour {
	
	public int index;
	public StaffList staffList;
	private StaffType currentStaffType;
	
	// Use this for initialization
	void Start () {
		currentStaffType = StaffType.Octodoctor;
		ShowOctoDoctorName();
		
		ShowFirstStaffDetails(StaffType.Octodoctor);
	}
	
	void OnEnable()
	{
		ChooseStaffType.showStaffType += HandleChooseStaffTypeshowStaffType;	
	}

	void HandleChooseStaffTypeshowStaffType (StaffType st)
	{
		switch(st)
		{
		case StaffType.Cthuluburse:
			ShowCthuluburseName();
			ShowFirstStaffDetails(StaffType.Cthuluburse);
			currentStaffType = StaffType.Cthuluburse;
				break;
		case StaffType.Octodoctor:
			ShowOctoDoctorName();
			ShowFirstStaffDetails(StaffType.Octodoctor);
			currentStaffType = StaffType.Octodoctor;
				break;
		case StaffType.Yetitor:
			ShowYetitorName();
			ShowFirstStaffDetails(StaffType.Yetitor);
			currentStaffType = StaffType.Yetitor;
			break;
		case StaffType.None:
			print ("ERROR NO STAFF TYPE");
			break;
		}
	}
	
	void ShowFirstStaffDetails(StaffType st)
	{
		switch(st)
		{
		case StaffType.Cthuluburse:
			if(index == 0)
			ShowCthulburseDetails();
			
			break;
		case StaffType.Octodoctor:
			if(index == 0)
				ShowOctoDoctorDetails();
			
					break;
		case StaffType.Yetitor:
			if(index == 0)
				ShowYetitorDetails();
			
			break;
		}
	}
	
	void OnDisable()
	{
		ChooseStaffType.showStaffType -= HandleChooseStaffTypeshowStaffType;
	}
	
	public void ShowOctoDoctorName()
	{
		UILabel staffName = (UILabel)transform.GetComponentInChildren<UILabel>();
		if(staffList.GrabOctodoctor(index) == null)
		{
			staffName.text = "NONE LEFT";
		}
		else
		{
			staffName.text = staffList.GrabOctodoctor(index).name;
		
		}
	}
	
	public void ShowYetitorName()
	{
		UILabel staffName = (UILabel)transform.GetComponentInChildren<UILabel>();
		if(staffList.GrabYetitor(index) == null)
		{
			staffName.text = "NONE LEFT";
		}
		else
		{
			staffName.text = staffList.GrabYetitor(index).name;	
	
		}
	}
	
	public void ShowCthuluburseName()
	{
		UILabel staffName = (UILabel)transform.GetComponentInChildren<UILabel>();
		if(staffList.GrabCtuluburse(index) == null)
		{
			staffName.text = "NONE LEFT";	
		}
		else
		{
			staffName.text = staffList.GrabCtuluburse(index).name;	
		}
	}
	
	public UILabel description;
	public UILabel wage;
	public UILabel cost;
	public UISprite face;
	
	public void ShowOctoDoctorDetails()
	{
		description.text = staffList.GrabOctodoctor(index).description;
		wage.text = staffList.GrabOctodoctor(index).monthWage.ToString();
		cost.text = staffList.GrabOctodoctor(index).cost.ToString();
		face.spriteName = staffList.GrabOctodoctor(index).photoName;
	}
	
	public void ShowCthulburseDetails()
	{
		description.text = staffList.GrabCtuluburse(index).description;
		wage.text = staffList.GrabCtuluburse(index).monthWage.ToString();
		cost.text = staffList.GrabCtuluburse(index).cost.ToString();
		face.spriteName = staffList.GrabCtuluburse(index).photoName;
	}
	
	public void ShowYetitorDetails()
	{
		description.text = staffList.GrabYetitor(index).description;
		wage.text = staffList.GrabYetitor(index).monthWage.ToString();
		cost.text = staffList.GrabYetitor(index).cost.ToString();
		face.spriteName = staffList.GrabYetitor(index).photoName;
	}
		
	void OnClick()
	{
		switch(currentStaffType)
		{
		case StaffType.Cthuluburse:
			ShowCthulburseDetails();
			break;
		case StaffType.Octodoctor:
			ShowOctoDoctorDetails();
			break;
		case StaffType.Yetitor:
			ShowYetitorDetails();
			break;
		}
	}
	
}
