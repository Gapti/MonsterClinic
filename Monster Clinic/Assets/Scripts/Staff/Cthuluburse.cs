using UnityEngine;
using System.Collections;
using System;


public enum CthulLevel
{
	one = 1,
	two = 2,
	three = 3
}

[Serializable]
public class Cthuluburse : Staff {
	
	public CthulLevel level;
	
	public Cthuluburse()
	{
		base.staffType = StaffType.Cthuluburse;
		base.name = NamesList.GetRandomName();
		base.monthWage = 20;
		base.description = "Cthuluburse";
		level = CthulLevel.one;
	}
}
