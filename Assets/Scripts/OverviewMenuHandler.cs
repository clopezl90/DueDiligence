using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OverviewMenuHandler : MonoBehaviour
{
    int activeJobs;
    int finishedJobs;
    int totalRewardsActive = 0;
    public string jobStatus;

    [SerializeField] Text activeJobsQty;
    [SerializeField] Text activeJobsAmount;
    void Start()
    {
        GetInformation();
        GetJobsInfo();
    }

    void Update()
    {

    }
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    void GetInformation()
    {
        activeJobs = UserData.jobsArray.jobsList.Count;
        foreach (Jobs b in UserData.jobsArray.jobsList)
        {
            if (b.jobStatus == "Active")
            {
                totalRewardsActive += b.jobReward;
            }
        }
        activeJobsQty.text = activeJobs.ToString();
        activeJobsAmount.text = "$ " + totalRewardsActive.ToString();
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
                    leadAmountCounter = leadAmountCounter + job.jobEstimateObject.estimateSubtotal;
                    break;
                case "Contract signed":
                    contracSignedCounter++;
                    contractsSignedAmountCounter = contractsSignedAmountCounter + job.jobEstimateObject.estimateSubtotal;
                    break;
                case "Work started":
                    workStartedCounter++;
                    workStartedAmountCounter = workStartedAmountCounter + job.jobEstimateObject.estimateSubtotal;
                    break;
                case "Work completed":
                    workCompletedCounter++;
                    workCompletedAmountCounter = workCompletedAmountCounter + job.jobEstimateObject.estimateSubtotal;
                    break;
                case "Closed":
                    workClosedCounter++;
                    workClosedAmountCounter = workClosedAmountCounter + job.jobEstimateObject.estimateSubtotal;
                    break;
                default:
                    break;
            }
        }

        print("los lead son " + leadCounter + "y suman " + leadAmountCounter);
        print("los contract son " + contracSignedCounter + "y suman " + contractsSignedAmountCounter);
        print("los work started son " + workStartedCounter + "y suman " + workStartedAmountCounter);
        print("los work comple son " + workCompletedCounter + "y suman " + workCompletedAmountCounter);
        print("los closed son " + workClosedCounter + "y suman " + workClosedAmountCounter);

    }
}
