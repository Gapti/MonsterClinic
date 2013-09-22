using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

public class StaffList : MonoBehaviour{
	
	public static List<Octodoctor> _octodoctorList = new List<Octodoctor>();
	public static List<Cthuluburse> _ctuluburseList = new List<Cthuluburse>();
	public static List<Yetitor> _yetitorList = new List<Yetitor>();
	
	public TextAsset OctodoctorText;
	public TextAsset CthuluburseText;
	public TextAsset YetitorText;
	
	
	void Awake()
	{
		LoadOctodoctor ();
		LoadYetitor();
		LoadCthuluburse();
	}
	
	void LoadOctodoctor()
    {
       string[] lines = OctodoctorText.text.Split(new char[]{'\n','\r'},System.StringSplitOptions.RemoveEmptyEntries);
       for (int i = 1; i < lines.Length; i++)
       {
           string[] splitLine = lines[i].Split(',');

			Octodoctor octodoctor = new Octodoctor()
           {
               name = splitLine[0],
               sexType = (SexType)Enum.Parse(typeof(SexType), splitLine[1]),
               staffType = StaffType.Octodoctor,
				description = splitLine[2],
				photoName = splitLine[3],
				level = OctoLevel.Attending,
           };

           _octodoctorList.Add(octodoctor);
     	}
    }
	
	void LoadCthuluburse()
    {
       string[] lines = CthuluburseText.text.Split(new char[]{'\n','\r'},System.StringSplitOptions.RemoveEmptyEntries);
       for (int i = 1; i < lines.Length; i++)
       {
           string[] splitLine = lines[i].Split(',');
			
			Cthuluburse cthuluburse = new Cthuluburse()
           {
               name = splitLine[0],
               sexType = (SexType)Enum.Parse(typeof(SexType), splitLine[1]),
               staffType = StaffType.Cthuluburse,
				description = splitLine[2],
				photoName = splitLine[3],
				level = CthulLevel.one,
           };

          _ctuluburseList.Add(cthuluburse);
     	}
    }
	
	void LoadYetitor()
    {
       string[] lines = YetitorText.text.Split(new char[]{'\n','\r'},System.StringSplitOptions.RemoveEmptyEntries);
       for (int i = 1; i < lines.Length; i++)
       {
           string[] splitLine = lines[i].Split(',');

			Yetitor yetitor = new Yetitor()
           {
               name = splitLine[0],
               sexType = (SexType)Enum.Parse(typeof(SexType), splitLine[1]),
               staffType = StaffType.Yetitor,
				description = splitLine[2],
				photoName = splitLine[3],
				level = YetitorLevel.Brown,
           };

          _yetitorList.Add(yetitor);
     	}
    }

}
