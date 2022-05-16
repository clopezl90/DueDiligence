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
    public string companyName = "EasyTest";
    public string companySite = "New York";
    public string companyEmail = "easy@easy.co";
    public string companyphone = "321654987";
    public string companyWebsite = "www.easycoding.co";
    public string measurementUnitInUse = "meters";
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
