using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class JobInfo : MonoBehaviour
{
    public static JobInfo instance;
    public Jobs activeJob;
    public Clients thisJobClientsObject;
    public Text mainTitleJob;
    [Header("Instances")]
    public Text thisJobDescription;
    [Header("Job Dashboard")]
    public Text thisJobDescription2;
    public Text thisJobStatus;
    public Text thisJobReward;

    public Text thisJobClientName;
    public Text thisJobClientCompany;
    public Text thisJobClientPhone;
    public Text thisJobClientEmail;

    public Text thisJobSite;

    [Header("Job info")]
    public Text thisJobTitle;

    public Text thisJobOverhead;

    public Text thisJobProfit;

    public Text thisJobContingency;
    public Toggle[] stateToggles;
    public Toggle[] tagToggles;
    public InputField jobTitleText;
    //public Text jobTitletext;
    public Dropdown clientsDropDownCustomer;
    public Text jobCustomerText;
    public string noneText = "";
    public Dropdown clientsDropDown;
    [Header("Job estimate")]
    public Text thisJobIssueDate;
    public Text thisJobExpiration;
    public Text thisJobEstimateExpiration;
    [Header("EstimateInfo")]
    public InputField itemName;
    public InputField itemDescription;
    public InputField itemQuantity;
    public InputField itemMaterialCost;



    public void Awake()
    {
        instance = this;

    }
    void Start()
    {

    }

    void Update()
    {

    }
    public void AssingJobValues(Jobs jobToValue)
    {

        activeJob = jobToValue;
        mainTitleJob.text = jobToValue.jobDescription;

        // Header
        thisJobDescription.text = jobToValue.jobDescription;
        //Info
        thisJobDescription2.text = jobToValue.jobDescription;
        thisJobStatus.text = jobToValue.jobStatus;
        thisJobReward.text = jobToValue.jobReward.ToString();
        thisJobClientName.text = jobToValue.jobCientObject.clientName;
        thisJobClientCompany.text = jobToValue.jobCientObject.clientCompany;
        thisJobClientPhone.text = jobToValue.jobCientObject.clientPhone;
        thisJobClientName.text = jobToValue.jobCientObject.clientName;
        thisJobSite.text = jobToValue.jobSite;
        thisJobTitle.text = jobToValue.jobDescription;
        thisJobOverhead.text = jobToValue.overhead.ToString();
        thisJobProfit.text = jobToValue.profit.ToString();
        thisJobContingency.text = jobToValue.contingency.ToString();
        //Estimate
        thisJobIssueDate.text = jobToValue.jobEstimateObject.issueDate;
        thisJobExpiration.text = jobToValue.jobEstimateObject.expirationPeriod.ToString() + " days";
        thisJobEstimateExpiration.text = jobToValue.jobEstimateObject.description;

    }
    public void OnBackButton()
    {
        AssingJobValues(activeJob);
    }
    public void FillDropdownList()
    {
        clientsDropDown.ClearOptions();
        List<string> names = new List<string>();
        names.Add(noneText);
        foreach (Clients c in UserData.clientsArray.clientsList)
        {
            names.Add(c.clientName);
        }
        clientsDropDown.AddOptions(names);
        //      clientsDropDownCustomer.AddOptions(names);

    }

    public void ToogleChangedStatus()
    {
        foreach (Toggle toggle in stateToggles)
        {
            if (toggle.isOn)
            {
                UserData.jobsArray.jobsList.Find(Jobs => Jobs.jobCientObject.clientName == activeJob.jobCientObject.clientName).jobStatus = toggle.name;
                UserData.instance.SendInfo();
            }
        }
    }
    public void ToogleChangedTag()
    {
        foreach (Toggle toggle in tagToggles)
        {
            if (toggle.isOn)
            {
                UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).jobTag = toggle.name;
                /* AssingJobValues(activeJob);
                print("se envio la informacion"); */
                UserData.instance.SendInfo();
            }
        }
    }

    public void JobTitleChanged()
    {
        if (!string.IsNullOrEmpty(jobTitleText.text))
        {
            UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).jobDescription = jobTitleText.text;
            UserData.instance.SendInfo();
            jobTitleText.text = "";
        }
        else
        {
            return;
        }
    }
    public void jobCustomerChanged()
    {
        if (jobCustomerText.text != UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).jobCientObject.clientName || jobCustomerText.text != "")
        {
            foreach (Clients client in UserData.clientsArray.clientsList)
            {
                print(jobCustomerText + client.clientName);
                if (jobCustomerText.text == client.clientName)
                {
                    UserData.jobsArray.jobsList[0].jobCientObject = client;
                }
            }
            UserData.instance.SendInfo();
        }
    }

    public void sendEstimate()
    {
        EstimateItems itemEstimate = new EstimateItems(itemName.text);
        itemEstimate.itemDescription = itemDescription.text;
        itemEstimate.itemQuantity = int.Parse(itemQuantity.text);
        itemEstimate.itemMaterialCost = float.Parse(itemMaterialCost.text);
        UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).jobEstimateObject.estimateList.Add(itemEstimate);
        UserData.instance.SendInfo();

    }
}

