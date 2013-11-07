using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;

// Item Class
public class Item : MonoBehaviour 
{
	// Public static variables
	public static int itemIdCounter = 0;
	
	// Public variables
	public int itemId;
	public int no;
	public string name;
	public string description;
	public int cost;
	public int widthInCells;
	public int heightInCells;
	public WayType wayType;
	public RoomType [] validRooms;
	public bool onWalls;
	public bool sharedWall;
	public bool locked;
	
	// Private variables
	private Vector2 leftBottomPosition;
	private int hDistance;
	private int vDistance;
	private Way way;
	private Room assignedRoom;
	
	void Start()
	{
		// Initialize the variables
		leftBottomPosition = new Vector2(-1,-1);
		hDistance = widthInCells;
		vDistance = heightInCells;
		way = Way.North;
		
		// Check if any wall placing item has height more then 1, throw error
		if(onWalls)
		{
			if(heightInCells > 1)
			{
				Debug.LogError("Item No: "+no+" and Item Name: "+name+" must have Height: 1");
			}
		}
		// Check if any wall placing item has other then four type way type, throw error
		if(onWalls)
		{
			if(wayType != WayType.FourWay)
			{
				Debug.LogError("Item No: "+no+" and Item Name: "+name+" must have Way Type: Four Way");
			}
		}
	}
	
	// Build the item
	public void buildItem(GameObject buildItem)
	{
		itemId = ++itemIdCounter;
		Maps.setFloorMapBlock(leftBottomPosition, hDistance, vDistance,3);
		
		// If it is a door
		if(no == 1)
		{
			assignedRoom.buildDoor(buildItem, way, leftBottomPosition, hDistance, vDistance);
			Vector2 newLeftBottom = new Vector2();
			// If way is north
			if(way == Way.North)
			{
				newLeftBottom = new Vector2(leftBottomPosition.x, leftBottomPosition.y-1F);
			}
			// If way is east
			else if(way == Way.East)
			{
				newLeftBottom = new Vector2(leftBottomPosition.x-1F, leftBottomPosition.y);				
			}
			// If way is south
			else if(way == Way.South)
			{
				newLeftBottom = new Vector2(leftBottomPosition.x, leftBottomPosition.y+1F);
			}
			// If way is west
			else if(way == Way.West)
			{
				newLeftBottom = new Vector2(leftBottomPosition.x+1F, leftBottomPosition.y);
			}
			Maps.setFloorMapBlock(newLeftBottom, hDistance, vDistance, 4);
		}
		// If it is not a door, its item
		
		///bench added by mark
		else if(no ==2 )
		{
			assignedRoom.roomItems.Add(buildItem);
			
			Transform seat = buildItem.transform.GetChild(1);
				
			if(seat.name == "Seat")
				PathFinderUpdate.AddBounds(seat);
			else
				Debug.LogError("it must be the seat with the collider");
		}
		else
		{
			assignedRoom.roomItems.Add(buildItem);
			Debug.Log (buildItem.name);
		}
		
		//AstarPath.active.FlushGraphUpdates();
	}
	
	// Remove the item
	public void removeItem(GameObject buildItem)
	{
		Maps.setFloorMapBlock(leftBottomPosition, hDistance, vDistance,2);
		
		// If it is a door
		if(no == 1)
		{
			assignedRoom.removeDoor(buildItem, way, leftBottomPosition, hDistance, vDistance);
			Vector2 newLeftBottom = new Vector2();
			// If way is north
			if(way == Way.North)
			{
				newLeftBottom = new Vector2(leftBottomPosition.x, leftBottomPosition.y-1F);
			}
			// If way is east
			else if(way == Way.East)
			{
				newLeftBottom = new Vector2(leftBottomPosition.x-1F, leftBottomPosition.y);				
			}
			// If way is south
			else if(way == Way.South)
			{
				newLeftBottom = new Vector2(leftBottomPosition.x, leftBottomPosition.y+1F);
			}
			// If way is west
			else if(way == Way.West)
			{
				newLeftBottom = new Vector2(leftBottomPosition.x+1F, leftBottomPosition.y);
			}
			Maps.setFloorMapBlock(newLeftBottom, hDistance, vDistance, 0);
		}
		// If it is not a door, its item
		///its a bench edited by mark
		else if(no == 2)
		{
			Transform seat = buildItem.transform.GetChild(1);
				
			if(seat.name == "Seat")
				PathFinderUpdate.AddBounds(seat);
			else
				Debug.LogError("it must be the seat with the collider");
			
			assignedRoom.roomItems.Remove(buildItem);	
		}
		else
		{
			assignedRoom.roomItems.Remove(buildItem);
		}
		
		// Delete the game object
		assignedRoom.deleteItem(buildItem);
		
		//AstarPath.active.FlushGraphUpdates();
	}
	
