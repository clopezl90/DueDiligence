using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]


public class Jobs 
{
    public string jobDescription;
    public int jobReward;
    public string jobStatus;
    public string jobTag;
    public string jobSite;
    public Clients jobCientObject;
    public Orders jobOrdersObject;
    public JobEstimate jobEstimateObject;
    public JobPayments jobPaymentsObject;
    public string projectType;
    public string projectLocation;
    public float overhead = 10;
    public float profit = 10;
    public float contingency = 15;
    public float discount = 0; 
    public float taxes = 10;
    public float jobGlobalAmount;
    public List <RoomData> roomsList = new List <RoomData> ();
    public List <bedroomTypeData> bedroomsTypeList = new List<bedroomTypeData>();
    


    public Jobs (string _jobDescription, string _jobSite, string _jobStatus) 
    {
        jobDescription =_jobDescription;          
        jobSite = _jobSite;
        jobStatus = _jobStatus;
        jobEstimateObject = new JobEstimate(); 
    }

    
}
