using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerGame : MonoBehaviour
{

    [Tooltip("Text Game timer")] [SerializeField] private TextMeshProUGUI timerText;
    [Tooltip("initial amount of time")] [SerializeField] private float timeLeft;
    [Tooltip("Text coins")] [SerializeField] private TextMeshProUGUI textCoins;
    [Tooltip("what happens when you lose/win game.")] [SerializeField] private LoseGame loseGame;
    private float addTime;
    private bool takingAway;
    // Start is called before the first frame update
    void Start()
    {
        takingAway = false;
        timerText.text = "Time: " + (timeLeft);
    }

    // Update is called once per frame
    void Update()
    {
        if(!OptionsGamePlay.menuIsActive)
        {
            if(!takingAway)
            {
                StartCoroutine(timerTaken());
            }
        }
        
    }

    IEnumerator timerTaken()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        if (timeLeft == 0)
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            int coin = int.Parse(textCoins.text.Substring(7));
            PlayerPrefs.SetInt("coins", coin);
            loseGame.loseGame("GameOver","Time Over");
        }
        else
        {
            timeLeft -= 1;
            timerText.text = "Time: " + (timeLeft + addTime);
        }
            
        takingAway = false;
    }

    public void addTimeSkill(float addTime)
    {
        this.addTime += addTime;
    }
}