using UnityEngine;
using System.Collections;


public class PanelManager : MonoBehaviour {

	public GameObject panel_Buttons;
	public GameObject Panel_Resources;
	public GameObject panel_StaffScreen;
//	public GameObject panel_Furnish;
//	public GameObject panel_Destroy;
	public GameObject panel_Build;
	
	public void BringInBuildPanel()
	{
		panel_Build.SetActive(true);
		CloseStaffPanel();
		
		LevelManager.gameMode = Mode.RoomCreation;
		LevelManager.gameState = State.Purchase;
	}
	
	public void CloseBuildPanel()
	{
		panel_Build.SetActive(false);
	}
	
	public void BringInResourcesPanel()
	{
		Panel_Resources.SetActive(true);
	}
	
	public void CloseResourcesPanel()
	{
		Panel_Resources.SetActive(false);
	}
	
	public void BringInButtonsPanel()
	{
		panel_Buttons.SetActive(true);
	}
	
	public void CloseButtonsPanel()
	{
		panel_Buttons.SetActive(true);
	}
	
	public void BringInStaffPanel()
	{
		panel_StaffScreen.SetActive(true);
		panel_Build.SetActive(false);
	}
	
	public void CloseStaffPanel()
	{
		panel_StaffScreen.SetActive(false);	
	}
	
	public void DeleteRoom()
	{
		LevelManager.gameMode = Mode.RoomDeletion;
		LevelManager.gameState = State.Choose;	
	}
	
}
