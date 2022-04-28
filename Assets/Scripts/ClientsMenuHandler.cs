using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClientsMenuHandler : MonoBehaviour
{

    [SerializeField] InputField clientName;
    [SerializeField] InputField clientCompany;
    [SerializeField] InputField clientPhone;
    [SerializeField] InputField clientEmail;

    [SerializeField] Text clientNameText;
    [SerializeField] Text clientCompanyText;
    [SerializeField] Text clientEmailText;
    [SerializeField] Text clientPhoneText;

    public GameObject clientsInfo;
    public Transform clientsTransform;
    public GameObject noClientsText;

    void Start()
    {
        if (UserData.clientsArray.clientsList.Count > 0)
        {
            UpdateClients();
        }
        else
        {
            noClientsText.SetActive(true);
        }
    }
    void Update()
    {

    }
    public void SendClients()
    {
        Clients newClient = new Clients(clientName.text, clientCompany.text, clientPhone.text, clientEmail.text);
        UserData.clientsArray.clientsList.Add(newClient);
        UpdateClients();
        noClientsText.SetActive(false);
        UserData.instance.SendInfo();
        clientName.text = "";
        clientCompany.text = "";
        clientEmail.text = "";
        clientPhone.text = "";

    }
    public void UpdateClients()
    {
        CleanClients();
        foreach (Clients p in UserData.clientsArray.clientsList)
        {
            clientNameText.text = p.clientName;
            clientCompanyText.text = p.clientCompany;
            clientEmailText.text = p.clientEmail;
            clientPhoneText.text = p.clientPhone;
            GameObject _tempgo2 = Instantiate(clientsInfo, clientsTransform);
        }
        
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }


    public void CleanClients()
    {
        foreach (Transform child in clientsTransform.transform)
        {
            GameObject.Destroy(child.gameObject);

        }


    }
}
