using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Statistics : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI objectsGUI;
    [SerializeField] private GameObject objects;
    [SerializeField] private string textStatistics;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        objectsGUI.text = textStatistics + ": " + objects.transform.childCount;
    }
}
