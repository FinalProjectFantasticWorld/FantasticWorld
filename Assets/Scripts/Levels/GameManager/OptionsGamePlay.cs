using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsGamePlay : MonoBehaviour
{
    [Tooltip("the speed sensativity")] [SerializeField] public static float sensativity = 1;
    [Tooltip("Slider of sensativity")] [SerializeField] private Slider sliderSensitivity;
    [Tooltip("Maximum speed sensativity")] [SerializeField] private float maxSensativity;


    [Tooltip("the intensity of the volume")] [SerializeField] public static float volume = 1;
    [Tooltip("Slider of volume")] [SerializeField] private Slider sliderVolume;
    [Tooltip("Maximum volume")] [SerializeField] private float maxVolume;
    [Tooltip("MenuGamePlay")] [SerializeField] private GameObject menuGamePlay;

    public static bool menuIsActive;

    private AudioSource audio;
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }


    private void Start()
    {
        
        audio = GetComponent<AudioSource>();
        sliderVolume.value = maxVolume/2;
        if (AutoSensitivityMouse.time > 0)
            sensativity = sliderSensitivity.value = AutoSensitivityMouse.time;
        else
            sensativity = sliderSensitivity.value = maxSensativity / 2;
        //setSensativity();
        //setVolume();

    }

    private void setSensativity()
    {
        
            sensativity = sliderSensitivity.value;
    }

    private void setVolume()
    {
        //if(sliderSensitivity != null)
        volume = sliderVolume.value;
        audio.volume = volume;
    }

    private void Update()
    {
        if(menuGamePlay.activeSelf && sliderSensitivity.value != sensativity)
        {
            setSensativity();
            //Debug.Log("Sensativity: " + sensativity);
        }
        if (menuGamePlay.activeSelf && (sliderVolume.value * maxVolume) != volume)
        {
            setVolume();
            //Debug.Log("Volume: " + volume);
        }    
            
    }

    public float getSensativity()
    {
        return sensativity;
    }

    public float getVolume()
    {
        return volume;
    }


}
