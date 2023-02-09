using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApplication : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        CloseApplicationHandler();
    }
    
    void CloseApplicationHandler()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("Esc key has been pressed");
            Application.Quit();
        }
    }
}
