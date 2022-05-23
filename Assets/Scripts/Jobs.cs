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
    public double overhead = 10;
    public double profit = 10;
    public double contingency = 15;
    public double discount = 0; 
    public double taxes = 10;
    public double jobGlobalAmount;
    public List <RoomData> roomsList = new List <RoomData> ();
    


    public Jobs (string _jobDescription, string _jobSite, string _jobStatus) 
    {
        jobDescription =_jobDescription;          
        jobSite = _jobSite;
        jobStatus = _jobStatus;
    }

    
}
