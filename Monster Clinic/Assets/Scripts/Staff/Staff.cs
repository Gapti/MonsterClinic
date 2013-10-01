using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public enum StaffType
{
	None,
	Octodoctor,
	Cthuluburse,
	Yetitor
}

public enum SexType
{
	M,
	F
}

[Serializable]
public class Staff  {
	
	//the staff propities
	public StaffType staffType;
	public string description;
	public int monthWage;
	public int experience = 0;
	public string photoName;
	public string name;
	public int cost;
	public SexType sexType;
	
}
