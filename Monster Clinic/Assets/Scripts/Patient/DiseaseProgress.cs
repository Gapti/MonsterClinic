using UnityEngine;
using System.Collections;
using System;

public enum illnessType
{
	flu,
	herpes
}

[Serializable]
public class DiseaseProgress {
	
	public illnessType illness;
	
	public DiseaseProgress()
	{
		illness = illnessType.flu;	
	}
}
