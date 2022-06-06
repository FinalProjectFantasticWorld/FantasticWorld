using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayFunctionChatWell : PlayFunctionChat
{
    [SerializeField] private KeyCode keyCode;
    [SerializeField] private int timeWait;
    [SerializeField] private TextMeshProUGUI showTimeWaitTextGUI;
    [SerializeField] private Shooter shooterPlayer;

    private bool isPlayFunction;
    public override void playFunction()
    {
        StartCoroutine(timerTaken());
        isPlayFunction = true;

    }

    public override bool getIsPlayFunction()
    {
        return isPlayFunction;
    }

    IEnumerator timerTaken()
    {
        int oldTimeWait = timeWait;
        showTimeWaitTextGUI.gameObject.SetActive(true);
        while(timeWait > 0)
        {
            showTimeWaitTextGUI.text = "" + (timeWait);
            yield return new WaitForSeconds(1);
            timeWait -= 1;
            showTimeWaitTextGUI.text = "" + (timeWait);
        }
        shooterPlayer.Reload();
        timeWait = oldTimeWait;
        showTimeWaitTextGUI.gameObject.SetActive(false);
    }

}
