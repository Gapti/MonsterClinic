using UnityEngine;
using System.Collections;

public class CloseHire : MonoBehaviour {
	
	public PanelManager panelManager;
		
	void OnClick()
	{
		LevelManager.gameMode = Mode.None;
		panelManager.CloseStaffScreen();	
	}
}
