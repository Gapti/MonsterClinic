using UnityEngine;
using System.Collections;


public class PanelManager : MonoBehaviour {

	public GameObject panel_Buttons;
	public GameObject Panel_Resources;
	public GameObject panel_StaffScreen;
	
	public void BringInStaffScreen()
	{
		panel_StaffScreen.SetActive(true);	
	}
	
	public void CloseStaffScreen()
	{
		panel_StaffScreen.SetActive(false);	
	}
	
}
