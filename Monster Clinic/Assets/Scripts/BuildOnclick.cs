using UnityEngine;
using System.Collections;

public class BuildOnclick : MonoBehaviour {

	void OnClick()
	{
		LevelManager.gameMode = Mode.RoomCreation;
		LevelManager.gameState = State.Purchase;	
	}
}
