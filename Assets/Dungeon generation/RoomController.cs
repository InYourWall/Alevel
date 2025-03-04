﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomInfo
	{
		public string name;
		public int x;
		public int y;
	}

public class RoomManager : MonoBehaviour {

	public static RoomManager instance;

	string currentWorldName = "Floor 1";

	RoomInfo currentLoadRoomData;

	Queue<RoomInfo> loadRoomQueue = new Queue<RoomInfo>();

	public List<Room> loadedRooms = new List<Room>();

	bool isLoadingRoom = false;

	void Awake()
	{
		instance = this;
	}

	public bool DoesRoomExist(int x, int y)
	{
		return loadedRooms.Find( item => item.X == x && item.Y == y) != null;
	}





}
