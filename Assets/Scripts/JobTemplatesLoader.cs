using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JobTemplatesLoader : MonoBehaviour
{
    public Text jobTemplateDescriptionDashboard;
    public Text jobTemplateDescriptionClient;

    public Jobs thisJobTemplate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SendJobTemplateValues()
    {
        JobTemplateInfo.instance.AssingJobTemplateValues(thisJobTemplate);
        //JobInfo.instance.AssingJobValues(thisJob);        
        //JobTitleHeader.text = thisJob.jobDescription;
        /* JobTitleHeader.text = thisJob.jobDescription;
        jobDescriptionDashboard.text = thisJob.jobDescription; */


    }
}
