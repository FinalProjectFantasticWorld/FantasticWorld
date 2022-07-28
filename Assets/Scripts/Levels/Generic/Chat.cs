using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Chat : MonoBehaviour,ChatInterface
{


    [Tooltip("Message Speaker GUI")] [SerializeField] private TextMeshProUGUI messageSpeeker;
    [Tooltip("Chat Content Message that contain the who speaker and his content message")] [SerializeField] private ChatContentMessages[] contentMessage;
    [Tooltip("Speed message text")] [SerializeField] private float speedSpeeker;
    [Tooltip("NPC")] [SerializeField] private GameObject NPC;
    [Tooltip("Activate playFunction of the NPC after finished talk")] [SerializeField] private bool isPlayFunction;
    [Tooltip("Pause of the game.")] [SerializeField] private bool notStopTime;
    private GameObject messageOpened; //openedChat
    private bool canPress = true;
    private int counter;


    private void Start()
    {
        counter = 0;
        messageOpened = this.transform.GetChild(0).gameObject;
        contentMessage[counter].whoSpeaker();
        messageSpeeker.text = contentMessage[counter++].getContentMessageSpeaker();
        

        Debug.Log("start: " + contentMessage.Length);
    }

    private void Update()
    {
        if(messageOpened.activeSelf)
        {
            if(!notStopTime)
                Time.timeScale = 0;
            if (Input.GetKeyDown(KeyCode.Z) && canPress)
                nextMessage();
            else if (Input.GetKeyDown(KeyCode.X) && canPress)
            {
                isPlayFunction = false;
                exitChat();
            }
              
        }       

    }

    public void exitChat()
    {
        playFunction();
        messageOpened.SetActive(false);
        counter = 0;
        messageSpeeker.text = contentMessage[counter++].getContentMessageSpeaker();
        if (!notStopTime)
            Time.timeScale = 1;
    }

    public void nextMessage()
    {
        Debug.Log("update: " + contentMessage.Length);
        if (counter < contentMessage.Length)
        {
            contentMessage[counter].whoSpeaker();
            StartCoroutine(sentenceDelay(contentMessage[counter++].getContentMessageSpeaker()));
        } 
        else
            exitChat();
        
    }

    IEnumerator sentenceDelay(string sentence)
    {
        canPress = false;
        messageSpeeker.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            messageSpeeker.text += letter;
            yield return new WaitForSeconds(speedSpeeker);
        }
        canPress = true;
    }

    private void playFunction()
    {
        if(isPlayFunction)
        {
            Debug.Log("isPlayFunction: " + isPlayFunction);
            NPC.GetComponent<PlayFunctionChat>().playFunction();
        }
    }

}
