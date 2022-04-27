using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuHandler : MonoBehaviour
{
    
    [SerializeField] Text userNametext;
    // Start is called before the first frame update
    void Start()
    {
        userNametext.text = UserData.userValidationInfo.userName;
        
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

}
