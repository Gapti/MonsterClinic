using UnityEngine;
using System.Collections;

public class FurnishInfoGUI : MonoBehaviour {
	
	public int ID;/// <summary>
	/// this needs updating to the ammar code
	/// </summary> thi
	
	private FurnishInfo furnishInfo;
	private UILabel cost, title;
	
	// Use this for initialization
	void Start () {
		FurnishListGUI flg = HospitalPrefabs.ScriptsObject.GetComponent<FurnishListGUI>();
		furnishInfo = flg.GetFurnishInfo(ID);
		
		cost =(UILabel) transform.Find("Cost").GetComponent<UILabel>();
		cost.text = furnishInfo.cost.ToString();
		
		title = (UILabel) transform.Find("Title").GetComponent<UILabel>();
		title.text = furnishInfo.title;
	}
	
	void OnTooltip(bool show)
	{
		if(show)
		{
			UITooltip.ShowText(furnishInfo.desc);
		}
		else
			UITooltip.ShowText(null);
	}
	
	void OnClick()
	{
		LevelManager.selectedItemNo = ID;	
	}
}
