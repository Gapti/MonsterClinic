﻿using UnityEngine;
using System.Collections;


public class PanelManager : MonoBehaviour {

	public GameObject panel_Buttons;
	public GameObject Panel_Resources;
	public GameObject panel_StaffScreen;
//	public GameObject panel_Furnish;
//	public GameObject panel_Destroy;
	public GameObject panel_Build;
	
	public void ExitBuildRoom()
	{
		LevelManager.gameMode = Mode.None;
		LevelManager.gameState = State.None;
		LevelManager.selectedRoomType = RoomType.None;	
	}
	
	public void BringInBuildPanel()
	{
		panel_Build.SetActive(true);
		CloseStaffPanel();
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
		
		CloseStaffPanel();
		CloseResourcesPanel();
		CloseBuildPanel();
	}
	
	
	public void StartBuilding()
	{
		LevelManager.gameMode = Mode.RoomCreation;
		LevelManager.gameState = State.Purchase;		
	}
	
	public void BuildReception()
	{
		LevelManager.selectedRoomType = RoomType.Reception;
		LevelManager.gameState = State.Placement;	
	}
	
	public void BuildStaffBreak()
	{
		LevelManager.selectedRoomType = RoomType.StaffBreak;
		LevelManager.gameState = State.Placement;
	}
	
	public void BuildPatientWard()
	{
		LevelManager.selectedRoomType = RoomType.PatientWard;
		LevelManager.gameState = State.Placement;
	}
	
	public void BuildDiagnostics()
	{
		LevelManager.selectedRoomType = RoomType.Diagnostics;
		LevelManager.gameState = State.Placement;
	}
	
	public void BuildMagicPotion()
	{
		LevelManager.selectedRoomType = RoomType.MagicPotion;
		LevelManager.gameState = State.Placement;
	}
	
	public void BuildPhysicalActivity()
	{
		LevelManager.selectedRoomType = RoomType.PhysicalActivity;
		LevelManager.gameState = State.Placement;
	}
	
	public void BuildShockTreatment()
	{
		LevelManager.selectedRoomType = RoomType.ShockTreatment;
		LevelManager.gameState = State.Placement;
	}
	
	public void BuildSlimeTreatment()
	{
		LevelManager.selectedRoomType = RoomType.SlimeTreatment;
		LevelManager.gameState = State.Placement;
	}
	
	void Update()
	{
		if(LevelManager.gameMode == Mode.RoomCreation && LevelManager.gameState == State.Purchase)
		{
			BringInBuildPanel();	
		}
		else
		{
			CloseBuildPanel();	
		}
	}
	
}
