using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LicensedWorkforceMenuHandler : MonoBehaviour
{
   public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}