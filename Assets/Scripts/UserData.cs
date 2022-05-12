using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Nakama;
using System.Threading.Tasks;
using System.Threading;

[Serializable]

public class UserData : MonoBehaviour
{
    public static IClient client;
    public static ISession session;
    public static User user;
    public static ClientHolder clientsArray;
    
    public static JobsHolder jobsArray;
    public static JobsTemplateHolder jobTemplatesArray;

    

    public static UserRecords userRecords;
    public static AccountValidation userValidationInfo;

    public static UserData instance;
    public static IApiAccount nakamaAccount;

    private void Awake()
    {        
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
        instance = this;         
    }

    public void StoreUserData(IClient _client, ISession _session, IApiAccount _account, UserRecords _userRecords, AccountValidation _validationInfo, ClientHolder _clientUser, JobsHolder _jobs, JobsTemplateHolder _jobTemplates)
    {
        client = _client;
        //socket = _socket;
        session = _session;
        nakamaAccount = _account;
        userRecords = _userRecords;
        userValidationInfo = _validationInfo;
        jobsArray = _jobs;  
        clientsArray = _clientUser;  
        jobTemplatesArray = _jobTemplates;

        //retryConfiguration = _retryConfiguration;
        //userRecords.CalculateCurrentLevel();
        //if (_user != null) { user = _user; }        
        print("User Data Stored");    
        
    }

    public void SendInfo() { SendInformation(); }

    async void SendInformation()
    {
        try
        {
            await WriteInfo();
        }
        catch (ApiResponseException e)
        {
            
            try {
                    // Attempt to refresh the existing session.
                    session = await client.SessionRefreshAsync(session);
                    SendInfo();
                } 
            catch (ApiResponseException) {
                    print(e.Message);
                }
            
            
        }
    }
    private async Task WriteInfo()
    {
        WriteStorageObject storageObject = new WriteStorageObject
        {
            Collection = userValidationInfo.email,
            Key = "UserRecords",
            Value = JsonUtility.ToJson(userRecords)
        };
        WriteStorageObject storageObject3 = new WriteStorageObject
        {
            Collection = userValidationInfo.email,
            Key = "Clients",
            Value = JsonUtility.ToJson(clientsArray)
        };
        
        WriteStorageObject storageObject4 = new WriteStorageObject
        {
            Collection = userValidationInfo.email,
            Key = "Jobs",
            Value = JsonUtility.ToJson(jobsArray)
        };

        WriteStorageObject storageObject5 = new WriteStorageObject
        {
            Collection = userValidationInfo.email,
            Key = "JobsTemplates",
            Value = JsonUtility.ToJson(jobTemplatesArray)
        };
        
        

        
        /* WriteStorageObject storageObject2 = new WriteStorageObject
        {
            Collection = userValidationInfo.email,
            Key = "UserValidation",
            Value = JsonUtility.ToJson(userValidationInfo)
        };
        
        WriteStorageObject storageObject4 = new WriteStorageObject
        {
            Collection = userValidationInfo.email,
            Key = "Jobs",
            Value = JsonUtility.ToJson(jobs)
        }; */
        IApiWriteStorageObject[] Objects = { storageObject, storageObject3, storageObject4,storageObject5};
        await client.WriteStorageObjectsAsync(session, Objects);
    }
}
