using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OverviewMenuHandler : MonoBehaviour
{
    public string jobStatus;
    public Text leadJobs;
    public Text leadJObsGlobalAmount;
    public Text contractSignedJobs;
    public Text contractSignedGlobalAmount;
    public Text workStartedJobs;
    public Text workStartedGlobalAmount;
    public Text workCompletedJobs;
    public Text workCompletedGlobalAmount;
    public Text workClosedJobs;
    public Text workClosedGlobalAmount;

    void Start()
    {
        GetJobsInfo();
    }

    void Update()
    {

    }
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }


    public void GetJobsInfo()
    {
        int leadCounter = 0;
        double leadAmountCounter = 0;
        int contracSignedCounter = 0;
        double contractsSignedAmountCounter = 0;
        int workStartedCounter = 0;
        double workStartedAmountCounter = 0;
        int workCompletedCounter = 0;
        double workCompletedAmountCounter = 0;
        int workClosedCounter = 0;
        double workClosedAmountCounter = 0;
        foreach (Jobs job in UserData.jobsArray.jobsList)
        {
            jobStatus = job.jobStatus;
            switch (jobStatus)
            {
                case "Lead":
                    leadCounter++;
                    leadAmountCounter = leadAmountCounter + job.jobGlobalAmount;
                    break;
                case "Contract signed":
                    contracSignedCounter++;
                    contractsSignedAmountCounter = contractsSignedAmountCounter + job.jobGlobalAmount;
                    break;
                case "Work started":
                    workStartedCounter++;
                    workStartedAmountCounter = workStartedAmountCounter + job.jobGlobalAmount;
                    break;
                case "Work completed":
                    workCompletedCounter++;
                    workCompletedAmountCounter = workCompletedAmountCounter + job.jobGlobalAmount;
                    break;
                case "Closed":
                    workClosedCounter++;
                    workClosedAmountCounter = workClosedAmountCounter + job.jobGlobalAmount;
                    break;
                default:
                    break;
            }
        }
        /* print("los lead son " + leadCounter + "y suman " + leadAmountCounter);
        print("los contract son " + contracSignedCounter + "y suman " + contractsSignedAmountCounter);
        print("los work started son " + workStartedCounter + "y suman " + workStartedAmountCounter);
        print("los work comple son " + workCompletedCounter + "y suman " + workCompletedAmountCounter);
        print("los closed son " + workClosedCounter + "y suman " + workClosedAmountCounter); */
        leadJobs.text = leadCounter.ToString();
        leadJObsGlobalAmount.text = "$" + leadAmountCounter.ToString();
        contractSignedJobs.text = contracSignedCounter.ToString();
        contractSignedGlobalAmount.text = "$" + contractsSignedAmountCounter.ToString();
        workStartedJobs.text = workStartedCounter.ToString();
        workStartedGlobalAmount.text = "$" + workStartedAmountCounter.ToString();
        workCompletedJobs.text = workCompletedCounter.ToString();
        workCompletedGlobalAmount.text = "$" + workCompletedAmountCounter.ToString();
        workClosedJobs.text = workClosedCounter.ToString();
        workClosedGlobalAmount.text = "$" + workClosedAmountCounter.ToString();
    }
}
