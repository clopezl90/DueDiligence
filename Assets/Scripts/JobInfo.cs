using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobInfo : MonoBehaviour
{
    public static JobInfo instance;
    public string thisJobDescription;

    

    // Start is called before the first frame update

    public void Awake()
    {
        instance=this;
       
    }
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AssingJobValues(Jobs jobToValue)
    {
        thisJobDescription = jobToValue.jobDescription;
        print("this is the " + thisJobDescription);

    }
}


