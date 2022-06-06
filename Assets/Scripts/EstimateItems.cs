using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]

public class EstimateItems 
{
    public string itemName;
    public string itemDescription;
    public int itemQuantity;
    // costs
    public float itemMaterialCost;
    public float itemLaborCost;
    public float itemEquipmentCost;
    public float itemOtherCost;
    public float itemSubcontractCost;
    public float itemSubtotal;
    public float itemFinalPrice;
    public float itemOverhead;
    public float itemProfit;
    public float itemContingency;
    public float itemDiscount;
    public float itemTaxes;
    
    public EstimateItems (string _itemName)
    {
        itemName = _itemName;
    }
    
}
