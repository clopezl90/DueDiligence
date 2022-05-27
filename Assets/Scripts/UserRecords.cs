using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[Serializable]
public class UserRecords
{
    public bool tutorial;
    public bool appPurchased;
    public string companyName = "";
    public string companySite = "";
    public string companyEmail = "";
    public string companyphone = "";
    public string companyWebsite = "";
    public string measurementUnitInUse = "";
    public string [] measurementUnits;
    public string currencyInUse;
    public string [] currency;
    public string taxGroupInUse;
    public string [] taxGroups;
    public List <string> jobTags = new List<string>();
    public List <string> customerTags = new List<string>();
    
    public UserRecords ()
    {
        jobTags = new List<string>();
        jobTags.Add("Commercial");
        jobTags.Add("New Construction");
        jobTags.Add("Renovation");
        jobTags.Add("Residential");
        jobTags.Add("Service");

        customerTags = new List<string>();
        customerTags.Add("High Value");
        customerTags.Add("Property value");
    }
    
}