	public Vector2 getLeftBottomPosition()
	{
		return leftBottomPosition;
	}
	
	public void setLeftBottomPosition(Vector2 LB)
	{
		leftBottomPosition.x = LB.x;
		leftBottomPosition.y = LB.y;
	}

	public int getHDistance()
	{
		return hDistance;
	}
	
	public int getVDistance()
	{
		return vDistance;
	}
	
	public Way getWay()
	{
		return way;
	}
	
	public Room getAssignedRoom()
	{
		return assignedRoom;
	}
	
	public void setAssignedRoom(Room room)
	{
		assignedRoom = room;
	}
	
	// Adjust the position with respect to rotation
	public void itemPositionAdjustment(Vector2 pointed)
	{
		// If way is north
		if(way == Way.North)
		{
			transform.position =  new Vector3(pointed.x, 0F, pointed.y);
		}
		// If way is east
		else if(way == Way.East)
		{
			transform.position =  new Vector3(pointed.x, 0F, pointed.y+widthInCells);
		}
		// If way is south
		else if(way == Way.South)
		{
			transform.position =  new Vector3(pointed.x+widthInCells, 0F, pointed.y+heightInCells);
		}
		// If way is west
		else if(way == Way.West)
		{
			transform.position =  new Vector3(pointed.x+heightInCells, 0F, pointed.y);
		}
	}
	
	// Rotate with respect to way type
	public void rotate()
	{	
		// If way type is one way, then don't rotate
		if(wayType == WayType.OneWay)
		{
			return;
		}
		// If way type is two way
		else if(wayType == WayType.TwoWay)
		{
			// If way is north, change to east
			if(way == Way.North)
			{
				way = Way.East;
				hDistance = heightInCells;
				vDistance = widthInCells;
				transform.Rotate(0F, 90F, 0F);
			}
			// If way is east, change to east
			else if(way == Way.East)
			{
				way = Way.North;
				hDistance = widthInCells;
				vDistance = heightInCells;
				transform.Rotate(0F, -90F, 0F);
			}
		}
		// If way type is four way
		else if(wayType == WayType.FourWay)
		{
			int wayCode = (int)way;
			wayCode++;
			if(wayCode == 5)
			{
				wayCode = 1;
			}
			way =(Way)wayCode;
			transform.Rotate(0F, 90F, 0F);
			
			if(way == Way.North || way == Way.South)
			{
				hDistance = widthInCells;
				vDistance = heightInCells;
			}
			else if(way == Way.East || way == Way.West)
			{
				hDistance = heightInCells;
				vDistance = widthInCells;
			}
		}
	}
	
