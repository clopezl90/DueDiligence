using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OverviewMenuHandler : MonoBehaviour
{
    [SerializeField] Text Description;
    [SerializeField] Text Client;
    [SerializeField] Text Amount;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    
}
