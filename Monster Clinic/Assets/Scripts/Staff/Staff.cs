﻿using UnityEngine;
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
	public GameObject staffModel;
	public Texture2D photo;
	public string name;
	public int cost;
	public SexType sexType;
	
}
