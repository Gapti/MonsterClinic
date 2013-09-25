using UnityEngine;
using System.Collections;

public class OpenHireStaff : MonoBehaviour {
	
	public PanelManager panelManager;
	
	void OnClick()
	{
		if(LevelManager.gameMode != Mode.StaffHiring)
		{
			LevelManager.gameMode = Mode.StaffHiring;
			panelManager.BringInStaffScreen();
		}
	}
}
