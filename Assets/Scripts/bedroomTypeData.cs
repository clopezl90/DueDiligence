    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]

public class bedroomTypeData
{
    public string bedroomType;
    public float multiroomQuantityInComplex;
    
    public float multiRoomFootagePercentagePaint;
    public float materialMultiRoomFootagePaint;
    public float laborMultiRoomFootagePaint;
    
    public float materialCostMultiRoomPlugs;
    public float laborCostMultiRoomPlugs;
    
    public float materialCostMultiRoomSwitchLights;
    public float laborCostMultiroomSwitchLights;
    public float numberHalfBaths;
    public float footageHalfBaths;
    public float numberPlugsHalfBaths;
    public float numberSwitchesHalfBaths;
    

    #region Bedroom
    public float multiroomfootage;

    public float multiroomWindows;
    public float multiroomDoors;
    public float multiroomScreens;
    public float multiroomSmokeDetectors;
    public float multiroomLights;
    public float multiroomReceptacles;
    public float multiroomCeilingFans;
    public float multiroomClosets;
    public float multiroomClosetLights;
    public float multiroomPlugs;
    public float multiroomSwitchLights;


    #endregion

    #region Bathroom

    public float numberFullbaths;
    public float footageFullBaths;
    public float numberPlugsFullBaths;
    public float numberSwitchesFullBaths;
    public float numberTubFullBath;
    public float numberToiletFullBath;
    public float numberMirrorFullBath;
    public float numberReceptaclesFullBath;
    public float numberLightsFullBath;
    public float numberExhaustFanFullBath;
    public float numberSinkFullBath;
    public float numberTowelRodFullBath;
    public float numberCabinetsFullBath;    

    #endregion

    #region Living

    public float multiroomLivingWindows;
    public float multiroomLivingDoors;
    public float multiroomLivingReceptacles;
    public float multiroomLivingThresholds;
    public float multiroomLivingSmokeDetectors;
    public float multiroomLivingLights;    
    public float multiroomLivingCeilingFans;    

    #endregion

    #region Kitchen
    public float multiroomKitchenRangeHood;
    public float multiroomKitchenRefrigerators;
    public float multiroomKitchenSink;
    public float multiroomKitchenCabinets;
    public float multiroomKitchenMicrowave;
    public float multiroomKitchenReceptacles;
    public float multiroomKitchenLights;
    public float multiroomKitchenLightSwitches;
    public float multiroomKitchenbreakerPanels;

    #endregion


    #region Entry
    public float multiroomEntryKnocker;
    public float multiroomEntryPeephole;
    public float multiroomEntryThreshold;
    

    #endregion
    #region Hall
    public float multiroomHallSmokeDetector;
    public float multiroomHallSmokeLights;
    public float multiroomHallReceptacles;
    public float multiroomHallCeilingFans;
    

    #endregion




    public bedroomTypeData(){}

}
