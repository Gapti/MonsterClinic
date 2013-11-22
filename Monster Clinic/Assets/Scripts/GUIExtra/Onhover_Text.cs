using UnityEngine;
using System.Collections;

public class Onhover_Text : MonoBehaviour {
	
	public string hoverText;
	
	void OnTooltip(bool show)
	{
		if(show)
			UITooltip.ShowText(hoverText);	
		else
			UITooltip.ShowText(null);	
	}
}
