using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using System;

// Room class
public class Room 
{
	// Public static variables
	public static int roomIdCounter = 0;
	
	// Public variables
	public int roomId;
	public RoomType type;
	public Vector2 leftBottom;
	public Vector2 leftTop;
	public Vector2 rightBottom;
	public Vector2 rightTop;
	public float xLength;
	public float yLength;
	public List<GameObject> leftWall;
	public List<GameObject> rightWall;
	public List<GameObject> bottomWall;
	public List<GameObject> topWall;
	public List<GameObject> roomItems;
	public List<GameObject> doors;
	
	// Constructor room
	public Room()
	{
		roomId = ++roomIdCounter;
		type = RoomType.None;
		leftBottom = new Vector2();
		leftTop = new Vector2();
		rightBottom = new Vector2();
		rightTop = new Vector2();
		xLength = 0;
		yLength = 0;
	}
	
	// Overloaded constructor room
	public Room(RoomType roomType, Vector2 leftDown, Vector2 leftUp, Vector2 rightDown, Vector2 rightUp, GameObject horizontalWall, GameObject verticalWall, Transform t)
	{
		roomId = ++roomIdCounter;
		type = roomType;
		leftBottom = leftDown;
		leftTop = leftUp;
		rightBottom = rightDown;
		rightTop = rightUp;
		// Value (-1,-1) for door means room has no door
		Vector2 door = new Vector2(-1f,-1f);
		leftWall = new List<GameObject>();
		rightWall = new List<GameObject>();
		bottomWall = new List<GameObject>();
		topWall = new List<GameObject>();
		roomItems = new List<GameObject>();
		doors = new List<GameObject>();
		
		// Calculate length of walls
		float xD = rightBottom.x - leftBottom.x;
		float yD = leftTop.y - leftBottom.y;
		GameObject wall;
		
		xLength = xD;
		yLength = yD;
		
		// Build left wall
		for(int i = 0; i<yD; i++)
		{
			wall = (GameObject) GameObject.Instantiate(verticalWall, new Vector3(leftBottom.x,0F,leftBottom.y+i), t.rotation);
			leftWall.Add(wall);
			
			// adjust NAV grid gragh bounds // edited by Mark
			Transform wallChild = wall.transform.GetChild(0);
			
			if(wallChild.name == "Wall")
				PathFinderUpdate.AddBounds(wallChild);
			else
				Debug.LogError("No wall child object");
		}
		// Build right wall
		for(int i = 0; i<yD; i++)
		{
			wall = (GameObject) GameObject.Instantiate(verticalWall, new Vector3(rightBottom.x,0F,rightBottom.y+i), t.rotation);
			rightWall.Add(wall);
			
			// adjust NAV grid gragh bounds // edited by Mark
			Transform wallChild = wall.transform.GetChild(0);
			
			if(wallChild.name == "Wall")
				PathFinderUpdate.AddBounds(wallChild);
			else
				Debug.LogError("No wall child object");
			
		}
		// Build bottom wall
		for(int i = 0; i<xD; i++)
		{
			wall = (GameObject) GameObject.Instantiate(horizontalWall, new Vector3(leftBottom.x+i,0F,leftBottom.y), t.rotation);
			bottomWall.Add(wall);
			
		// adjust NAV grid gragh bounds // edited by Mark
			Transform wallChild = wall.transform.GetChild(0);
			
			if(wallChild.name == "Wall")
				PathFinderUpdate.AddBounds(wallChild);
			else
				Debug.LogError("No wall child object");
			
		}
		// Build top wall
		for(int i = 0; i<xD; i++)
		{
			wall = (GameObject) GameObject.Instantiate(horizontalWall, new Vector3(leftTop.x+i,0F,leftTop.y), t.rotation);
			topWall.Add(wall);
			
			// adjust NAV grid gragh bounds // edited by Mark
			Transform wallChild = wall.transform.GetChild(0);
			
			if(wallChild.name == "Wall")
				PathFinderUpdate.AddBounds(wallChild);
			else
				Debug.LogError("No wall child object");
			
		}
		
		// flush NAV grid graph update. // edited by Mark
		//AstarPath.active.FlushGraphUpdates();
		
	}
	
	// Build a door
	public void buildDoor(GameObject door, Way way, Vector2 LBP, int xD, int yD)
	{
		doors.Add(door);
		
		//pass the child wall with the collider to the pathfinderUpdate
		foreach(Transform child in door.transform)
		{
			if(child.name == "Door 1")
			{
				PathFinderUpdate.AddBounds(child);	
			}
			
			if(child.name == "Door 2")
			{
				PathFinderUpdate.AddBounds(child);
			}
		}
		///end door graph code
		
		// If way is north
		if(way == Way.North)
		{
			bottomWall[(int)LBP.x-(int)leftBottom.x].SetActive(false);
			bottomWall[((int)LBP.x-(int)leftBottom.x)+1].SetActive(false);
			
		}
		// If way is east
		else if(way == Way.East)
		{
			leftWall[(int)LBP.y-(int)leftBottom.y].SetActive(false);
			leftWall[((int)LBP.y-(int)leftBottom.y)+1].SetActive(false);
		}
		// If way is south
		else if(way == Way.South)
		{
			topWall[(int)LBP.x-(int)leftBottom.x].SetActive(false);
			topWall[((int)LBP.x-(int)leftBottom.x)+1].SetActive(false);
		}
		// If way is west
		else if(way == Way.West)
		{
			rightWall[(int)LBP.y-(int)leftBottom.y].SetActive(false);
			rightWall[((int)LBP.y-(int)leftBottom.y)+1].SetActive(false);
		}
		
		// flush NAV grid graph update. // edited by mark
		//AstarPath.active.FlushGraphUpdates();
	}
	
