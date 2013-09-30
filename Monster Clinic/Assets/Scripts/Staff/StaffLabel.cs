using UnityEngine;
using System.Collections;

public class StaffLabel : MonoBehaviour {
	
	public int index; // this buttons index
	public StaffList staff; // ref to the StaffList
	private StaffType currentStaffType;// this staff type 
	
	// Use this for initialization
	void Start () {
		///make the octodoctor the first staff type
		currentStaffType = StaffType.Octodoctor;
		ShowOctoDoctorName();
		
		ShowFirstStaffDetails(StaffType.Octodoctor);
	}
	
	void OnEnable()
	{
		/// delegate for button to choose staff type for list
		ChooseStaffType.showStaffType += HandleChooseStaffTypeshowStaffType;	
	}
	
	// handler for staff type delegate
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
	
	//we must show the first staff type details
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
	
	//show the ocotodoctors name in the button
	public void ShowOctoDoctorName()
	{
		UILabel staffName = (UILabel)transform.GetComponentInChildren<UILabel>();
		if(staff.GrabOctodoctor(index) == null)
		{
			staffName.text = "NONE LEFT";// no more to show from the stafflist
		}
		else
		{
			staffName.text = staff.GrabOctodoctor(index).name;
		
		}
	}
	
	//show the yetitor name in the buttons
	public void ShowYetitorName()
	{
		UILabel staffName = (UILabel)transform.GetComponentInChildren<UILabel>();
		if(staff.GrabYetitor(index) == null)
		{
			staffName.text = "NONE LEFT";//no more to show from the stafflist
		}
		else
		{
			staffName.text = staff.GrabYetitor(index).name;	
	
		}
	}
	
	//show the cthuluburse name in the buttons
	public void ShowCthuluburseName()
	{
		UILabel staffName = (UILabel)transform.GetComponentInChildren<UILabel>();
		if(staff.GrabCtuluburse(index) == null)
		{
			staffName.text = "NONE LEFT";	//no more to show from the stafflist
		}
		else
		{
			staffName.text = staff.GrabCtuluburse(index).name;	
		}
	}
	
	//staff info public to gui
	public UILabel description;
	public UILabel wage;
	public UILabel cost;
	public UISprite face;
	public UILabel level;
	
	//show the ocotodoctor more info when you click his name
	public void ShowOctoDoctorDetails()
	{
		var myStaff = staff.GrabOctodoctor(index);
		description.text = myStaff.description;
		wage.text = myStaff.monthWage.ToString();
		cost.text = myStaff.cost.ToString();
		face.spriteName = myStaff.photoName;
		level.text = (((Octodoctor)myStaff).level).ToString();
	}
	
	// show the cthulburse more info when you click his name
	public void ShowCthulburseDetails()
	{
		var myStaff = staff.GrabCtuluburse(index);
		description.text = myStaff.description;
		wage.text = myStaff.monthWage.ToString();
		cost.text = myStaff.cost.ToString();
		face.spriteName = myStaff.photoName;
		level.text = (((Cthuluburse)myStaff).level).ToString();
	}
	
	//show the yetitor more into when you click his name
	public void ShowYetitorDetails()
	{
		var myStaff = staff.GrabYetitor(index);
		description.text = myStaff.description;
		wage.text = myStaff.monthWage.ToString();
		cost.text = myStaff.cost.ToString();
		face.spriteName = myStaff.photoName;
		level.text = (((Yetitor)myStaff).level).ToString();
	}
		
	/// <summary>
	/// Raises the click event.
	/// </summary>
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
