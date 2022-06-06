using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]

public class RoomData 
{
    public string roomName;
    public string roomType;
    public float roomFootage;
    public float roomFootagePercentagePaint;
    public float materialRoomFootagePaint;
    public float laborRoomFootagePaint;
    public float roomPlugs;
    public float materialCostRoomPlugs;
    public float laborCostRoomPlugs;
    public float roomPlates;
    public float materialCostRoomPlates;
    public float laborCostRoomPlates;
    public float roomSwitchLights;
    public float materialCostRoomSwitchLights;
    public float laborCostroomSwitchLights;
    public float numberOfCabinets;
    public float numberOfAppliances;

    public RoomData(){}
}
