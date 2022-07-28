using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : MonoBehaviour
{
    [Tooltip("KeyCode to open menu")] [SerializeField] private KeyCode keyOpenMenu;
    [Tooltip("Menu GameObject")] [SerializeField] private GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyOpenMenu))
        {
            menu.SetActive(true);
        }
    }
}
