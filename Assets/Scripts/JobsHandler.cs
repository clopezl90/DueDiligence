using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JobsHandler : MonoBehaviour
{
    public Text jobDescription;
    public Text jobClient;
    public Text jobReward;

    public int buildingIndex;

    public Jobs thisJob;

    public void AssignValues(string _description, string _client, Jobs _job)
    {
        jobDescription.text = _description;
        jobClient.text = _client;
        thisJob = _job;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