	// Remove a door
	public void removeDoor(GameObject door, Way way, Vector2 LBP, int xD, int yD)
	{
		doors.Remove(door);
		// If way is north
		if(way == Way.North)
		{
			bottomWall[(int)LBP.x-(int)leftBottom.x].SetActive(true);
			bottomWall[((int)LBP.x-(int)leftBottom.x)+1].SetActive(true);
		}
		// If way is east
		else if(way == Way.East)
		{
			leftWall[(int)LBP.y-(int)leftBottom.y].SetActive(true);
			leftWall[((int)LBP.y-(int)leftBottom.y)+1].SetActive(true);
		}
		// If way is south
		else if(way == Way.South)
		{
			topWall[(int)LBP.x-(int)leftBottom.x].SetActive(true);
			topWall[((int)LBP.x-(int)leftBottom.x)+1].SetActive(true);
		}
		// If way is west
		else if(way == Way.West)
		{
			rightWall[(int)LBP.y-(int)leftBottom.y].SetActive(true);
			rightWall[((int)LBP.y-(int)leftBottom.y)+1].SetActive(true);
	
		}
	}
	
	// Delete all the items
	public void deleteItems()
	{
		// Delete the items
		for(int i = roomItems.Count-1; i >= 0; i--) 
		{
		    GameObject go = roomItems[i];
			Item itemPro = go.GetComponent<Item>();
			itemPro.removeItem(go);
		}	
	}
	
	// Delete the walls and doors of room
	public void deleteWallsDoors()
	{
		
		// Delete the doors
		for(int i = doors.Count-1; i >= 0; i--) 
		{
		    GameObject go = doors[i];
			
			//pass the child door with the collider to the pathfinderUpdate
			foreach(Transform child in go.transform)
			{
				if(child.name == "Door 1")
				{
					PathFinderUpdate.AddBounds(child);	
				}
				
				if(child.name == "Door 2")
				{
					PathFinderUpdate.AddBounds(child);
				}
			}
		///end door graph code
			
			Item itemPro = go.GetComponent<Item>();
			itemPro.removeItem(go);
		}
		
		// Delete left wall
		foreach(GameObject go in leftWall)
		{
			// adjust NAV grid gragh bounds // edited by Mark
			Transform wallChild = go.transform.GetChild(0);
			
			if(wallChild.name == "Wall")
				PathFinderUpdate.AddBounds(wallChild);
			else
				Debug.LogError("No wall child object");
			
			GameObject.Destroy(go);
		}
		// Delete right wall
		foreach(GameObject go in rightWall)
		{ 
			// adjust NAV grid gragh bounds // edited by Mark
			Transform wallChild = go.transform.GetChild(0);
			
			if(wallChild.name == "Wall")
				PathFinderUpdate.AddBounds(wallChild);
			else
				Debug.LogError("No wall child object");
			
			GameObject.Destroy(go);
		}
		// Delete bottom wall
		foreach(GameObject go in bottomWall)
		{
			// adjust NAV grid gragh bounds // edited by Mark
			Transform wallChild = go.transform.GetChild(0);
			
			if(wallChild.name == "Wall")
				PathFinderUpdate.AddBounds(wallChild);
			else
				Debug.LogError("No wall child object");
			
			GameObject.Destroy(go);
		}
		// Delete top wall
		foreach(GameObject go in topWall)
		{
			// adjust NAV grid gragh bounds // edited by Mark
			Transform wallChild = go.transform.GetChild(0);
			
			if(wallChild.name == "Wall")
				PathFinderUpdate.AddBounds(wallChild);
			else
				Debug.LogError("No wall child object");
			
			GameObject.Destroy(go);
		}
		// flush NAV grid graph update. // edited by Chan
		//AstarPath.active.FlushGraphUpdates();
	}
	
	// Delete the Item or Door
	public void deleteItem(GameObject gObject)
	{
		GameObject.Destroy(gObject);
	}
}

// Enum test
public enum Test
{
    None,
	Box
}

// Enum mode
public enum Mode
{
    None,
	RoomCreation,
    RoomFurnishing,
    RoomDeletion,
	StaffHiring
}

// Enum state
public enum State
{
    None,
	Purchase,
    Placement,
	Choose,
	Deletion,
	Move
}

// Enum room type
public enum RoomType
{
    None,
	Reception,
	StaffBreak,
	PatientWard,
	Diagnostics,
	SlimeTreatment,
	ShockTreatment,
	MagicPotion,
	PhysicalActivity
}

// Enum room type
public enum RectanglePosition
{
    None,
	LeftBottom,
	LeftTop,
	RightBottom,
	RightTop
}

// Enum direction
public enum Way
{
    None = 0,
	North = 1,
	East = 2,
	South = 3,
	West = 4
}

// Enum direction
public enum WayType
{
    None,
	OneWay,
	TwoWay,
	FourWay
}