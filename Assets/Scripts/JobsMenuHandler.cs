using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JobsMenuHandler : MonoBehaviour
{

    [SerializeField] InputField jobDescriptionText;
    [SerializeField] InputField jobClientText;
    [SerializeField] InputField jobRewardText;

    [SerializeField] Text Description;
    [SerializeField] Text Client;
    [SerializeField] Text Amount;

    public GameObject jobsInfo;
    public Transform jobsTransform;
    public GameObject noJobsText;


    // Start is called before the first frame update

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
        

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SendJobs()
    {
        Jobs vagina = new Jobs(jobDescriptionText.text, jobClientText.text, jobRewardText.text, "Active");
        UserData.jobsArray.jobsList.Add(vagina);
        UpdateJobs();
        noJobsText.SetActive(false);
        UserData.instance.SendInfo();
    }

    public void UpdateJobs()
    {
        foreach (Jobs p in UserData.jobsArray.jobsList)
        {
            Description.text = p.jobDescription;
            Client.text = p.jobClient;
            Amount.text = "$" + p.jobReward;
        }
        GameObject _tempgo2 = Instantiate(jobsInfo, jobsTransform);  
        

        
    }
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
