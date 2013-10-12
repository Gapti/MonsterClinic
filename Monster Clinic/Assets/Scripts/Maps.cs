using UnityEngine;
using System.Collections;

// Maps class
public class Maps
{
	// Maps
	
	/// <summary>
	/// Floor map is used to keep track of map
	/// 0 for empty cell outside room
	/// 1 for non-empty cell outside room
	/// 2 for empty cell inside room
	/// 3 for non-empty cell inside room
	/// 4 for empty cell outside room door
	/// </summary>
	private static int [,] floorMap = new int[100,100];
	
	/// <summary>
	/// Room map is used to keep track of rooms
	/// 0 for no room
	/// 1,2,3...999 Room IDs
	/// </summary>
	private static int [,] roomMap = new int[100,100];
	
	/// <summary>
	/// Object map is used to keep track reference to game objects (walls and doors)
	/// </summary>
	/*private static GameObject [,] objectsMap = new GameObject[100,100];*/
	
	// Get floorMap value
	public static int GetFloorMapValue(Vector2 points)
	{
		return floorMap[(int)points.x, (int)points.y];
	}
	
	// Get floorMap value
	public static int GetFloorMapValue(int x, int y)
	{
		return floorMap[x,y];
	}
	
	// Set floorMap value
	public static void SetFloorMapValue(Vector2 points, int val)
	{
		floorMap[(int)points.x, (int)points.y] = val;
	}
	
	// Set floorMap value
	public static void SetFloorMapValue(int x, int y, int val)
	{
		floorMap[x,y] = val;
	}
	
	// Get roomMap value
	public static int GetRoomMapValue(Vector2 points)
	{
		return roomMap[(int)points.x, (int)points.y];
	}
	
	// Get roomMap value
	public static int GetRoomMapValue(int x, int y)
	{
		return roomMap[x,y];
	}
	
	// Set roomMap value
	public static void SetRoomMapValue(Vector2 points, int val)
	{
		roomMap[(int)points.x, (int)points.y] = val;
	}
	
	// Set floorMap value
	public static void SetRoomMapValue(int x, int y, int val)
	{
		roomMap[x,y] = val;
	}
	
	// Check is block in room map consist of specific value
	public static bool isRoomMapFill(Vector2 leftBottom, int xD, int yD, int val)
	{
		try
		{
			for(int i = 0; i<xD; i++)
			{
				for(int j = 0; j<yD; j++)
				{
					if(roomMap[((int)leftBottom.x)+i, ((int)leftBottom.y)+j] != val)
					{
						return false;
					}
				}
			}
		}
		catch
		{
			return false;
		}
		return true;
	}
	
	// Check is block in room map not consist of specific value
	public static bool isRoomMapNotFill(Vector2 leftBottom, int xD, int yD, int val)
	{
		try
		{
			for(int i = 0; i<xD; i++)
			{
				for(int j = 0; j<yD; j++)
				{
					if(roomMap[((int)leftBottom.x)+i, ((int)leftBottom.y)+j] == val)
					{
						return false;
					}
				}
			}
		}
		catch
		{
			return false;
		}
		return true;
	}
	
	// Check is block in floor map consist of specific value
	public static bool isFloorMapFill(Vector2 leftBottom, int xD, int yD, int val)
	{
		try
		{
			for(int i = 0; i<xD; i++)
			{
				for(int j = 0; j<yD; j++)
				{
					if(floorMap[((int)leftBottom.x)+i, ((int)leftBottom.y)+j] != val)
					{
						return false;
					}
				}
			}
		}
		catch
		{
			return false;
		}
		return true;
	}
	
	// Check is block in floor map not consist of specific value
	public static bool isFloorMapNotFill(Vector2 leftBottom, int xD, int yD, int val)
	{
		try
		{
			for(int i = 0; i<xD; i++)
			{
				for(int j = 0; j<yD; j++)
				{
					if(floorMap[((int)leftBottom.x)+i, ((int)leftBottom.y)+j] == val)
					{
						return false;
					}
				}
			}
		}
		catch
		{
			return false;
		}
		return true;
	}
	
	// Set specific value in floor map block
	public static void setFloorMapBlock(Vector2 leftBottom, int xD, int yD, int val)
	{
		for(int i = 0; i<xD; i++)
		{
			for(int j = 0; j<yD; j++)
			{
				floorMap[((int)leftBottom.x)+i, ((int)leftBottom.y)+j] = val;
			}
		}
	}
	
	// Set specific value in room map block
	public static void setRoomMapBlock(Vector2 leftBottom, int xD, int yD, int val)
	{
		for(int i = 0; i<xD; i++)
		{
			for(int j = 0; j<yD; j++)
			{
				roomMap[((int)leftBottom.x)+i, ((int)leftBottom.y)+j] = val;
			}
		}
	}
	
	/*
	// Get objectsMap value
	public static GameObject GetObjectsMapValue(Vector2 points)
	{
		return objectsMap[(int)points.x, (int)points.y];
	}
	
	// Get objectsMap value
	public static GameObject GetObjectsMapValue(int x, int y)
	{
		return objectsMap[x,y];
	}
	
	// Set objectsMap value
	public static void SetObjectsMapValue(Vector2 points, GameObject val)
	{
		objectsMap[(int)points.x, (int)points.y] = val;
	}
	
	// Set objectsMap value
	public static void SetObjectsMapValue(int x, int y, GameObject val)
	{
		objectsMap[x,y] = val;
	}
	
	// Delete objectsMap value
	public static void DeleteObjectsMapValue(Vector2 points)
	{
		GameObject.Destroy(objectsMap[(int)points.x, (int)points.y]);
	}
	
	// Delete objectsMap value
	public static void DeleteObjectsMapValue(int x, int y)
	{
		GameObject.Destroy(objectsMap[x,y]);
	}*/
}
