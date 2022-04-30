using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]


public class Jobs 
{
    public string jobDescription;
    public string jobClient;
    public int jobReward;
    public string jobStatus;
    public Clients jobCientObject;


    public Jobs (string _jobDescription, string _jobClient, int _jobReward, string _jobStatus) 
    {
        jobDescription =_jobDescription;
        jobClient = _jobClient;
        jobReward = _jobReward;
        jobStatus = _jobStatus;
    }

    
}
