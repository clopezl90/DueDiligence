using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuHandler : MonoBehaviour
{
    
    [SerializeField] Text userNametext;
    [SerializeField] GameObject loadingPanel;
    [SerializeField] GameObject mainPanel;
    // Start is called before the first frame update
    void Start()
    {
        userNametext.text = UserData.userValidationInfo.userName;
        //StartCoroutine(ShowLoadingPanel()); 
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    IEnumerator ShowLoadingPanel()
    {
        loadingPanel.SetActive(true);
        yield return new WaitForSeconds(6f);
        loadingPanel.SetActive(false);
        mainPanel.SetActive(true);
    }

}
