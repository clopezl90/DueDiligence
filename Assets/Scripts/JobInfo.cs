using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class JobInfo : MonoBehaviour
{
    public static JobInfo instance;
    public Text thisJobDescription;
    public Text thisJobDescription2;
    public Text thisJobStatus;
    public Text thisJobReward;
    public Text thisJobTitle;
    public Text thisJobOverhead;
    public Text thisJobProfit;
    public Text thisJobContingency;
    public Dropdown clientsDropDown;
    public Text thisJobIssueDate;
    public Text thisJobExpiration;
    public Text thisJobEstimateExpiration;
    

    

    // Start is called before the first frame update

    public void Awake()
    {
        instance=this;
       
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AssingJobValues(Jobs jobToValue)
    {
        thisJobDescription.text = jobToValue.jobDescription;
        thisJobDescription2.text = jobToValue.jobDescription;
        thisJobStatus.text = jobToValue.jobStatus;
        thisJobReward.text = jobToValue.jobReward.ToString();
        thisJobTitle.text = jobToValue.jobDescription; 
        thisJobOverhead.text = jobToValue.overhead.ToString();
        thisJobProfit.text = jobToValue.profit.ToString();
        thisJobContingency.text = jobToValue.contingency.ToString();
        thisJobIssueDate.text = jobToValue.jobEstimateObject.issueDate;
        thisJobExpiration.text = jobToValue.jobEstimateObject.expirationPeriod.ToString() + " days";
        thisJobEstimateExpiration.text = jobToValue.jobEstimateObject.description;

        FillDropdownList();       
    }


    public void FillDropdownList()
    {
        List<string> names = new List<string>();        
        foreach (Clients c in UserData.clientsArray.clientsList)
        {          
            names.Add(c.clientName);
        }
        clientsDropDown.AddOptions(names);
    }
}


