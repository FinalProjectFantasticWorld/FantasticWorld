using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayFunctionChatFisherMan : PlayFunctionChat
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject circlefishingRod;
    [SerializeField] private GameObject fishingRod;
    [SerializeField] private GameObject boat;
    [SerializeField] private GameObject movementFishingRod;
    [SerializeField] private GameObject collectAllObjects;
    private bool isPlayFunction;
    public override void playFunction()
    {
        if(collectAllObjects.transform.childCount > 0)
        {
            boat.GetComponent<PatrollerRegular>().enabled = true;
            player.transform.position = boat.transform.position;
            player.transform.parent = boat.transform;
            circlefishingRod.SetActive(true);
            fishingRod.SetActive(true);
            movementFishingRod.SetActive(true);
            isPlayFunction = true;
        }
        else
        {
            collectAllObjects.GetComponent<ColletAllTheObjects>().enabled = true;
        }

    }

    public override bool getIsPlayFunction()
    {
        return isPlayFunction;
    }

}
