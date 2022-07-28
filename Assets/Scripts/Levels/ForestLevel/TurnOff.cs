using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurnOff : MonoBehaviour
{
    [Tooltip("hand Player")] [SerializeField] private GameObject handPlayer;
    [Tooltip("lives of fire")] [SerializeField] private int lives;
    [Tooltip("Slider of lives")] [SerializeField] private Slider slider;
    [Tooltip("Gradient of lives")] [SerializeField] private Gradient gradient;
    [Tooltip("Fill of lives")] [SerializeField] private Image fill;
    private void Start()
    {
        lives *= 2;
        if(slider != null)
        {
            slider.maxValue = lives;
            slider.value = lives;
            fill.color = gradient.Evaluate(1f);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        
        if (other.transform.tag == "Ballet")
        {
            if (lives <= 0)
            {
                transform.parent.GetComponent<AddCoins>().addCoin();
                Destroy(this.gameObject);
            }
            slider.value = lives;
            fill.color = gradient.Evaluate(slider.normalizedValue);
            lives -= 1;
            Debug.Log("INNNNNNNNNNNNNNNNNNNNN-1");
        }
    }
    
}
