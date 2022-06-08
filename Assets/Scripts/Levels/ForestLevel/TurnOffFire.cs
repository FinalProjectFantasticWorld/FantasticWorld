using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TurnOffFire : MonoBehaviour
{
    private TextMesh timeFire;
    [SerializeField] private float timeLeft;
    [SerializeField] private LoseGame loseGame;
    private bool takingAway;
    void Start()
    {
        timeFire = GetComponent<TextMesh>();
        timeFire.text = "Time: " + (timeLeft);
        takingAway = false;
        Debug.Log("TimeFire: " + timeFire.text);
    }

    // Update is called once per frame
    void Update()
    {
        if (!takingAway)
        {
            StartCoroutine(timerTaken());
        }
    }

    IEnumerator timerTaken()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        timeLeft -= 1;
        if (timeLeft < 0)
        {
            loseGame.loseGame("GameOver","the time of the fire is over!");
        }

        timeFire.text = "" + (timeLeft);
        takingAway = false;
    }


}