	// Check if the location of tile is valid
	public bool isValid()
	{
		// Check the room type validity
		bool roomTypeCheck = false;
		foreach(RoomType rt in validRooms)
		{
			if(assignedRoom.type == rt)
			{
				roomTypeCheck = true;
			}
		}
		if(!roomTypeCheck)
		{
			return false;
		}
		
		// Check the room placement (inside selected room)
		if(!Maps.isRoomMapFill(leftBottomPosition, hDistance, vDistance, assignedRoom.roomId))
		{
			return false;
		}
		
		// Check the floor vacancy in room for placement
		if(!Maps.isFloorMapFill(leftBottomPosition, hDistance, vDistance, 2))
		{
			return false;
		}
		
		// If can only be placed on walls
		if(onWalls)
		{
			// If way is north
			if(way == Way.North)
			{
				// If object is not on border edge of south wall
				if(leftBottomPosition.y != 0)
				{
					// If it is not on south wall
					Vector2 newLeftBottom = new Vector2(leftBottomPosition.x, leftBottomPosition.y-1F);
					if(!Maps.isRoomMapNotFill(newLeftBottom, hDistance, vDistance, assignedRoom.roomId))
					{
						return false;
					}
				}
			}
			// If way is east
			else if(way == Way.East)
			{
				// If object is not on border edge of west wall
				if(leftBottomPosition.x != 0)
				{
					// If it is not on west wall
					Vector2 newLeftBottom = new Vector2(leftBottomPosition.x-1F, leftBottomPosition.y);
					if(!Maps.isRoomMapNotFill(newLeftBottom, hDistance, vDistance, assignedRoom.roomId))
					{
						return false;
					}
				}
			}
			// If way is south
			else if(way == Way.South)
			{
				// If object is not on border edge of north wall
				if(leftBottomPosition.y != 99)
				{
					// If it is not on north wall
					Vector2 newLeftBottom = new Vector2(leftBottomPosition.x, leftBottomPosition.y+1F);
					if(!Maps.isRoomMapNotFill(newLeftBottom, hDistance, vDistance, assignedRoom.roomId))
					{
						return false;
					}
				}
			}
			// If way is west
			else if(way == Way.West)
			{
				// If object is not on border edge of east wall
				if(leftBottomPosition.x != 99)
				{
					// If it is not on eest wall
					Vector2 newLeftBottom = new Vector2(leftBottomPosition.x+1F, leftBottomPosition.y);
					if(!Maps.isRoomMapNotFill(newLeftBottom, hDistance, vDistance, assignedRoom.roomId))
					{
						return false;
					}
				}
			}
		}
		
		// If can only be placed on walls and adjacent / shared walls are not allowed
		if(onWalls && !sharedWall)
		{
			// If way is north
			if(way == Way.North)
			{
				// If object on border edge of south wall
				if(leftBottomPosition.y == 0)
				{
					return false;
				}
				// If it is not shared
				Vector2 newLeftBottom = new Vector2(leftBottomPosition.x, leftBottomPosition.y-1F);
				if(!Maps.isFloorMapFill(newLeftBottom, hDistance, vDistance, 0))
				{
					return false;
				}
			}
			// If way is east
			else if(way == Way.East)
			{
				// If object is not on border edge of west
				if(leftBottomPosition.x == 0)
				{
					return false;
				}
				// If it is not shared
				Vector2 newLeftBottom = new Vector2(leftBottomPosition.x-1F, leftBottomPosition.y);
				if(!Maps.isFloorMapFill(newLeftBottom, hDistance, vDistance, 0))
				{
					return false;
				}
			}
			// If way is south
			else if(way == Way.South)
			{
				// If object is on border edge of north wall
				if(leftBottomPosition.y == 99)
				{
					return false;
				}
				// If it is not shared
				Vector2 newLeftBottom = new Vector2(leftBottomPosition.x, leftBottomPosition.y+1F);
				if(!Maps.isFloorMapFill(newLeftBottom, hDistance, vDistance, 0))
				{
					return false;
				}
			}
			// If way is west
			else if(way == Way.West)
			{
				// If object is on border edge of east wall
				if(leftBottomPosition.x == 99)
				{
					return false;
				}
				// If it is not shared
				Vector2 newLeftBottom = new Vector2(leftBottomPosition.x+1F, leftBottomPosition.y);
				if(!Maps.isFloorMapFill(newLeftBottom, hDistance, vDistance, 0))
				{
					return false;
				}
			}
		}
		return true;
	}
}
