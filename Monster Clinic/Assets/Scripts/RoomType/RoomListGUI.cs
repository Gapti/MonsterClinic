using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System;

public class RoomListGUI : MonoBehaviour{
	
	
	public List<RoomInfo> roomInfoList = new List<RoomInfo>();
	
	void Awake()
	{
		LoadRooms();
	}
	
	public RoomInfo GetRoomInfo(int id)
	{
		return( roomInfoList.Find(x => x.ID == id));
	}
	
	void LoadRooms()
	{
		XmlSerializer xml = new XmlSerializer(typeof(List<RoomInfo>));
		FileStream fs = new FileStream(Application.streamingAssetsPath + "/RoomType.xml", FileMode.Open);
		roomInfoList = xml.Deserialize(fs) as List<RoomInfo>;
	}
	
}
