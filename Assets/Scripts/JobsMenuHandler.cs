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
    [SerializeField] Text jobTemplateText;
    [SerializeField] Text projectTypeText;
    [SerializeField] InputField jobSite;

    [SerializeField] Text description;
    [SerializeField] Text client;
    [SerializeField] Text site;

    public Clients selectedClient;
    public Jobs selectedTemplateJob;
    public GameObject jobsInfo;
    public Transform jobsTransform;
    public GameObject noJobsText;
    public Dropdown complexTypeDropDown;
    public Dropdown clientsDropDown;
    public Dropdown jobTemplatesDropdown;
    public string noneText = "None";
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
        FillTemplatesDropdownList();
    }
    private void OnEnable()
    {

    }
    void Update()
    {

    }
    public void SendJobs()
    {
        string stgJobSite = jobSite.text;
        foreach (Clients client in UserData.clientsArray.clientsList)
        {
            if (client.clientName == jobClientText.text)
            {
                selectedClient = client;
            }

        }
        Jobs newJob = new Jobs(jobdText.text, stgJobSite, "Lead");
        newJob.jobCientObject = selectedClient;
        newJob.projectType = projectTypeText.text;
        UserData.jobsArray.jobsList.Add(newJob);
        selectedClient = new Clients("", "", "", "");
        foreach (Clients client in UserData.clientsArray.clientsList)
        {
            print(jobClientText.text + client.clientName);
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
        jobSite.text = "";
        /* if (JobInfo.instance.templatetoAdd)
        {
            foreach (Jobs job in UserData.jobTemplatesArray.jobTemplatesList)
            {
                if (job.jobDescription == jobTemplateText.text)
                {
                    selectedTemplateJob = job;
                }

            }
            UserData.jobsArray.jobsList.Add(selectedTemplateJob);
            jobTemplateText.text = "";

        }
        else if (JobInfo.instance.jobToAddInfo)
        {
            string stgJobSite = jobSite.text;
            foreach (Clients client in UserData.clientsArray.clientsList)
            {
                if (client.clientName == jobClientText.text)
                {
                    selectedClient = client;
                }

            }
            Jobs newJob = new Jobs(jobdText.text, stgJobSite, "Lead");
            newJob.jobCientObject = selectedClient;
            newJob.projectType = projectTypeText.text;
            UserData.jobsArray.jobsList.Add(newJob);
            selectedClient = new Clients("", "", "", "");
            foreach (Clients client in UserData.clientsArray.clientsList)
            {
                print(jobClientText.text + client.clientName);
                if (jobClientText.text == client.clientName)
                {
                    UserData.jobsArray.jobsList[0].jobCientObject = client;
                }
            }
        }
        UpdateJobs();
        noJobsText.SetActive(false);
        UserData.instance.SendInfo();
        jobdText.text = "";
        jobClientText.text = "";
        jobSite.text = ""; */

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
            site.text = p.jobSite;
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

        List<string> complexType = new List<string>();

        complexType.Add("Single-family");
        complexType.Add("Multi-family");

        complexTypeDropDown.AddOptions(complexType);
    }
    public void FillTemplatesDropdownList()
    {
        jobTemplatesDropdown.ClearOptions();
        List<string> templates = new List<string>();
        templates.Add(noneText);
        foreach (Jobs c in UserData.jobTemplatesArray.jobTemplatesList)
        {
            templates.Add(c.jobDescription);
        }
        jobTemplatesDropdown.AddOptions(templates);
    }

    
}


