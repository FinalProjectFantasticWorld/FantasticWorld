using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFunctionChatFisherManBoat : PlayFunctionChat
{
    [SerializeField] private GameObject boat;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject circleFishingRod;
    [SerializeField] private GameObject fishingRod;
    [SerializeField] private GameObject movementFishingRod;
    [SerializeField] private Vector3 outFromBoat;
    private bool isPlayFunction;
    public override void playFunction()
    {
        
        if(!boat.GetComponent<PatrollerRegular>().enabled)
        {
            player.transform.position = outFromBoat;
            boat.GetComponent<Animator>().enabled = false;
            player.transform.parent = null;
            circleFishingRod.SetActive(false);
            fishingRod.SetActive(false);
            movementFishingRod.SetActive(false);
            isPlayFunction = true;
        }
            
    }

    public override bool getIsPlayFunction()
    {
        return isPlayFunction;
    }
}
