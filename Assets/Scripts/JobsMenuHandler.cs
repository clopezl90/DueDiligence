using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;


public class JobsMenuHandler : MonoBehaviour
{

    [SerializeField] InputField jobdText;
    [SerializeField] Text jobClientText;
    [SerializeField] InputField jobRewardText;

    [SerializeField] Text description;
    [SerializeField] Text client;
    [SerializeField] Text amount;

    public Clients selectedClient;
    

    public GameObject jobsInfo;
    public Transform jobsTransform;
    public GameObject noJobsText;
    public Dropdown clientsDropDown;
    public Toggle leadStatus;
    
    
    

    
    
    void Start()
    {
        if (UserData.jobsArray.jobsList.Count > 0)
        {
            UpdateJobs();
        }
        else
        {
            noJobsText.SetActive(true);
        }

        FillDropdownList();
    }
    private void OnEnable() {
        
    }

    void Update()
    {

    }
    public void SendJobs()
    {
        int intJobReward = int.Parse(jobRewardText.text.ToString());
        foreach (Clients client in UserData.clientsArray.clientsList)
        {
            if (client.clientName == jobClientText.text)
            {
                selectedClient = client;
            }
            
        }            
        Jobs newJob = new Jobs(jobdText.text, intJobReward, "Lead");
        newJob.jobCientObject = selectedClient;
        UserData.jobsArray.jobsList.Add(newJob);    
        selectedClient = new Clients("","","","");      
        foreach (Clients client in UserData.clientsArray.clientsList)
        {
            print (jobClientText.text + client.clientName);
            if (jobClientText.text == client.clientName)
            {
                UserData.jobsArray.jobsList[0].jobCientObject = client;                
            }           
        }
        UpdateJobs();       
        noJobsText.SetActive(false);
        UserData.instance.SendInfo();        
        jobdText.text = "";
        jobClientText.text = "";
        jobRewardText.text = "";
        
    }

    public void UpdateJobs()
    {
        CleanJobs();
        foreach (Jobs p in UserData.jobsArray.jobsList)
        {
            description.text = p.jobDescription;
            if (p.jobCientObject.clientName != null)
            {
                client.text = p.jobCientObject.clientName;
            }
            else
            {
                client.text = "No client";
            }
            amount.text = "$" + p.jobReward;
            GameObject _tempgo2 = Instantiate(jobsInfo, jobsTransform);
            _tempgo2.GetComponentInChildren<JobsLoader>().thisJob = p;
        }
    }
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void CleanJobs()
    {
        foreach (Transform child in jobsTransform.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
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
