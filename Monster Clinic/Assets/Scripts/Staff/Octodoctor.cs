using System.Collections;
using System;

public enum OctoLevel
{
	Intern = 1,
	Attending = 2,
	Head_of_Surgery = 3
}

[Serializable]
public class Octodoctor : Staff {
	
	public OctoLevel level;
	
}
