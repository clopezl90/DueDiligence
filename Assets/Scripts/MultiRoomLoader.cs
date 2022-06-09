using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiRoomLoader : MonoBehaviour
{
    public bedroomTypeData thisRoom;

    public void SendMultiRoomValues()
    {
        JobInfo.instance.AssingBedroomValues(thisRoom);

    }
}
