using UnityEngine;
using System.Collections;

public class RoomInfoGUI : MonoBehaviour {
	
	/// <summary>
	/// this is to get the right information for the room
	/// </summary>
	public int ID;
	
	private RoomInfo roomInfo;
	private UILabel cost_label, title;
	
	void Start()
	{
		RoomListGUI rlg = (RoomListGUI)	HospitalPrefabs.ScriptsObject.GetComponent<RoomListGUI>();
		roomInfo = rlg.GetRoomInfo(ID);
		
		cost_label = (UILabel)transform.FindChild("Cost_Cell_Label").GetComponent<UILabel>();
		cost_label.text = roomInfo.cost.ToString();
		
		title = (UILabel)transform.FindChild("title").GetComponent<UILabel>();
		title.text = roomInfo.title;
	}
	
	void OnTooltip(bool show)
	{
		if(show)
			UITooltip.ShowText(roomInfo.desc);	
		else
			UITooltip.ShowText(null);	
	}
}
