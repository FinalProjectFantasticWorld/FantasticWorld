using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Statistics : MonoBehaviour
{

    [Tooltip("Statistics GUI Text.")] [SerializeField] private TextMeshProUGUI objectsGUI;
    [Tooltip("The garbage in the game.")] [SerializeField] private GameObject objects;
    [Tooltip("the description text of the statistics.")] [SerializeField] private string textStatistics;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        objectsGUI.text = textStatistics + ": " + objects.transform.childCount;
    }
}
