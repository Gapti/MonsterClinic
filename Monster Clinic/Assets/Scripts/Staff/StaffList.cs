using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

public class StaffList : MonoBehaviour{
	
	private List<Octodoctor> _octodoctorList = new List<Octodoctor>();
	private List<Cthuluburse> _ctuluburseList = new List<Cthuluburse>();
	private List<Yetitor> _yetitorList = new List<Yetitor>();
	
	public TextAsset OctodoctorText;
	public TextAsset CthuluburseText;
	public TextAsset YetitorText;
	
	public GameObject octodoctor;
	public GameObject cthuluburse;
	public GameObject yetitor;
	
	
	void Awake()
	{
		LoadOctodoctor ();
		LoadYetitor();
		LoadCthuluburse();
		
		HospitalPrefabs.Octodoctor = octodoctor;
		HospitalPrefabs.Cthuluburse = cthuluburse;
		HospitalPrefabs.Yetitor = yetitor;
	}
	
	public Staff GrabOctodoctor(int index)
	{
		if(index <= _octodoctorList.Count)
			return _octodoctorList[index];
		
		print ("no more staff");
		return null;
	}
	
	public Staff GrabCtuluburse(int index)
	{
		if(index <= _ctuluburseList.Count)
			return _ctuluburseList[index];
		
		
		print ("no more staff");
		return null;
	}
	
	public Staff GrabYetitor(int index)
	{
		if(index <= _yetitorList.Count)
			return _yetitorList[index];
		
		print ("no more staff");
		return null;
	}
	
	void LoadOctodoctor()
    {
       string[] lines = OctodoctorText.text.Split(new char[]{'\n','\r'},System.StringSplitOptions.RemoveEmptyEntries);
       for (int i = 0; i < lines.Length; i++)
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
       for (int i = 0; i < lines.Length; i++)
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
       for (int i = 0; i < lines.Length; i++)
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
