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
    public Toggle toggleJobTemplate;
    public GameObject jobToAddInfo;
    public GameObject templatetoAdd;


    public Text thisJobSite;

    [Header("Job info")]
    public Text thisJobTitle;

    public Text thisJobOverhead;

    public Text thisJobProfit;

    public Text thisJobContingency;
    public Text thisJobDiscount;
    public Toggle[] stateToggles;
    public Toggle[] tagToggles;
    public InputField jobTitleText;
    //public Text jobTitletext;
    public Dropdown clientsDropDownCustomer;
    public Text jobCustomerText;
    public string noneText = "None";
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
    public InputField itemLaborCost;
    public Text itemEstimateDescription;
    public Text itemEstimateValue;
    public Text itemsEstimateSubtotal;
    public Text itemsEstimateOverhead;
    public Text itemsEstimateProfit;
    public Text itemsEstimateContingency;
    public Text itemEstimateMarkup;
    public Text itemEstimateDiscount;
    public Text itemEstimatetaxes;
    public Text itemFinalPriceWithDiscount;
    public Text itemsEstimateFinalPrice;
    public Text itemText;
    public Text itemCost;
    double subtotalCounter;
    double overheadCouter;
    double profitCounter;
    double contingencyCounter;
    double discountCounter;
    double taxesCounter;
    double itemFinalPriceCounter;
    double itemFinalPriceCounterDiscount;
    double itemFinalPriceCounterTaxes;
    int itemscounter = 0;
    public GameObject itemsInfo;
    public Transform itemsTransform;

    [Header("ItemInfo")]
    public InputField itemSelectedName;
    public InputField itemSelectedDescription;
    public InputField itemSelectedQuantity;
    public InputField itemSelectedMaterialCost;
    public InputField itemSelectedLaborCost;

    [Header("OverheadInfo")]

    public InputField overheadInputfield;
    [Header("profiInfo")]

    public InputField profitInputfield;
    [Header("ContingencyInfo")]

    public InputField contingencyInputfield;
    [Header("DiscountInfo")]

    public InputField discountInputfield;

    [Header("TaxesInfo")]

    public InputField taxesInputfield;

    [Header("RoomInfo")]
    public InputField roomNameText;
    public Text roomTypeText;
    public InputField roomFootageText;
    public InputField roomPlugsText;
    public InputField roomPlatesText;
    public InputField roomSwitchLightsText;

    public Text roomName;
    public Text roomFootage;
    public GameObject roomsInfo;
    public Transform roomsTransform;
    public Dropdown roomTypeDropdown;
    public Text bedroomsTotalFootage;
    public float footageBedroomsCounter;
    public float footageHalfbathCounter;
    public float footageFullbathCounter;
    public float footageKitchenCounter;
    public float footageLivingCounter;
    public float footageDinningCounter;



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
        thisJobDiscount.text = jobToValue.discount.ToString();
        //Estimate
        thisJobIssueDate.text = jobToValue.jobEstimateObject.issueDate;
        thisJobExpiration.text = jobToValue.jobEstimateObject.expirationPeriod.ToString() + " days";
        thisJobEstimateExpiration.text = jobToValue.jobEstimateObject.description;
        if (jobToValue.jobEstimateObject.estimateList.Count != 0)
        {
            foreach (EstimateItems item in UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).jobEstimateObject.estimateList)
            {
                itemscounter++;
                item.itemOverhead = item.itemSubtotal * (UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).overhead / 100);
                item.itemProfit = item.itemSubtotal * (UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).profit / 100);
                item.itemContingency = item.itemSubtotal * (UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).contingency / 100);
                item.itemDiscount = item.itemSubtotal * (UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).discount / 100);
                item.itemTaxes = item.itemSubtotal * (UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).taxes / 100);
                subtotalCounter = subtotalCounter + item.itemSubtotal;
                overheadCouter = overheadCouter + item.itemOverhead;
                profitCounter = profitCounter + item.itemProfit;
                contingencyCounter = contingencyCounter + item.itemContingency;
                discountCounter = discountCounter + item.itemDiscount;
                taxesCounter = taxesCounter + item.itemTaxes;
            }
        }
        itemsEstimateSubtotal.text = "$" + subtotalCounter.ToString();
        itemsEstimateOverhead.text = "$" + overheadCouter.ToString();
        itemsEstimateProfit.text = "$" + profitCounter.ToString();
        itemsEstimateContingency.text = "$" + contingencyCounter.ToString();
        itemEstimateDiscount.text = "$" + discountCounter.ToString();
        itemEstimatetaxes.text = "$" + taxesCounter.ToString();
        itemFinalPriceCounter = subtotalCounter + overheadCouter + profitCounter + contingencyCounter;
        itemEstimateMarkup.text = "$" + itemFinalPriceCounter.ToString();
        itemFinalPriceCounterDiscount = itemFinalPriceCounter - discountCounter;
        itemFinalPriceWithDiscount.text = "$" + itemFinalPriceCounterDiscount.ToString();
        itemsEstimateFinalPrice.text = "$" + (itemFinalPriceCounterDiscount + taxesCounter).ToString();
        UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).jobGlobalAmount = itemFinalPriceCounter;
        itemscounter = 0;
        subtotalCounter = 0;
        overheadCouter = 0;
        profitCounter = 0;
        contingencyCounter = 0;
        
        foreach (RoomData room in activeJob.roomsList)
        {
            if (room.roomType == "Bedroom")
            {
                footageBedroomsCounter = footageBedroomsCounter + room.roomFootage;
            }
            if (room.roomType == "Half bath")
            {
                footageHalfbathCounter = footageHalfbathCounter + room.roomFootage;
            }
            if (room.roomType == "Full bath")
            {
                footageFullbathCounter = footageFullbathCounter + room.roomFootage;
            }

        }
        bedroomsTotalFootage.text = footageBedroomsCounter.ToString() + " ft2";
        footageBedroomsCounter = 0;



    }
    public void OnBackButton()
    {
        AssingJobValues(activeJob);
    }

    public void ToogleJobTemplatechanged()
    {
        if (toggleJobTemplate.isOn)
        {
            templatetoAdd.SetActive(true);
            jobToAddInfo.SetActive(false);
        }
        else
        {
            templatetoAdd.SetActive(false);
            jobToAddInfo.SetActive(true);
        }
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
    }

    public void UpdateEstimateItems()
    {
        CleanEstimateItems();
        foreach (EstimateItems item in UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).jobEstimateObject.estimateList)
        {
            itemText.text = item.itemDescription;
            itemCost.text = "$" + item.itemSubtotal.ToString();
            GameObject _tempGo = Instantiate(itemsInfo, itemsTransform);
        }
    }
    public void CleanEstimateItems()
    {
        foreach (Transform child in itemsTransform.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
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
            //thisJobDescription.text = jobTitleText.text;
            AssingJobValues(activeJob);
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
        else
        {
            return;
        }
    }
    public void sendEstimate()
    {
        EstimateItems itemEstimate = new EstimateItems(itemName.text);
        itemEstimate.itemDescription = itemDescription.text;
        itemEstimate.itemQuantity = int.Parse(itemQuantity.text);
        itemEstimate.itemMaterialCost = double.Parse(itemMaterialCost.text);
        itemEstimate.itemLaborCost = double.Parse(itemLaborCost.text);
        itemEstimate.itemSubtotal = ((itemEstimate.itemMaterialCost + itemEstimate.itemLaborCost) * itemEstimate.itemQuantity);
        UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).jobEstimateObject.estimateList.Add(itemEstimate);
        UserData.instance.SendInfo();
        AssingJobValues(activeJob);
        itemName.text = "";
        itemDescription.text = "";
        itemMaterialCost.text = "";
        itemLaborCost.text = "";
        itemQuantity.text = "";
    }
    public void OverheadChange()
    {
        if (!string.IsNullOrEmpty(overheadInputfield.text))
        {
            UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).overhead = double.Parse(overheadInputfield.text);
            UserData.instance.SendInfo();
            overheadInputfield.text = "";
            AssingJobValues(activeJob);
        }
    }
    public void ProfitChange()
    {
        if (!string.IsNullOrEmpty(profitInputfield.text))
        {
            UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).profit = double.Parse(profitInputfield.text);
            UserData.instance.SendInfo();
            profitInputfield.text = "";
            AssingJobValues(activeJob);
        }
    }
    public void ContingencyChange()
    {
        if (!string.IsNullOrEmpty(contingencyInputfield.text))
        {
            UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).contingency = double.Parse(contingencyInputfield.text);
            UserData.instance.SendInfo();
            contingencyInputfield.text = "";
            AssingJobValues(activeJob);
        }
    }
    public void DiscountChange()
    {
        if (!string.IsNullOrEmpty(discountInputfield.text))
        {
            UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).discount = double.Parse(discountInputfield.text);
            UserData.instance.SendInfo();
            discountInputfield.text = "";
            AssingJobValues(activeJob);
        }
    }
    public void TaxesChange()
    {
        if (!string.IsNullOrEmpty(taxesInputfield.text))
        {
            UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).taxes = double.Parse(taxesInputfield.text);
            UserData.instance.SendInfo();
            taxesInputfield.text = "";
            AssingJobValues(activeJob);
        }
    }
    public void AssingItemValues(EstimateItems itemToValue)
    {
        itemSelectedName.text = itemToValue.itemName;
        itemSelectedDescription.text = itemToValue.itemDescription;
        itemSelectedQuantity.text = itemToValue.itemQuantity.ToString();
        itemSelectedMaterialCost.text = itemToValue.itemMaterialCost.ToString();
        itemSelectedLaborCost.text = itemToValue.itemLaborCost.ToString();
    }
    public void sendRoom()
    {
        RoomData roomData = new RoomData();        
        roomData.roomName = roomNameText.text;
        roomData.roomType = roomTypeText.text;
        roomData.roomFootage = float.Parse(roomFootageText.text);
        roomData.roomPlugs = float.Parse(roomPlugsText.text);
        roomData.roomPlates = float.Parse(roomPlatesText.text);
        roomData.roomSwitchLights = float.Parse(roomSwitchLightsText.text);
        UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).roomsList.Add(roomData);
        UserData.instance.SendInfo();
        AssingJobValues(activeJob);
        roomNameText.text = "";
        roomTypeText.text = "";
        roomFootageText.text = "";
        roomPlugsText.text = "";
        roomPlatesText.text = "";
        roomSwitchLightsText.text = "";
    }
    public void UpdateRooms()
    {
        CleanRoomItems();
        FillRoomTypeDropdown();
        AssingJobValues(activeJob);
        foreach (RoomData rooms in UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).roomsList)
        {
            roomName.text = rooms.roomName;
            roomFootage.text = rooms.roomFootage.ToString() + " ft2";
            GameObject _tempGo = Instantiate(roomsInfo, roomsTransform);
        }
    }

    public void CleanRoomItems()
    {
        foreach (Transform child in roomsTransform.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    public void FillRoomTypeDropdown()
    {
        List<string> roomType = new List<string>();
        roomType.Add("Living room");
        roomType.Add("Bedroom");
        roomType.Add("Kitchen");
        roomType.Add("Dinning room");
        roomType.Add("Full bath");
        roomType.Add("Half bath");
        roomTypeDropdown.AddOptions(roomType);
    }
}


