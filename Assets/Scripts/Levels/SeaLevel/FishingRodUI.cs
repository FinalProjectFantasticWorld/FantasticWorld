using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FishingRodUI : MonoBehaviour
{
    [Tooltip("KeyCode that has been pressed for controll Circle fishing rod")] [SerializeField] private KeyCode key;
    private Image imageKey; // get the image button key
    private void Start()
    {
        imageKey = GetComponent<Image>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(key))
        {
            imageKey.color = Color.green; // changing color of the current button that used.
        }
        if(Input.GetKeyUp(key))
        {
            imageKey.color = Color.white; // changing to the regular color
        }
    }
}
