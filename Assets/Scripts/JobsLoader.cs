using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JobsLoader : MonoBehaviour
{
    public Text jobDescriptionDashboard;
    public Text jobDescriptionClient;

    public Jobs thisJob;

    // Start is called before the first frame update
    private void Awake()
    {

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SendJobValues()
    {
        JobInfo.instance.AssingJobValues(thisJob);
        print(thisJob.jobDescription);
        //JobTitleHeader.text = thisJob.jobDescription;
        /* JobTitleHeader.text = thisJob.jobDescription;
        jobDescriptionDashboard.text = thisJob.jobDescription; */


    }
}
