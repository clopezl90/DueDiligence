using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]

public class Clients
{
    public string clientName;
    public string clientCompany;
    public string clientPhone;
    public string clientEmail;

    public Clients(string _clientName)
    {
        clientName = _clientName;
    }


}
