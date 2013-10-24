using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System;

public class FurnishListGUI : MonoBehaviour{
	
	
	public List<FurnishInfo> furnishInfoList = new List<FurnishInfo>();
	
	void Awake()
	{
		LoadFurnish();
	}
	
	public FurnishInfo GetFurnishInfo(int id)
	{
		return( furnishInfoList.Find(x => x.ID == id));
	}
	
	void LoadFurnish()
	{
		XmlSerializer xml = new XmlSerializer(typeof(List<FurnishInfo>));
		FileStream fs = new FileStream(Application.streamingAssetsPath + "/FurnishType.xml", FileMode.Open);
		furnishInfoList = xml.Deserialize(fs) as List<FurnishInfo>;
	}
	
}
