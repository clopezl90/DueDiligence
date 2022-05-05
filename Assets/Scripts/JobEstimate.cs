using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]

public class JobEstimate 
{
    //public DateTime dateToIssue = DateTime.Now;
    public string issueDate = "";
    public int expirationPeriod = 30;
    public string description = "None";
    public int poNumber;
    public float estimateSubtotal;
    public float estimateOverhead;
    public float estimateProfit;
    public float estimateContingency;
    public float estimateDiscount;
    public List <EstimateItems> estimateList = new List<EstimateItems>();
    public JobEstimate (){}    
}
