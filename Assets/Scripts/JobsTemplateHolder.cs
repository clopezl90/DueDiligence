using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]

public class JobsTemplateHolder  
{      
    public List <Jobs> jobTemplatesList = new List <Jobs> ();                   

    public JobsTemplateHolder ()
    {
        jobTemplatesList = new List <Jobs> ();
        Jobs template = new Jobs("Template1", "NoSite", "Lead");
        jobTemplatesList.Add(template);
        // jobTemplatesList.Add(
        //     new Jobs("Template1", "NoSite", "Lead")
        // );
    } 

    
}
