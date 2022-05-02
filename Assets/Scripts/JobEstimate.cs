using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]

public class JobEstimate 
{
    public DateTime dateToIssue = DateTime.Now;
    public string issueDate = "02/05/2022";
    public int expirationPeriod = 30;
    public string description = "None";
    public int poNumber;
    public EstimateItems estimateItems;
    public JobEstimate (){}    
}
