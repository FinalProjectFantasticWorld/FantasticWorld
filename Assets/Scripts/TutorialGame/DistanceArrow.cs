using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DistanceArrow : MonoBehaviour
{
    [SerializeField] private int distance;
    private GameObject player;
    private bool isDestroy;
    private PlayFunctionChat playFunctionChat;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        PlayFunctionChat hinge = gameObject.GetComponentInParent(typeof(PlayFunctionChat)) as PlayFunctionChat;

        if (hinge != null)
            playFunctionChat = transform.parent.parent.GetComponent<PlayFunctionChat>();

    }
    private void Update()
    {
        //float dis = Vector3.Distance(new Vector3(player.transform.position.x,transform.position.y,player.transform.position.z), transform.position);
        //Debug.Log("Distance : " + dis);
        
        if(playFunctionChat != null && playFunctionChat.getIsPlayFunction())
        {
            Debug.Log("Distance : ");
            TutorialGame.distroyCounter--;
           isDestroy = true;
           Destroy(this.gameObject);

        }

        

    }

    private void OnDestroy()
    {
        TutorialGame.distroyCounter--;
    }

}
