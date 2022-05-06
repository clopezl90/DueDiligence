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
    public double itemMaterialCost;
    public double itemLaborCost;
    public double itemEquipmentCost;
    public double itemOtherCost;
    public double itemSubcontractCost;
    public double itemSubtotal;
    public double itemFinalPrice;
    public double itemOverhead;
    public double itemProfit;
    public double itemContingency;
    
    public EstimateItems (string _itemName)
    {
        itemName = _itemName;
    }
    
}
