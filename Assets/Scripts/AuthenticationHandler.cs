using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Nakama;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading.Tasks;
public class AuthenticationHandler : MonoBehaviour
{

    public string scheme;
    public string host;
    public int port;
    public string serverKey;
    private IClient client;
    private ISession session;
    private IApiAccount account;
    public User newUser;
    public static AuthenticationHandler instance;
    private IApiStorageObject[] userData;
    public InputField userEmail;
    public InputField userPassword;
    public InputField signUserEmail;
    public InputField signUserPassword;
    public InputField signUserPasswordRepeat;
    public InputField userName;

    [Header("TemporalObjectsForSignIn")]

    public UserRecords tempUserRecords;
    public ClientHolder tempClientArray = new ClientHolder();
    public JobsHolder tempJobsArray = new JobsHolder();
    public Jobs tempJob = new Jobs("", "", 0, "");
    public Clients tempClients = new Clients("", "", "", "");
    private AccountValidation validationInfo = new AccountValidation();

    public void Awake()
    {
        instance = this;        
        try
        {
            client = new Client(scheme, host, port, serverKey);
            //client = new Client(scheme, host, port, serverKey, UnityWebRequestAdapter.Instance);  
        }
        catch (ApiResponseException e)
        {
            Debug.LogError($"Error: {e.Message} / codes: {e.StatusCode}, {e.GrpcStatusCode}");
        }
    }
    
    void Start()
    {
        try
        {
            client = new Client(scheme, host, port, serverKey);
            newUser = new User();
            //newUser.userEmail = "rerere@123.com";
            //newUser.userName = "Herledy";
            //Login();
            print(client);
        }
        catch (Exception e)
        {
            print(e.Message);
            throw;
        }
    }

    public async void Login(string email, string password)
    {
        session = await client.AuthenticateEmailAsync(email, password, null, false);
        account = await client.GetAccountAsync(session);
        //StorageObjects(email);
        ReadStorageObjects(email);
        OnLogin(session, account, email);
        print(account);
    }

    private async void Login2(string email, string password)
    {
        try
        {
            session = await client.AuthenticateEmailAsync(email, password, null, false, null);
            account = await client.GetAccountAsync(session);
            await GetUserInformation(session, email);
            OnLogin(session, account, email);
            print(tempUserRecords);
            print(validationInfo.ToString());
        }
        catch (ApiResponseException e)
        {
            Debug.LogError($"Error: {e.Message} / codes: {e.StatusCode}, {e.GrpcStatusCode}");
            print(e.Message);
        }
    }

    /* public async void SignUp()
    {
        string email = "lopezcristianla@criswow.com";
        string password = "12345678";
        session = await client.AuthenticateEmailAsync(email, password, "Cristian", true);
        print(session);
    } */

    private async void SignUp(string email, string password, string username)
    //public async void SignUp()
    {
        /* string email = "lopezcristianla@criswow.com";
        string password = "12345678";
        session = await client.AuthenticateEmailAsync(email, password, "Cristian", true);
        print(session); */
        try
        {
            session = await client.AuthenticateEmailAsync(email, password, username, true);
            //await CreateAdminData(email, password);
            //session = await client.AuthenticateEmailAsync(email, password, null, true, null, retryConfiguration, canceller);
            //await client.UpdateAccountAsync(session, session.Username, null, null, null, country, null, retryConfiguration, canceller);
            CreateUserData(password, email, username);
        }
        catch (ApiResponseException e)
        {
            //loadingPanel.SetActive(false);
            //Error(error, e.Message);
            Debug.LogError($"Error: {e.Message} / codes: {e.StatusCode}, {e.GrpcStatusCode}");
        }


    }


    public async void StorageObjects(string email)
    {
        IApiWriteStorageObject[] writeObjects = new[] {
            new WriteStorageObject
            {
                Collection = email,
                Key = "User",
                Value = JsonUtility.ToJson(newUser)
            },
            new WriteStorageObject
            {
                Collection = email,
                Key = "Skill",
                Value = "{ \"skill\": 24 }"
            }
        };
        await client.WriteStorageObjectsAsync(session, writeObjects);
    }

