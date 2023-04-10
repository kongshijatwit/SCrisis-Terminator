using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;
using System;
using System.Text.RegularExpressions;

public class SCMainMenuController : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start() {
   
    }
    public void URLButtonClick_1()
    {
        Application.OpenURL("https://www.sparksicklecellchange.com/sickle-cell-genetics/history?msclkid=b48d293897ca12de18634d0bc97634ba");       
        UnityEngine.Debug.Log("opened link");
    }
    public void URLButtononClick_2()
    {
        Application.OpenURL("https://gbscda.org");
        UnityEngine.Debug.Log("opened link");
    }
    // Update is called once per frame
    void Update()
    {
    

    }
}
