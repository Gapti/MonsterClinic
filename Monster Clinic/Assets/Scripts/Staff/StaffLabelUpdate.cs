using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StaffLabelUpdate : MonoBehaviour {
	
	public UILabel glitter;
	public UILabel nameLabel;
	public UILabel wage;
	public UILabel level;
	
	public Staff _staff;
	
	public Staff staff
	{
		get
		{
			return _staff;
		}
		set
		{
			_staff = value;
			
			UpdateGlitter();
			UpdateName();
			UpdateWage();
			UpdateLevel();
		}
	}
	
	public void UpdateGlitter()
	{
		glitter.text = _staff.cost.ToString();
	}
	
	public void UpdateName()
	{
		nameLabel.text = _staff.name;
	}
	
	public void UpdateWage()
	{
		wage.text = _staff.monthWage.ToString();
	}
	
	public void UpdateLevel()
	{
		switch(_staff.staffType)
		{
		case StaffType.Cthuluburse:
			level.text = (((Cthuluburse)_staff).level).ToString(); 
			break;
		case StaffType.Octodoctor:
			level.text = (((Octodoctor)_staff).level).ToString();
			break;
		case StaffType.Yetitor:
			level.text = (((Yetitor)_staff).level).ToString();
			break;
		}
			
	}
	
}
