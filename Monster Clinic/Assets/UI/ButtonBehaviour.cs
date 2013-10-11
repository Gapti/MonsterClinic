using UnityEngine;
using System.Collections;

public class ButtonBehaviour : MonoBehaviour {


	void OnPress (bool isPressed) 
	{
		if(isPressed)
		{
			this.gameObject.GetComponent<UIImageButton>().isEnabled = false;
		}
	}
}
