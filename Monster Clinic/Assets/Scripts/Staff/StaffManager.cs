using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class StaffManager : MonoBehaviour {
	
	public Staff staffMember;
	public GameObject staffTempRef;
	public MeshRenderer staffTempRefRend;
	
	public StaffLabelUpdate[] staffButtons;
	
	public List<Staff> staffList= new List<Staff>();
	
	public GameObject staffPanel;
	public GameObject staffInfoPanel;
	
	
	void OnEnable()
	{
		StaffLabelUpdate.staffPick += BringInStaffInfoPanel;
		Hire.hire += HandleHirehire;
	}

	void HandleHirehire (Staff staff)
	{
		NoPanels();
		
		staffMember = staff;
		LevelManager.gameState = State.Placement;
		switch(staff.staffType)
		{
			case StaffType.Cthuluburse:
			SpawnTempStaff(HospitalPrefabs.Cthuluburse);
			break;
			case StaffType.Octodoctor:
			SpawnTempStaff(HospitalPrefabs.Octodoctor);
			break;
			case StaffType.Yetitor:
			SpawnTempStaff(HospitalPrefabs.Yetitor);
			break;
		}
	}
	
	void OnDisable()
	{
		StaffLabelUpdate.staffPick -= BringInStaffInfoPanel;
		Hire.hire -= HandleHirehire;
	}
	
	void BringInStaffInfoPanel(Staff staff)
	{
		staffPanel.SetActive(false);
		staffInfoPanel.SetActive( true );
		
		staffInfoPanel.GetComponent<StaffInfoPanel>().staff = staff;
	}
	
	void BringInStaffPanel()
	{
		staffInfoPanel.SetActive(false);
		staffPanel.SetActive(true);
	}
	
	void NoPanels()
	{
		staffInfoPanel.SetActive(false);
		staffPanel.SetActive(false);
	}
	
	
	
	void Start()
	{
		ShowOctodoctorList();
	}
	
	void ShowOctodoctorList ( )
	{
		int amount = 6;
		if(StaffList._octodoctorList.Count < 6)
			amount = StaffList._octodoctorList.Count;
			
		for(int a = 0;  a < amount; a++ )
		{
			staffButtons[a].staff = StaffList._octodoctorList[a];
		}
	}
	
	void ShowYetitorList ( )
	{
		int amount = 6;
		if(StaffList._yetitorList.Count < 6)
			amount = StaffList._yetitorList.Count;
		
		for (int i = 0; i < amount; i++) 
		{	
			staffButtons[i].staff = StaffList._yetitorList[i];
		}
	}
	
	void ShowcthuluburseList ( )
	{
		int amount = 6;
		
		if(StaffList._ctuluburseList.Count < 6)
			amount = StaffList._ctuluburseList.Count;
		
		for (int i = 0; i < amount; i++) 
		{
			staffButtons[i].staff = StaffList._ctuluburseList[i];
		}
	}
	
	void SpawnTempStaff(GameObject staffPrefab)
	{
		// Instantiate staff temp
		staffTempRef = (GameObject) Instantiate(staffPrefab);
		staffTempRef.GetComponentInChildren<MeshRenderer>().enabled = false;
		
		// Create a mesh renderer component
		staffTempRefRend =staffTempRef.GetComponentInChildren<MeshRenderer>();
	}
	
	void Update()
	{
		if(LevelManager.gameState == State.Placement)
		{
			if(Input.GetKeyUp(KeyCode.Escape))
			{
				LevelManager.gameState = State.None;
				Destroy(staffTempRef);
				staffTempRefRend = null;
				BringInStaffPanel();
				
				return;
			}
			
		// Cast a ray from screen mouse position to 3d world space
		Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit cameraRayHit;
		
		// Check if the casted ray collides only floor
		if(Physics.Raycast(cameraRay, out cameraRayHit, 1000, 1 << 8))
		{
				// Move the hover tile to collison point and switch it on
				Vector3 hitPoint = cameraRayHit.point;
				hitPoint = getTilePoints(hitPoint);
				staffTempRef.transform.position = new Vector3(hitPoint.x*1f, 0f , hitPoint.y*1f);
				staffTempRefRend.enabled = true;
				staffTempRef.transform.localScale = new Vector3(1F,1F,1F);
				
				// If empty cell outside room
				if(Maps.GetFloorMapValue((int)hitPoint.x, (int)hitPoint.y)==0)
				{
					// Set the color of tile to green
					staffTempRefRend.material.SetColor ("_Color", new Color(0F, 1.0F, 0F, 0.25F));
					if(Input.GetMouseButtonDown(0))
					{
						////plant the staff down
						PositionStaff(new Vector2(hitPoint.x, hitPoint.y));
					}	
				}
				// If not an empty cell outside room
				else
				{
					// Set the color of tile to red
					staffTempRefRend.material.SetColor ("_Color", new Color(1.0F, 0F, 0F, 0.25F));
				}
		}
		// If no collison, switch off hover tile
		else
		{
			staffTempRefRend.enabled = false;
		}
			
		}
	}
	
	void PositionStaff(Vector2 pos)
	{
		//put the staff in the list
		AddStaff();
		staffTempRef = null;
		LevelManager.gameState = State.None;
		BringInStaffPanel();
	}
	
	void AddStaff()
	{
		staffList.Add (staffMember);
		
		switch(staffMember.staffType)
		{
		case StaffType.Cthuluburse:
			StaffList._ctuluburseList.Remove((Cthuluburse)staffMember);
			break;
		case StaffType.Octodoctor:
			StaffList._octodoctorList.Remove((Octodoctor)staffMember);
			break;
		case StaffType.Yetitor:
			StaffList._yetitorList.Remove((Yetitor)staffMember);
			break;
		}
	}
	
	// Convert world space floor points to tile points
	Vector2 getTilePoints(Vector3 floorPoints)
	{
		Vector2 tilePoints = new Vector2();
		
		// Convert the space points to tile points
		tilePoints.x = (int)(floorPoints.x / 1f);
		tilePoints.y = (int)(floorPoints.z / 1f);
		
		// Return the tile points
		return tilePoints;
	}
}
