using UnityEngine;
using System.Collections;

public class StaffLabel : MonoBehaviour {
	
	public int index; // this buttons index
	public StaffList staff; // ref to the StaffList
	public CurrentStaffPick pick;
	private StaffType currentStaffType;// this staff type 
	
	void Awake()
	{
		pick=(CurrentStaffPick) transform.parent.GetComponent<CurrentStaffPick>();
	}
	
	
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
		
		Hire.refreshStaffButtons += HandleChooseStaffTypeshowStaffType;
	}
	
	void OnDisable()
	{
		ChooseStaffType.showStaffType -= HandleChooseStaffTypeshowStaffType;
		Hire.refreshStaffButtons -= HandleChooseStaffTypeshowStaffType;
	}
	
	// andler for staff type delegate
	void HandleChooseStaffTypeshowStaffType (StaffType st)
	{
		switch(st)
		{
		case StaffType.Cthuluburse:
			currentStaffType = StaffType.Cthuluburse;
			ShowCthuluburseName();
			ShowFirstStaffDetails(StaffType.Cthuluburse);
			
				break;
		case StaffType.Octodoctor:
			currentStaffType = StaffType.Octodoctor;
			ShowOctoDoctorName();
			ShowFirstStaffDetails(StaffType.Octodoctor);
				break;
		case StaffType.Yetitor:
			currentStaffType = StaffType.Yetitor;
			ShowYetitorName();
			ShowFirstStaffDetails(StaffType.Yetitor);
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
		
		pick.staffType = currentStaffType;
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
		
		pick.staffType = currentStaffType;
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
		
		pick.staffType = currentStaffType;
	}
	
	//staff info public to gui
	public UILabel description;
	public UILabel wage;
	public UILabel cost;
	public UISprite face;
	public UILabel level;
	
	/// ref to the hire button
	public UIImageButton hireButton;
	
	//show the ocotodoctor more info when you click his name
	public void ShowOctoDoctorDetails()
	{
		UpdateLabels(staff.GrabOctodoctor(index));
		
		//make a ref of staff picked
		pick.staffListPosition = index;
		
	}
	
	// show the cthulburse more info when you click his name
	public void ShowCthulburseDetails()
	{
		UpdateLabels(staff.GrabCtuluburse(index));
		
		//make a ref of staff picked
		pick.staffListPosition = index;
		
	}
	
	//show the yetitor more into when you click his name
	public void ShowYetitorDetails()
	{
		UpdateLabels(staff.GrabYetitor(index));
		
		//make a ref of staff picked
		pick.staffListPosition = index;
	}
	
	void UpdateLabels(Staff m)
	{
		if(m == null)
			return;
		
		if(m.staffType == StaffType.Octodoctor)
			level.text = (((Octodoctor)m).level).ToString();
		
		if(m.staffType == StaffType.Cthuluburse)
			level.text = (((Cthuluburse)m).level).ToString();
			
		if(m.staffType == StaffType.Yetitor)
			level.text = (((Yetitor)m).level).ToString();	
				
		description.text = m.description;
		wage.text = m.monthWage.ToString();
		cost.text = m.cost.ToString();
		face.spriteName = m.photoName;
		
		///check can we offord this, if not disable the button
		GameResources gr = HospitalPrefabs.ScriptsObject.GetComponent<GameResources>();
		if(gr.OffordItemCheck(m.cost) < 0 )
			hireButton.isEnabled = false;
		else
			hireButton.isEnabled = true;
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
