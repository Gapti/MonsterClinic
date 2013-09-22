using UnityEngine;
using System.Collections;

public class StaffInfoPanel : MonoBehaviour {
	
	public Staff _staff;
	
	public UILabel glitter;
	public UILabel nameLabel;
	public UILabel desc;
	public UISprite photo;
	
	public Staff staff
	{
		get
		{
			return _staff;
		}
		set
		{
			_staff = value;	
			
			UpdateFields();
		}
		
		
	}
	
	void UpdateFields()
	{
		glitter.text = _staff.cost.ToString();
		nameLabel.text = _staff.name;
		desc.text = _staff.description;
		photo.spriteName = _staff.photoName;
	}
	
}
