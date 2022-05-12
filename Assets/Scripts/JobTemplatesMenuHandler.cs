using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JobTemplatesMenuHandler : MonoBehaviour
{

    [SerializeField] Text templateDescription;
    [SerializeField] Text templateCost;

    public GameObject jobTemplateInfo;
    public Transform jobTempleteTransform;
    // Start is called before the first frame update
    void Start()
    {
        UpdateJobs();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddJobTemplates()
    {
        /* Jobs newTemplateJob = new Jobs ("Blank Job Template", "No Site", "Lead");
        Jobs newTemplateJob2 = new Jobs ("Residental Job", "No Site", "Lead");
        Jobs newTemplateJob3 = new Jobs ("Kitechen remodel", "No Site", "Lead");
        UserData.jobTemplatesArray.jobTemplatesList.Add(newTemplateJob);
        UserData.jobTemplatesArray.jobTemplatesList.Add(newTemplateJob2);
        UserData.jobTemplatesArray.jobTemplatesList.Add(newTemplateJob3); */

    }
    public void UpdateJobs()
    {
        //CleanJobs();
        foreach (Jobs p in UserData.jobTemplatesArray.jobTemplatesList)
        {
            templateDescription.text = p.jobDescription;
            templateCost.text = "$0";
            
            GameObject _tempgo2 = Instantiate(jobTemplateInfo, jobTempleteTransform);
            _tempgo2.GetComponentInChildren<JobTemplatesLoader>().thisJobTemplate = p;
        }
    }
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
