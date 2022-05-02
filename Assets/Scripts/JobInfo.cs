using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JobInfo : MonoBehaviour
{
    public static JobInfo instance;
    public string thisJobDescription;
    public Text thisJobDescription2;
    public Text thisJobStatus;
    public Text thisJobReward;
    

    

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
        //thisJobDescription = jobToValue.jobDescription;
        thisJobDescription2.text = jobToValue.jobDescription;
        thisJobStatus.text = jobToValue.jobStatus;
        thisJobReward.text = jobToValue.jobReward.ToString();

        print("this is the " + thisJobDescription2);

    }
}


