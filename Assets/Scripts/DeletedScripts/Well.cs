using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Well : MonoBehaviour
{
    [Tooltip("the text that show for talk with well")] [SerializeField] private TextMeshProUGUI showPressTextGUI;
    [Tooltip("show text time for renew ammo")] [SerializeField] private TextMeshProUGUI showTimeWaitTextGUI;
    [Tooltip("KeyCode to talk with well")] [SerializeField] private KeyCode keyCode;
    [Tooltip("the time that need to wait for renew ammo")] [SerializeField] private int timeWait;
    [Tooltip("Shooter")] [SerializeField] private Shooter shooterPlayer;
    private void Start()
    {
        //shooterPlayer = GetComponent<Shooter>();
    }
    private void OnCollisionStay(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            if(Input.GetKeyDown(keyCode))
            {
                StartCoroutine(timerTaken());
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        showPressTextGUI.gameObject.SetActive(true);
    }
    private void OnCollisionExit(Collision collision)
    {
        showPressTextGUI.gameObject.SetActive(false);
    }

    IEnumerator timerTaken()
    {
        int oldTimeWait = timeWait;
        showPressTextGUI.gameObject.SetActive(false);
        showTimeWaitTextGUI.gameObject.SetActive(true);
        for (int i = 0; i < timeWait; i++)
        {
            yield return new WaitForSeconds(1);
            timeWait -= 1;
            showTimeWaitTextGUI.text = "" + (timeWait);
        }
        shooterPlayer.Reload();
        timeWait = oldTimeWait;
        showTimeWaitTextGUI.gameObject.SetActive(false);
    }
}
