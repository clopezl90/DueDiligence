using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomSingleLoader : MonoBehaviour
{
    public RoomData thisRoom;

    // Start is called before the first frame update
    private void Awake()
    {

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SendRoomValues()
    {
        JobInfo.instance.AssignRoomValues(thisRoom);        
        //JobTitleHeader.text = thisJob.jobDescription;
        /* JobTitleHeader.text = thisJob.jobDescription;
        jobDescriptionDashboard.text = thisJob.jobDescription; */


    }
}
