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
    public int overhead = 10;
    public int profit = 10;
    public int contingency = 15;


    public Jobs (string _jobDescription, int _jobReward, string _jobStatus) 
    {
        jobDescription =_jobDescription;     
          
        jobReward = _jobReward;
        jobStatus = _jobStatus;
    }

    
}
