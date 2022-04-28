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
    [SerializeField] Text activeJobsQty;
    [SerializeField] Text activeJobsAmount;
    void Start()
    {
        GetInformation();
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
}
