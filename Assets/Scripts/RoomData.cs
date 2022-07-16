using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]

public class RoomData
{
    #region name and type

    public string roomName;
    public string roomType;
    #endregion

    #region paint

    public float roomFootage;
    public float roomFootagePercentagePaint;
    public float materialRoomFootagePaint;
    public float laborRoomFootagePaint;

    #endregion

    #region items 
    public float roomPlugs;
    public float roomPlates;
    public float roomSwitchLights;

    public float roomEntries;
    public float roomDoorAndFrames;
    public float roomThreshold;
    public float roomPeepHole;
    public float roomClosets;
    public float roomClosetDoors;
    public float roomClosetShelfs;
    public float roomClosetRod;
    public float roomClosetLights;
    public float numberOfCabinets;
    public float numberOfAppliances;
    #endregion

    #region costs

    public float materialCostRoomPlugs;
    public float laborCostRoomPlugs;

    public float materialCostRoomPlates;
    public float laborCostRoomPlates;

    public float materialCostRoomSwitchLights;
    public float laborCostroomSwitchLights;

    #endregion

    public RoomData() { }
}
