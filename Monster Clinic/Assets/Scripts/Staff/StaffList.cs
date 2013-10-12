using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System;

public class StaffList : MonoBehaviour{
	/// <summary>
	/// The _octodoctor list.
	/// </summary>
	private List<Octodoctor> _octodoctorList = new List<Octodoctor>();
	/// <summary>
	/// The _ctuluburse list.
	/// </summary>
	private List<Cthuluburse> _ctuluburseList = new List<Cthuluburse>();
	/// <summary>
	/// The _yetitor list.
	/// </summary>
	private List<Yetitor> _yetitorList = new List<Yetitor>();
	
	/// <summary>
	/// Text files for the lists.
	/// </summary>
	public TextAsset OctodoctorText;
	public TextAsset CthuluburseText;
	public TextAsset YetitorText;
	//game objects for the staff...(might need changing)
	
	public GameObject octodoctor;
	public GameObject cthuluburse;
	public GameObject yetitor;
	
	public WWW file;
	
	void Awake()
	{
		//start making the lists
		LoadOctodoctor ();
		LoadYetitor();
		LoadCthuluburse();
		
		//move the prefabs into the staticprefabs
		HospitalPrefabs.Octodoctor = octodoctor;
		HospitalPrefabs.Cthuluburse = cthuluburse;
		HospitalPrefabs.Yetitor = yetitor;
	}
	
	
	/// <summary>
	/// Grabs the octodoctor.
	/// </summary>
	/// <returns>
	/// The octodoctor.
	/// </returns>
	/// <param name='index'>
	/// Index.
	/// </param>
	public Octodoctor GrabOctodoctor(int index)
	{
		if(index < _octodoctorList.Count)
			return _octodoctorList[index];
		
		print ("no more staff");
		return null;
	}
	/// <summary>
	/// Grabs the ctuluburse.
	/// </summary>
	/// <returns>
	/// The ctuluburse.
	/// </returns>
	/// <param name='index'>
	/// Index.
	/// </param>
	public Cthuluburse GrabCtuluburse(int index)
	{
		if(index < _ctuluburseList.Count)
			return _ctuluburseList[index];
		
		
		print ("no more staff");
		return null;
	}
	/// <summary>
	/// Grabs the yetitor.
	/// </summary>
	/// <returns>
	/// The yetitor.
	/// </returns>
	/// <param name='index'>
	/// Index.
	/// </param>
	public Yetitor GrabYetitor(int index)
	{
		if(index < _yetitorList.Count)
			return _yetitorList[index];
		
		print ("no more staff");
		return null;
	}
	
	public void RemoveYetitor(int index)
	{
		_yetitorList.RemoveAt(index);	
	}
	
	public void RemoveCthuluburse(int index)
	{
		_ctuluburseList.RemoveAt(index);	
	}
	
	public void RemoveOctodoctor(int index)
	{
		_octodoctorList.RemoveAt(index);
	}


	void CreateOctodoctor()
    {
		XmlSerializer xml = new XmlSerializer(typeof(List<Octodoctor>));
		TextWriter writer = new StreamWriter(Application.dataPath + "/Scripts/Staff/xml/Octodoctor.xml");
		
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
				cost =int.Parse( splitLine[4] ),
				level = OctoLevel.Attending,
           };

           _octodoctorList.Add(octodoctor);
     	}
		
		///serialze the data
		xml.Serialize(writer, _octodoctorList);
		writer.Close();
    }
	/// <summary>
	/// Loads the cthuluburse.
	/// </summary>
	void CreateCthuluburse()
    {
		XmlSerializer xml = new XmlSerializer(typeof(List<Cthuluburse>));
		TextWriter writer = new StreamWriter(Application.dataPath + "/Scripts/Staff/xml/Cthuluburse.xml");
		
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
				cost = int.Parse(splitLine[4]),
				level = CthulLevel.one,
           };

          _ctuluburseList.Add(cthuluburse);
     	}
		
		xml.Serialize(writer, _ctuluburseList);
		writer.Close ();
    }
	/// <summary>
	/// Loads the yetitor.
	/// </summary>
	void CreateYetitor()
    {
		XmlSerializer xml = new XmlSerializer(typeof(List<Yetitor>));
		TextWriter writer = new StreamWriter(Application.dataPath +  "/Scripts/Staff/xml/Yetitor.xml");
		
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
				cost = int.Parse(splitLine[4]),
				level = YetitorLevel.Brown,
           };

          _yetitorList.Add(yetitor);
     	}
		
		xml.Serialize(writer, _yetitorList);
		writer.Close();
    }
	
	void LoadOctodoctor()
	{
		XmlSerializer xml = new XmlSerializer(typeof(List<Octodoctor>));
		FileStream fs = new FileStream(Application.streamingAssetsPath + "/Octodoctor.xml", FileMode.Open);
		_octodoctorList = xml.Deserialize(fs) as List<Octodoctor>;
	}
	
	void LoadYetitor()
	{
		XmlSerializer xml = new XmlSerializer(typeof(List<Yetitor>));
		FileStream fs = new FileStream(Application.streamingAssetsPath + "/Yetitor.xml", FileMode.Open);
		_yetitorList = xml.Deserialize(fs) as List<Yetitor>;
	}
	
	void LoadCthuluburse()
	{
		XmlSerializer xml = new XmlSerializer(typeof(List<Cthuluburse>));
		FileStream fs = new FileStream(Application.streamingAssetsPath + "/Cthuluburse.xml", FileMode.Open);
		_ctuluburseList = xml.Deserialize(fs) as List<Cthuluburse>;	
	}

}
