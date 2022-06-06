using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TutorialModel
{
    [SerializeField] private GameObject[] arrayTutorialObjects;
    [SerializeField] private bool isNPC;
    [SerializeField] private bool isCollision;
    [SerializeField] [TextArea(3, 10)] private string textTutorial;

    public GameObject[] getGameObjects()
    {
        return arrayTutorialObjects;
    }

    public string getTextTutorial()
    {
        return textTutorial;
    }

    public bool getIsNPC()
    {
        return isNPC;
    }

    public bool getIsCollision()
    {
        return isCollision;
    }

}
