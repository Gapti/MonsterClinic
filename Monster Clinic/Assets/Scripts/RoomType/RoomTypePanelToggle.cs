using UnityEngine;
using System.Collections;

public class RoomTypePanelToggle : MonoBehaviour {
	
	public GameObject pg;
	public GameObject pb;
	public UISprite gt;
	public UISprite bt;
	
	void OnEnable()
	{
		SetBlue();
	}
	
	public void SetBlue()
	{
	
		pg.SetActive(false);
		pb.SetActive(true);
		
		gt.depth = 0;
		bt.depth = 2;
	}
	
	public void SetGreen()
	{
		pg.SetActive(true);
		pb.SetActive(false);
		
		gt.depth = 2;
		bt.depth = 0;
	}
}
