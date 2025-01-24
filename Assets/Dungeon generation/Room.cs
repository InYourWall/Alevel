using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {

	public int Width;
	public int Height;
	public int X;
	public int Y;

	void start()
	{
		if(RoomManager.instance = null)
		{
			Debug.Log("WRong Scene");
			return;
		}
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(transform.position, new Vector3(Width,Height,0));
	}

	public Vector3 GetRoomCentre()
	{
		return new Vector3( X * Width, Y * Height);
	}

}
