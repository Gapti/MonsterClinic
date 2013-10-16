using UnityEngine;
using System.Collections;

public class HospitalPrefabs : MonoBehaviour {
	//static class for prefabs
	
	public static GameObject Octodoctor;
	public static GameObject Cthuluburse;
	public static GameObject Yetitor;
	
	public static GameObject ScriptsObject;
	
	void Awake()
	{
		ScriptsObject = this.gameObject;	
	}
}
