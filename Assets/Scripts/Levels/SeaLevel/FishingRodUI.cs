using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FishingRodUI : MonoBehaviour
{
    [SerializeField] private KeyCode key;
    private Image imageKey;
    private void Start()
    {
        imageKey = GetComponent<Image>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(key))
        {
            imageKey.color = Color.green;
        }
        if(Input.GetKeyUp(key))
        {
            imageKey.color = Color.white;
        }
    }
}
