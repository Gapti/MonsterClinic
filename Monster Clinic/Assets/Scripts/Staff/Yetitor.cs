using UnityEngine;
using System.Collections;
using System;

public enum YetitorLevel
{
	Brown = 1,
	Silverback = 2,
	Icemane = 3
}

[Serializable]
public class Yetitor : Staff {
	
	public YetitorLevel level;
	
	public Yetitor()
	{
		base.staffType = StaffType.Yetitor;	
		base.name = NamesList.GetRandomName();
		base.monthWage = 10;
		base.description = "Yetitor";
		level = YetitorLevel.Brown;
	}
	
}
