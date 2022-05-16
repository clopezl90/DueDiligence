using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuHandler : MonoBehaviour
{
    [SerializeField] Text companyName;
    [SerializeField] Text companySite;
    [SerializeField] Text companyPhone;
    [SerializeField] Text companyEmail;
    [SerializeField] Text tagText;
    public GameObject tagContainer;
    public Transform tagTramsform;
    [SerializeField] Text customerTagText;
    public GameObject customerTagContainer;
    public Transform CustomerTagTramsform; 
    void Start()
    {
        AssingSettingValues();
               
    }

    void Update()
    {
        
    }
    public void AssingSettingValues()
    {
        companyName.text = UserData.userRecords.companyName;
        companySite.text = UserData.userRecords.companySite;
        companyPhone.text = UserData.userRecords.companyphone;
        companyEmail.text = UserData.userRecords.companyEmail; 
        UpdateTags();

    }
    public void UpdateTags()
    {
        CleanTags();
        foreach (string tag in UserData.userRecords.jobTags)
        {
            tagText.text = tag;            
            GameObject _tempGo = Instantiate(tagContainer, tagTramsform);
        }
        foreach (string tag in UserData.userRecords.customerTags)
        {
            customerTagText.text = tag;            
            GameObject _tempGo = Instantiate(customerTagContainer, CustomerTagTramsform);
        }
    }
    public void CleanTags()
    {
        foreach (Transform child in tagTramsform.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        foreach (Transform child in CustomerTagTramsform.transform)
        {
            GameObject.Destroy(child.gameObject);
        }        
    }

}
