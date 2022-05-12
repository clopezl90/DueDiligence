using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class JobTemplateInfo : MonoBehaviour
{
    public static JobTemplateInfo instance;    
    public Text mainTitleJobTemplate;
    public Text templatePanelsTitle;
    public Jobs activeTemplateJob;

    [Header("Job info")]
    public Text thisJobTitle;

    public Text thisJobOverhead;

    public Text thisJobProfit;

    public Text thisJobContingency;
    public Text thisJobDiscount;    
    public Toggle[] tagToggles;
    public InputField jobTitleText;
    //public Text jobTitletext;
    public Dropdown clientsDropDownCustomer;
    public Text jobCustomerText;
    public string noneText = "";
    public Dropdown clientsDropDown;
    public Dropdown jobTemplatesDropdown;
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

    
    // Start is called before the first frame update
    public void Awake()
    {
        instance = this;
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AssingJobTemplateValues(Jobs jobTemplateToValue)
    {
        activeTemplateJob = jobTemplateToValue;
        mainTitleJobTemplate.text = jobTemplateToValue.jobDescription;
        templatePanelsTitle.text = jobTemplateToValue.jobDescription;        
        thisJobTitle.text = jobTemplateToValue.jobDescription;
        thisJobOverhead.text = jobTemplateToValue.overhead.ToString();
        thisJobProfit.text = jobTemplateToValue.profit.ToString();
        thisJobContingency.text = jobTemplateToValue.contingency.ToString();
        thisJobDiscount.text = jobTemplateToValue.discount.ToString();  
        //Estimate
        thisJobIssueDate.text = jobTemplateToValue.jobEstimateObject.issueDate;
        thisJobExpiration.text = jobTemplateToValue.jobEstimateObject.expirationPeriod.ToString() + " days";
        thisJobEstimateExpiration.text = jobTemplateToValue.jobEstimateObject.description;
        if (jobTemplateToValue.jobEstimateObject.estimateList.Count != 0)
        {
            foreach (EstimateItems item in UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeTemplateJob).jobEstimateObject.estimateList)
            {
                itemscounter++;
                item.itemOverhead = item.itemSubtotal * (UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeTemplateJob).overhead / 100);
                item.itemProfit = item.itemSubtotal * (UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeTemplateJob).profit / 100);
                item.itemContingency = item.itemSubtotal * (UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeTemplateJob).contingency / 100);
                item.itemDiscount = item.itemSubtotal * (UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeTemplateJob).discount / 100);
                item.itemTaxes = item.itemSubtotal * (UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeTemplateJob).taxes / 100);
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
        UserData.jobTemplatesArray.jobTemplatesList.Find(Jobs => Jobs == activeTemplateJob).jobGlobalAmount = itemFinalPriceCounter;
        itemscounter = 0;
        subtotalCounter = 0;
        overheadCouter = 0;
        profitCounter = 0;
        contingencyCounter = 0;        
    }

    public void OnBackButton()
    {
        AssingJobTemplateValues(activeTemplateJob);
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
        foreach (EstimateItems item in UserData.jobTemplatesArray.jobTemplatesList.Find(Jobs => Jobs == activeTemplateJob).jobEstimateObject.estimateList)
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
    
    public void ToogleChangedTag()
    {
        foreach (Toggle toggle in tagToggles)
        {
            if (toggle.isOn)
            {
                UserData.jobTemplatesArray.jobTemplatesList.Find(Jobs => Jobs == activeTemplateJob).jobTag = toggle.name;
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
            UserData.jobTemplatesArray.jobTemplatesList.Find(Jobs => Jobs == activeTemplateJob).jobDescription = jobTitleText.text;
            //thisJobDescription.text = jobTitleText.text;
            AssingJobTemplateValues(activeTemplateJob);
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
        if (jobCustomerText.text != UserData.jobTemplatesArray.jobTemplatesList.Find(Jobs => Jobs == activeTemplateJob).jobCientObject.clientName || jobCustomerText.text != "")
        {
            foreach (Clients client in UserData.clientsArray.clientsList)
            {
                print(jobCustomerText + client.clientName);
                if (jobCustomerText.text == client.clientName)
                {
                    UserData.jobTemplatesArray.jobTemplatesList.Find(Jobs => Jobs == activeTemplateJob).jobCientObject = client;
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
        /* itemEstimate.itemOverhead = itemEstimate.itemSubtotal * 0.1;
        itemEstimate.itemProfit = itemEstimate.itemSubtotal * 0.1;
        itemEstimate.itemContingency = itemEstimate.itemSubtotal * 0.15;
        itemEstimate.itemFinalPrice = itemEstimate.itemOverhead + itemEstimate.itemContingency + itemEstimate.itemContingency; */
        //UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).jobGlobalAmount = UserData.jobsArray.jobsList.Find(Jobs => Jobs == activeJob).jobGlobalAmount + itemEstimate.itemFinalPrice;
        UserData.jobTemplatesArray.jobTemplatesList.Find(Jobs => Jobs == activeTemplateJob).jobEstimateObject.estimateList.Add(itemEstimate);
        UserData.instance.SendInfo();
        AssingJobTemplateValues(activeTemplateJob);
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
            UserData.jobTemplatesArray.jobTemplatesList.Find(Jobs => Jobs == activeTemplateJob).overhead = double.Parse(overheadInputfield.text);
            UserData.instance.SendInfo();
            overheadInputfield.text = "";
            AssingJobTemplateValues(activeTemplateJob);
        }
    }
    public void ProfitChange()
    {
        if (!string.IsNullOrEmpty(profitInputfield.text))
        {
            UserData.jobTemplatesArray.jobTemplatesList.Find(Jobs => Jobs == activeTemplateJob).profit = double.Parse(profitInputfield.text);
            UserData.instance.SendInfo();
            profitInputfield.text = "";
            AssingJobTemplateValues(activeTemplateJob);
        }
    }
    public void ContingencyChange()
    {
        if (!string.IsNullOrEmpty(contingencyInputfield.text))
        {
            UserData.jobTemplatesArray.jobTemplatesList.Find(Jobs => Jobs == activeTemplateJob).contingency = double.Parse(contingencyInputfield.text);
            UserData.instance.SendInfo();
            contingencyInputfield.text = "";
            AssingJobTemplateValues(activeTemplateJob);
        }
    }
    public void DiscountChange()
    {
        if (!string.IsNullOrEmpty(discountInputfield.text))
        {
            UserData.jobTemplatesArray.jobTemplatesList.Find(Jobs => Jobs == activeTemplateJob).discount = double.Parse(discountInputfield.text);
            UserData.instance.SendInfo();
            discountInputfield.text = "";
            AssingJobTemplateValues(activeTemplateJob);
        }
    }
    public void TaxesChange()
    {
        if (!string.IsNullOrEmpty(taxesInputfield.text))
        {
            UserData.jobTemplatesArray.jobTemplatesList.Find(Jobs => Jobs == activeTemplateJob).taxes = double.Parse(taxesInputfield.text);
            UserData.instance.SendInfo();
            taxesInputfield.text = "";
            AssingJobTemplateValues(activeTemplateJob);
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
}
