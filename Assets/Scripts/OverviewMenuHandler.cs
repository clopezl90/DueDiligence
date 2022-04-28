using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OverviewMenuHandler : MonoBehaviour
{

    int activeJobs;
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
        print("hay " + activeJobs + "trabajos activos");
    }

    
}
