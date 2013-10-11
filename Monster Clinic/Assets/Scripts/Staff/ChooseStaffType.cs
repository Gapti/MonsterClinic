using UnityEngine;
using System.Collections;

public class ChooseStaffType : MonoBehaviour {
	
	public StaffType staffType;
	public delegate void StaffTypeHandler(StaffType st);
	public static event StaffTypeHandler showStaffType;
	
	public UISprite[] otherButtons;
	
	void OnClick()
	{
		if(showStaffType != null)
			showStaffType(staffType);
		
		UISprite thisSprite = transform.GetComponentInChildren<UISprite>();
		thisSprite.depth = 1;
		
		otherButtons[0].depth = -1;
		otherButtons[1].depth = -1;
	}
	
}
