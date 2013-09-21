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
	
}
