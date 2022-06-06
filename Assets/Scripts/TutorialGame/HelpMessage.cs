using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HelpMessage : MonoBehaviour
{

    [SerializeField] private GameObject helpTutorial;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            helpTutorial.SetActive(true);
        }
    }




    
}
