using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class JobInfo : MonoBehaviour
{
    public static JobInfo instance;
    public Jobs activeJob;
    public RoomData activeRoom;
    public bedroomTypeData activeMultiroom;
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
    float subtotalCounter;
    float overheadCouter;
    float profitCounter;
    float contingencyCounter;
    float discountCounter;
    float taxesCounter;
    float itemFinalPriceCounter;
    float itemFinalPriceCounterDiscount;
    float itemFinalPriceCounterTaxes;
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

    public GameObject addSingleFamilyUI;
    public GameObject addMultifamilyUI;
    public InputField roomNameText;
    public Text roomTypeText;
    public InputField roomFootageText;
    public InputField roomPlugsText;
    public InputField roomPlatesText;
    public InputField roomSwitchLightsText;

    // Single family

    public Text roomName;
    public Text roomFootage;
    public Text apartmentText;
    public Text apartmentFootageText;
    public Text apartmentFullbathsText;
    public Text apartmentHalfBathText;
    public Text numberInComplexText;
    public Text totalFootageUnit;
    public GameObject roomsInfo;
    public Transform roomsTransform;
    public GameObject apartmentsInfo;
    public Transform apartmentsTransform;
    public Dropdown roomTypeDropdown;
    public Dropdown roomMultifamilyTypeDropdown;
    public Text bedroomsTotalFootage;
    public Text halfBathTotalFootage;
    public Text fullBathTotalFootage;
    public Text kitchenTotalFootage;
    public Text livingRoomsTotalFootage;
    public Text dinningRoomsTotalFootage;
    public Text projectTotalFootage;
    public float footageBedroomsCounter;
    public float footageHalfbathCounter;
    public float footageFullbathCounter;
    public float footageKitchenCounter;
    public float footageLivingCounter;
    public float footageDinningCounter;
    public float totalFootage;

    public Text roomNameItemCost;
    public Text roomFootageItemCost;
    public Text roomTypeItemCost;
    public GameObject roomsInfoItemCost;
    public Transform roomsTransformItemCost;

    public Text multiRoomNameItemCost;
    public Text multiRoomFootageItemCost;
    public Text multiRoomTypeItemCost;

    public GameObject multiRoomInfoItemCost;
    public Transform multiRoomTransformItemCost;

    //single family room info panel 
    public Text roomTypeItemNameText;
    public Text roomTypeItemTypeText;
    public Text roomTypeItemFootageText;
    public Text roomTypeItemPaintPercentageText;
    public Text roomTypeItemPaintMaterialCostText;
    public Text roomTypeItemPaintLaborCostText;
    public Text roomTypeItemPlugsText;
    public Text roomTypeItemPlugsMaterialCostText;
    public Text roomTypeItemPlugsLaborCostText;
    public Text roomTypeItemSwitchesText;
    public Text roomTypeItemSwitchesMaterialCostText;
    public Text roomTypeItemSwitchesLaborCostText;


    public InputField roomTypeItemPaintPercentageInput;
    public InputField roomTypeItemPaintMaterialCostInput;
    public InputField roomTypeItemPaintLaborCostInput;
    public InputField roomTypeItemPlugsMaterialCostInput;
    public InputField roomTypeItemPlugsLaborCostInput;
    public InputField roomTypeItemSwitchesMaterialCostInput;
    public InputField roomTypeItemSwitchesLaborCostInput;
    public Transform SingleFamilyRoomItemsTransform;

    public Text subtotalSingleRoomText;
    public Text overheadSingleRoomText;
    public Text profitSingleRoomText;
    public Text contingencySingleRoomText;
    public Text markUpSingleRoomText;
    public Text discountSingleRoomText;
    public Text withDiscountSingleRoomText;
    public Text finalPriceSingleRoomText;

    //Multifamily

    public Text bedroomTypeText;

    public Text multiroomTypeItemNameText;
    public Text multiroomTypeItemTypeText;
    public Text multiroomTypeItemFootageText;
    public Text multiroomTypeItemPaintPercentageText;
    public Text multiroomTypeItemPaintMaterialCostText;
    public Text multiroomTypeItemPaintLaborCostText;
    public Text multiroomTypeItemPlugsText;
    public Text multiroomTypeItemPlugsMaterialCostText;
    public Text multiroomTypeItemPlugsLaborCostText;
    public Text multiroomTypeItemSwitchesText;
    public Text multiroomTypeItemSwitchesMaterialCostText;
    public Text multiroomTypeItemSwitchesLaborCostText;




    public InputField multiroomQuantityInComplexText;
    public InputField multiroomFootageText;
    public InputField multiroomPlugstext;
    public InputField multiroomSwitchLightsText;
    public InputField numberHalfBathsText;
    public InputField footageHalfBathsText;
    public InputField numberPlugsHalfBathsText;
    public InputField numberSwitchesHalfBathsText;
    public InputField numberFullbathsText;
    public InputField footageFullBathsText;
    public InputField numberPlugsFullBathsText;
    public InputField numberSwitchesFullBathsText;

    float oneBedroomApartmentsFootageCounter;
    float twoBedroomApartmentsFootageCounter;
    float threeBedroomApartmentsFootageCounter;
    float halfBathApartmentsFootagecounter;
    float fullBathApartmentsFootageCounter;
    float switchesApartmensCounter;
    float plugsApartmentsCounter;
    public Text switchesApartmentsText;
    public Text plugsApartmentsText;
    public Text halfBathFootageText;
    public Text fullBathFootageText;
    public Text totalApartmentsfootageText;

    public InputField multiroomTypeItemPaintPercentageInput;
    public InputField multiroomTypeItemPaintMaterialCostInput;
    public InputField multiroomTypeItemPaintLaborCostInput;
    public InputField multiroomTypeItemPlugsMaterialCostInput;
    public InputField multiroomTypeItemPlugsLaborCostInput;
    public InputField multiroomTypeItemSwitchesMaterialCostInput;
    public InputField multiroomTypeItemSwitchesLaborCostInput;
    

    public Text subtotalMultiRoomText;
    public Text overheadMultiRoomText;
    public Text profitMultiRoomText;
    public Text contingencyMultiRoomText;
    public Text markUpMultiRoomText;
    public Text discountMultiRoomText;
    public Text withDiscountMultiRoomText;
    public Text finalPriceMultiRoomText;


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

        //Singlefamily

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
        halfBathTotalFootage.text = footageHalfbathCounter.ToString() + " ft2";
        fullBathTotalFootage.text = footageFullbathCounter.ToString() + " ft2";
        kitchenTotalFootage.text = footageKitchenCounter.ToString() + " ft2";
        dinningRoomsTotalFootage.text = footageDinningCounter.ToString() + " ft2";
        livingRoomsTotalFootage.text = footageLivingCounter.ToString() + " ft2";
        totalFootage = footageBedroomsCounter + footageHalfbathCounter + footageFullbathCounter + footageKitchenCounter + footageDinningCounter + footageLivingCounter;
        projectTotalFootage.text = totalFootage.ToString() + " ft2";
        footageBedroomsCounter = 0;

        // Multifamily
        foreach (bedroomTypeData item in UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).bedroomsTypeList)
        {
            if (item.bedroomType == "1-Bedroom Apartments")
            {
                oneBedroomApartmentsFootageCounter = oneBedroomApartmentsFootageCounter + (item.multiroomfootage * item.multiroomQuantityInComplex);
            }
            if (item.bedroomType == "2-Bedrooms Apartments")
            {
                twoBedroomApartmentsFootageCounter = twoBedroomApartmentsFootageCounter + (item.multiroomfootage * item.multiroomQuantityInComplex);
            }
            if (item.bedroomType == "3-Bedrooms Apartments")
            {
                threeBedroomApartmentsFootageCounter = threeBedroomApartmentsFootageCounter + (item.multiroomfootage * item.multiroomQuantityInComplex);
            }
            halfBathApartmentsFootagecounter = halfBathApartmentsFootagecounter + item.footageHalfBaths;
            fullBathApartmentsFootageCounter = fullBathApartmentsFootageCounter + item.footageFullBaths;
            switchesApartmensCounter = switchesApartmensCounter + (item.multiroomSwitchLights + item.numberSwitchesFullBaths + item.numberSwitchesHalfBaths);
            plugsApartmentsCounter = plugsApartmentsCounter + (item.multiroomPlugs + item.numberPlugsFullBaths + item.numberPlugsHalfBaths);
        }
        switchesApartmentsText.text = switchesApartmensCounter.ToString();
        plugsApartmentsText.text = plugsApartmentsCounter.ToString();
        halfBathFootageText.text = halfBathApartmentsFootagecounter.ToString() + " ft2";
        fullBathFootageText.text = fullBathApartmentsFootageCounter.ToString() + " ft2";
        totalApartmentsfootageText.text = (oneBedroomApartmentsFootageCounter + twoBedroomApartmentsFootageCounter + threeBedroomApartmentsFootageCounter).ToString() + " ft2";
        oneBedroomApartmentsFootageCounter = 0;
        twoBedroomApartmentsFootageCounter = 0;
        threeBedroomApartmentsFootageCounter = 0;
        switchesApartmensCounter = 0;
        plugsApartmentsCounter = 0;
        halfBathApartmentsFootagecounter = 0;
        fullBathApartmentsFootageCounter = 0;
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
        itemEstimate.itemMaterialCost = float.Parse(itemMaterialCost.text);
        itemEstimate.itemLaborCost = float.Parse(itemLaborCost.text);
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
            UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).overhead = float.Parse(overheadInputfield.text);
            UserData.instance.SendInfo();
            overheadInputfield.text = "";
            AssingJobValues(activeJob);
        }
    }
    public void ProfitChange()
    {
        if (!string.IsNullOrEmpty(profitInputfield.text))
        {
            UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).profit = float.Parse(profitInputfield.text);
            UserData.instance.SendInfo();
            profitInputfield.text = "";
            AssingJobValues(activeJob);
        }
    }
    public void ContingencyChange()
    {
        if (!string.IsNullOrEmpty(contingencyInputfield.text))
        {
            UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).contingency = float.Parse(contingencyInputfield.text);
            UserData.instance.SendInfo();
            contingencyInputfield.text = "";
            AssingJobValues(activeJob);
        }
    }
    public void DiscountChange()
    {
        if (!string.IsNullOrEmpty(discountInputfield.text))
        {
            UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).discount = float.Parse(discountInputfield.text);
            UserData.instance.SendInfo();
            discountInputfield.text = "";
            AssingJobValues(activeJob);
        }
    }
    public void TaxesChange()
    {
        if (!string.IsNullOrEmpty(taxesInputfield.text))
        {
            UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).taxes = float.Parse(taxesInputfield.text);
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
    public void FillMultifamilyRoomType()
    {
        List<string> roomMultiFamilyType = new List<string>();
        roomMultiFamilyType.Add("1-Bedroom Apartments");
        roomMultiFamilyType.Add("2-Bedrooms Apartments");
        roomMultiFamilyType.Add("3-Bedrooms Apartments");
        roomMultifamilyTypeDropdown.AddOptions(roomMultiFamilyType);
    }
    public void sendMultifamilyRoom()
    {
        bedroomTypeData bedroomTypeToAdd = new bedroomTypeData();
        bedroomTypeToAdd.bedroomType = bedroomTypeText.text;
        bedroomTypeToAdd.multiroomQuantityInComplex = float.Parse(multiroomQuantityInComplexText.text);
        bedroomTypeToAdd.multiroomfootage = float.Parse(multiroomFootageText.text);
        bedroomTypeToAdd.multiroomPlugs = float.Parse(multiroomPlugstext.text);
        bedroomTypeToAdd.multiroomSwitchLights = float.Parse(multiroomSwitchLightsText.text);
        bedroomTypeToAdd.numberHalfBaths = float.Parse(numberHalfBathsText.text);
        bedroomTypeToAdd.footageHalfBaths = float.Parse(footageHalfBathsText.text);
        bedroomTypeToAdd.numberPlugsHalfBaths = float.Parse(numberPlugsHalfBathsText.text);
        bedroomTypeToAdd.numberSwitchesHalfBaths = float.Parse(numberSwitchesHalfBathsText.text);
        bedroomTypeToAdd.numberFullbaths = float.Parse(numberFullbathsText.text);
        bedroomTypeToAdd.footageFullBaths = float.Parse(footageFullBathsText.text);
        bedroomTypeToAdd.numberPlugsFullBaths = float.Parse(numberPlugsFullBathsText.text);
        bedroomTypeToAdd.numberSwitchesFullBaths = float.Parse(numberSwitchesFullBathsText.text);
        UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).bedroomsTypeList.Add(bedroomTypeToAdd);
        UserData.instance.SendInfo();
        AssingJobValues(activeJob);
        bedroomTypeText.text = "";
        multiroomQuantityInComplexText.text = "";
        multiroomFootageText.text = "";
        multiroomPlugstext.text = "";
        multiroomSwitchLightsText.text = "";
        numberHalfBathsText.text = "";
        footageHalfBathsText.text = "";
        numberPlugsHalfBathsText.text = "";
        numberSwitchesHalfBathsText.text = "";
        numberFullbathsText.text = "";
        footageFullBathsText.text = "";
        numberPlugsFullBathsText.text = "";
        numberSwitchesFullBathsText.text = "";
    }

    public void ShowTypeUIPanel()
    {
        if (activeJob.projectType == "Multi-family")
        {
            addMultifamilyUI.SetActive(true);
            FillMultifamilyRoomType();
            UpdateMultiFamilyRooms();
        }
        else if (activeJob.projectType == "Single-family")
        {
            addSingleFamilyUI.SetActive(true);
            UpdateRooms();
        }
    }

    public void UpdateMultiFamilyRooms()
    {
        CleanMultifamilyRoomsItems();
        AssingJobValues(activeJob);
        foreach (bedroomTypeData bedroomType in UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).bedroomsTypeList)
        {
            apartmentText.text = bedroomType.bedroomType;
            apartmentFootageText.text = (bedroomType.multiroomfootage).ToString() + " ft2";
            //apartmentFullbathsText.text = bedroomType.numberFullbaths.ToString();
            //apartmentHalfBathText.text = bedroomType.numberHalfBaths.ToString();
            numberInComplexText.text = bedroomType.multiroomQuantityInComplex.ToString();
            totalFootageUnit.text = (bedroomType.multiroomfootage * bedroomType.multiroomQuantityInComplex).ToString() + " ft2";
            GameObject _tempGo = Instantiate(apartmentsInfo, apartmentsTransform);
        }
    }

    public void CleanMultifamilyRoomsItems()
    {
        foreach (Transform child in apartmentsTransform.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

    }

    public void UpdateRoomJobs()
    {
        CleanRoomsItems();
        foreach (RoomData rooms in UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).roomsList)
        {
            roomNameItemCost.text = rooms.roomName;
            roomFootageItemCost.text = rooms.roomFootage.ToString() + " ft2";
            roomTypeItemCost.text = rooms.roomType;
            GameObject _tempGo = Instantiate(roomsInfoItemCost, roomsTransformItemCost);
            _tempGo.GetComponentInChildren<RoomSingleLoader>().thisRoom = rooms;
        }
    }

    public void CleanRoomsItems()
    {
        foreach (Transform child in SingleFamilyRoomItemsTransform.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

    }

    public void CleanMultiRoomsItems()
    {
        foreach (Transform child in multiRoomTransformItemCost.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

    }

    public void AssignRoomValues(RoomData roomToValue)
    {
        activeRoom = roomToValue;
        roomTypeItemNameText.text = roomToValue.roomName;
        roomTypeItemTypeText.text = roomToValue.roomType;
        roomTypeItemFootageText.text = roomToValue.roomFootage.ToString();
        roomTypeItemPaintPercentageText.text = roomToValue.roomFootagePercentagePaint.ToString();
        roomTypeItemPaintMaterialCostText.text = roomToValue.materialRoomFootagePaint.ToString();
        roomTypeItemPaintLaborCostText.text = roomToValue.laborRoomFootagePaint.ToString();
        roomTypeItemPlugsText.text = roomToValue.roomPlugs.ToString();
        roomTypeItemPlugsMaterialCostText.text = roomToValue.materialCostRoomPlugs.ToString();
        roomTypeItemPlugsLaborCostText.text = roomToValue.laborCostRoomPlugs.ToString();
        roomTypeItemSwitchesText.text = roomToValue.roomSwitchLights.ToString();
        roomTypeItemSwitchesMaterialCostText.text = roomToValue.materialCostRoomSwitchLights.ToString();
        roomTypeItemSwitchesLaborCostText.text = roomToValue.laborCostroomSwitchLights.ToString();
    }

    public void     AssingBedroomValues(bedroomTypeData multiroomToValue)
    {
        activeMultiroom = multiroomToValue;
        print("Este es el multirroom" + activeMultiroom.bedroomType);
        multiroomTypeItemNameText.text = multiroomToValue.bedroomType;
        multiroomTypeItemTypeText.text = multiroomToValue.bedroomType;
        multiroomTypeItemFootageText.text = multiroomToValue.multiroomfootage.ToString();
        multiroomTypeItemPaintPercentageText.text = multiroomToValue.multiRoomFootagePercentagePaint.ToString();
        multiroomTypeItemPaintMaterialCostText.text = multiroomToValue.materialMultiRoomFootagePaint.ToString();
        multiroomTypeItemPaintLaborCostText.text = multiroomToValue.laborMultiRoomFootagePaint.ToString();
        multiroomTypeItemPlugsText.text = multiroomToValue.multiroomPlugs.ToString();
        multiroomTypeItemPlugsMaterialCostText.text = multiroomToValue.materialCostMultiRoomPlugs.ToString();
        multiroomTypeItemPlugsLaborCostText.text = multiroomToValue.laborCostMultiRoomPlugs.ToString();
        multiroomTypeItemSwitchesText.text = multiroomToValue.multiroomSwitchLights.ToString();
        multiroomTypeItemSwitchesMaterialCostText.text = multiroomToValue.materialCostMultiRoomSwitchLights.ToString();
        roomTypeItemSwitchesLaborCostText.text = multiroomToValue.laborCostMultiroomSwitchLights.ToString();

    }

    public void sendRoomItem()
    {
        UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).roomsList.Find(RoomData => RoomData == activeRoom).roomFootagePercentagePaint = float.Parse(roomTypeItemPaintPercentageInput.text);
        UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).roomsList.Find(RoomData => RoomData == activeRoom).materialRoomFootagePaint = float.Parse(roomTypeItemPaintMaterialCostInput.text);
        UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).roomsList.Find(RoomData => RoomData == activeRoom).laborRoomFootagePaint = float.Parse(roomTypeItemPaintLaborCostInput.text);
        UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).roomsList.Find(RoomData => RoomData == activeRoom).materialCostRoomPlugs = float.Parse(roomTypeItemPaintMaterialCostInput.text);
        UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).roomsList.Find(RoomData => RoomData == activeRoom).laborCostRoomPlugs = float.Parse(roomTypeItemPlugsLaborCostInput.text);
        UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).roomsList.Find(RoomData => RoomData == activeRoom).materialCostRoomSwitchLights = float.Parse(roomTypeItemSwitchesMaterialCostInput.text);
        UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).roomsList.Find(RoomData => RoomData == activeRoom).laborCostroomSwitchLights = float.Parse(roomTypeItemSwitchesLaborCostInput.text);
        UserData.instance.SendInfo();
        AssingJobValues(activeJob);
        UpdateRoomJobs();
        UpdateSingleRoomsCosts();
        roomTypeItemPaintPercentageInput.text = "";
        roomTypeItemPaintMaterialCostInput.text = "";
        roomTypeItemPaintLaborCostInput.text = "";
        roomTypeItemPaintMaterialCostInput.text = "";
        roomTypeItemPlugsLaborCostInput.text = "";
        roomTypeItemSwitchesMaterialCostInput.text = "";
        roomTypeItemSwitchesLaborCostInput.text = "";
    }


    public void sendMultiRoomItem()
    {
        UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).bedroomsTypeList.Find(bedroomTypeData=> bedroomTypeData == activeMultiroom).multiRoomFootagePercentagePaint= float.Parse(multiroomTypeItemPaintPercentageInput.text);
        UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).bedroomsTypeList.Find(bedroomTypeData=> bedroomTypeData == activeMultiroom).materialMultiRoomFootagePaint = float.Parse(multiroomTypeItemPaintMaterialCostInput.text);
        UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).bedroomsTypeList.Find(bedroomTypeData=> bedroomTypeData == activeMultiroom).laborMultiRoomFootagePaint = float.Parse(multiroomTypeItemPaintLaborCostInput.text);
        UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).bedroomsTypeList.Find(bedroomTypeData=> bedroomTypeData == activeMultiroom).materialCostMultiRoomPlugs = float.Parse(multiroomTypeItemPaintMaterialCostInput.text);
        UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).bedroomsTypeList.Find(bedroomTypeData=> bedroomTypeData == activeMultiroom).laborCostMultiRoomPlugs = float.Parse(multiroomTypeItemPlugsLaborCostInput.text);
        UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).bedroomsTypeList.Find(bedroomTypeData=> bedroomTypeData == activeMultiroom).materialCostMultiRoomSwitchLights = float.Parse(multiroomTypeItemSwitchesMaterialCostInput.text);
        UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).bedroomsTypeList.Find(bedroomTypeData=> bedroomTypeData == activeMultiroom).laborCostMultiroomSwitchLights = float.Parse(multiroomTypeItemSwitchesLaborCostInput.text);
        UserData.instance.SendInfo();
        AssingJobValues(activeJob);
        UpdateMultiFamilyRooms();
        UpdateMultiRoomsCosts();
        multiroomTypeItemPaintPercentageInput.text = "";
        multiroomTypeItemPaintMaterialCostInput.text = "";
        multiroomTypeItemPaintLaborCostInput.text = "";
        multiroomTypeItemPlugsMaterialCostInput.text = "";
        multiroomTypeItemPlugsLaborCostInput.text = "";
        multiroomTypeItemSwitchesMaterialCostInput.text = "";
        multiroomTypeItemSwitchesLaborCostInput.text = "";
    }

    public void UpdateSingleRoomsCosts()
    {
        float subtotalCounter = 0;
        foreach (RoomData room in UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).roomsList)
        {
            float paintCost;
            float plugsCost;
            float switchCost;
            paintCost = ((room.roomFootage * (room.materialRoomFootagePaint + room.laborRoomFootagePaint)) * (room.roomFootagePercentagePaint / 100));
            plugsCost = (room.laborCostRoomPlugs + room.materialCostRoomPlugs) * room.roomPlugs;
            switchCost = (room.laborCostroomSwitchLights + room.materialCostRoomSwitchLights) * room.roomSwitchLights;
            subtotalCounter = subtotalCounter + (paintCost + plugsCost + switchCost);
        }
        subtotalSingleRoomText.text = "$" + subtotalCounter.ToString();
        overheadSingleRoomText.text = "$" + (subtotalCounter * (UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).overhead / 100)).ToString();
        profitSingleRoomText.text = "$" + (subtotalCounter * (UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).profit / 100)).ToString();
        contingencySingleRoomText.text = "$" + (subtotalCounter * (UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).contingency / 100)).ToString();
        markUpSingleRoomText.text = "$" + (subtotalCounter + (subtotalCounter * ((UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).contingency / 100) + (UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).profit / 100) + (UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).overhead / 100)))).ToString();
        float markuptotal = subtotalCounter + (subtotalCounter * ((UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).contingency / 100) + (UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).profit / 100) + (UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).overhead / 100)));
        discountSingleRoomText.text = "$" + (subtotalCounter * (UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).discount / 100)).ToString();
        float withDiscountTotal = markuptotal - (subtotalCounter * (UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).discount / 100));
        withDiscountSingleRoomText.text = "$" + withDiscountTotal.ToString();
        finalPriceSingleRoomText.text = "$" + withDiscountTotal.ToString();
    }

    public void UpdateMultiRoomsCosts()
    {
        float subtotalCounter = 0;
        foreach (bedroomTypeData room in UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).bedroomsTypeList)
        {
            float paintCost;
            float plugsCost;
            float switchCost;
            paintCost = ((room.multiroomfootage * (room.materialMultiRoomFootagePaint + room.laborMultiRoomFootagePaint)) * (room.multiRoomFootagePercentagePaint / 100));
            plugsCost = (room.laborCostMultiRoomPlugs + room.materialCostMultiRoomPlugs) * room.multiroomPlugs;
            switchCost = (room.laborCostMultiroomSwitchLights + room.materialCostMultiRoomSwitchLights) * room.multiroomSwitchLights;
            subtotalCounter = subtotalCounter + (paintCost + plugsCost + switchCost);
        }
        subtotalMultiRoomText.text = "$" + subtotalCounter.ToString();
        overheadMultiRoomText.text = "$" + (subtotalCounter * (UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).overhead / 100)).ToString();
        profitMultiRoomText.text = "$" + (subtotalCounter * (UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).profit / 100)).ToString();
        contingencyMultiRoomText.text = "$" + (subtotalCounter * (UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).contingency / 100)).ToString();
        markUpMultiRoomText.text = "$" + (subtotalCounter + (subtotalCounter * ((UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).contingency / 100) + (UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).profit / 100) + (UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).overhead / 100)))).ToString();
        float markuptotal = subtotalCounter + (subtotalCounter * ((UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).contingency / 100) + (UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).profit / 100) + (UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).overhead / 100)));
        discountMultiRoomText.text = "$" + (subtotalCounter * (UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).discount / 100)).ToString();
        float withDiscountTotal = markuptotal - (subtotalCounter * (UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).discount / 100));
        withDiscountMultiRoomText.text = "$" + withDiscountTotal.ToString();
        finalPriceMultiRoomText.text = "$" + withDiscountTotal.ToString();
    }


    public void OnRoomJobsButton()
    {
        if (activeJob.projectType == "Multi-family")
        {
            UpdateMultifamilyRoomJobs();


        }
        else if (activeJob.projectType == "Single-family")
        {
            UpdateRoomJobs();
            UpdateSingleRoomsCosts();
        }
    }

    public void UpdateMultifamilyRoomJobs()
    {
        CleanMultifamilyRoomsItems();
        foreach (bedroomTypeData bedroomsApartment in UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).bedroomsTypeList)
        {
            multiRoomNameItemCost.text = bedroomsApartment.bedroomType;
            multiRoomFootageItemCost.text = bedroomsApartment.multiroomfootage.ToString() + " ft2";
            multiRoomTypeItemCost.text = bedroomsApartment.multiroomQuantityInComplex.ToString();
            GameObject _tempGo = Instantiate(multiRoomInfoItemCost, multiRoomTransformItemCost);
            _tempGo.GetComponentInChildren<MultiRoomLoader>().thisRoom = bedroomsApartment;
        }
    }
}


