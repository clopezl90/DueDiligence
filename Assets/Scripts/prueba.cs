using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;

public class prueba : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RequestHelper helper = new RequestHelper();
        helper.Uri = "https://easycoding.com.co/due-diligence/prueba.php";
        helper.Body = JsonUtility.ToJson(helper);
        RestClient.Post(helper).Then(response =>
        {
            print(response.Text);
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