    public async void ReadStorageObjects(string email)
    {
        IApiReadStorageObjectId[] objectsId = {
            new StorageObjectId
            {
                Collection = email,
                Key = "Skill",
                UserId = session.UserId
            },
            new StorageObjectId
            {
                Collection = email,
                Key = "User",
                UserId = session.UserId
            }
        };
        IApiStorageObjects objects = await client.ReadStorageObjectsAsync(session, objectsId);
        IApiStorageObject[] userData = objects.Objects.ToArray();

        foreach (IApiStorageObject o in userData)
        {
            print(o.Key + "/" + o.Value);
        }

        for (int i = 0; i < userData.Length; i++)
        {
            if (userData[i].Key == "User")
            {
                newUser = JsonUtility.FromJson<User>(userData[i].Value);
            }
        }
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void OnLoginButton()
    {
        Login2(userEmail.text, userPassword.text);
    }

    public void  OnLogin(ISession _session, IApiAccount _account, string _email)
    {

        UserData.instance.StoreUserData(client, session, account, tempUserRecords, validationInfo, tempClientArray, tempJobsArray);
        LoadScene("MainMenu");
    }

    public void OnSignUpButton()
    {
        if (string.IsNullOrEmpty(signUserEmail.text) || string.IsNullOrEmpty(signUserPassword.text)
            || string.IsNullOrEmpty(signUserPasswordRepeat.text) || string.IsNullOrEmpty(userName.text))
        {
            //Error(error, "Please Fill all the Fields");
            print("Please fill all the fields");
            return;
        }
        if (signUserPassword.text != signUserPasswordRepeat.text)
        {
            //Error(error, "Passwords Don't Match");
            print("Passwords do not match");
            return;
        }
        if (signUserPassword.text.Contains('#') || signUserPassword.text.Contains('?') || signUserPassword.text.Contains('%')
        || signUserPassword.text.Contains("\"") || signUserPassword.text.Contains("\'") || signUserPassword.text.Contains("&"))
        {
            //Error(error, "Please don't use special characters for password: \", \', ?, #, %, &.");
            print("Please don't use special characters for password: \", \', ?, #, %, &.");
            return;
        }


        CheckSign(signUserEmail.text, signUserPassword.text, userName.text);
        //SignUp(signEmail.text, signUserPassword.text, country);

    }

    private async void CheckSign(string email, string password, string userName)
    {
        //loadingPanel.SetActive(true);
        try
        {
            session = await client.AuthenticateEmailAsync(email, password, null, false);
            print("The email is already in use");
            client?.SessionLogoutAsync(session);
            //loadingPanel.SetActive(false);
        }
        catch (ApiResponseException e)
        {
            print(e.Message);
            SignUp(email, password, userName);
        }
    }
    

    private async void CreateUserData(string _password, string _email, string _userName)
    {
        AccountValidation validation = new AccountValidation
        {
            email = _email,
            password = _password,
            userName = _userName
        };

        JobsHolder jobsArray = new JobsHolder
        {
            //jobsList = new List<Jobs>{tempJob}
            jobsList = new List<Jobs>()
        };

        ClientHolder clients = new ClientHolder
        {        
            //clientsList = new List<Clients>{tempClients}
            clientsList = new List<Clients>()
        };

        UserRecords recordsTemp = new UserRecords
        {
            tutorial = false,
            appPurchased = false
        };

        WriteStorageObject storageObject = new WriteStorageObject
        {
            Collection = _email,
            Key = "UserRecords",
            Value = JsonUtility.ToJson(recordsTemp)
        };

        WriteStorageObject storageObject3 = new WriteStorageObject
        {
            Collection = _email,
            Key = "UserValidation",
            Value = JsonUtility.ToJson(validation)
        };

        WriteStorageObject storageObject4 = new WriteStorageObject
        {
            Collection = _email,
            Key = "Clients",
            Value = JsonUtility.ToJson(clients)
        };

        WriteStorageObject storageObject5 = new WriteStorageObject
        {
            Collection = _email,
            Key = "Jobs",
            //Value = JsonUtility.ToJson(jobs)
            Value = JsonUtility.ToJson(jobsArray)
        };
        IApiWriteStorageObject[] Objects = { storageObject, storageObject3, storageObject4, storageObject5 };
        await client.WriteStorageObjectsAsync(session, Objects);
    }

    public async Task GetUserInformation(ISession _session, string _email)
    {
        IApiReadStorageObjectId[] objectsId = {
            new StorageObjectId
            {
                Collection = _email,
                Key = "UserRecords",
                UserId = session.UserId
            },
            new StorageObjectId
            {
                Collection = _email,
                Key = "UserValidation",
                UserId = session.UserId
            },
            new StorageObjectId
            {
                Collection = _email,
                Key = "Clients",
                UserId = session.UserId
            },
            new StorageObjectId
            {
                Collection = _email,
                Key = "Jobs",
                UserId = session.UserId
            }
        };
        IApiStorageObjects objects = await client.ReadStorageObjectsAsync(session, objectsId);
        IApiStorageObject[] userData = objects.Objects.ToArray();

        for (int i = 0; i < userData.Length; i++)
        {
            switch (userData[i].Key)
            {
                case "UserValidation":
                    print(userData[i].Value);
                    validationInfo = JsonUtility.FromJson<AccountValidation>(userData[i].Value);
                    break;
                case "UserRecords":
                    tempUserRecords = JsonUtility.FromJson<UserRecords>(userData[i].Value);
                    break;
                case "Clients":
                    tempClientArray = JsonUtility.FromJson<ClientHolder>(userData[i].Value);
                    break;
                case "Jobs":
                    tempJobsArray = JsonUtility.FromJson<JobsHolder>(userData[i].Value);
                    break;
                
            }
        }        
    }    
}
