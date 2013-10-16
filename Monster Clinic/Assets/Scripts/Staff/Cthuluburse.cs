using UnityEngine;
using System.Collections;
using System;


public enum CthulLevel
{
	Nurse = 1,
	Matron = 2,
	Head_Matron = 3
}

[Serializable]
public class Cthuluburse : Staff {
	
	public CthulLevel level;
	
}
