using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour
{
    [Tooltip("Timer of the game.")] [SerializeField] private TimerGame timer;
    [Tooltip("Player")] [SerializeField] private SimpleSampleCharacterControl playerMovement;
    public void selectSkill(string skill)
    {
        switch (skill)
        {
            case "Timer":
                timerSkill(skill);
                break;
            case "Speed":
                speedSkill(skill);
                break;

        }
    }

    //timerSkill
    private void timerSkill(string skill)
    {
        timer.addTimeSkill(30);
        Debug.Log("Timer getting: " + PlayerPrefs.GetString(skill));
        PlayerPrefs.SetString(skill, "0");
    }

    //speedSkill
    private void speedSkill(string skill)
    {
        StartCoroutine(timeSpeedSkill());
        Debug.Log("Speed getting: " + PlayerPrefs.GetString(skill));
        PlayerPrefs.SetString(skill, "0");
    }

    //time speed skill.
    IEnumerator timeSpeedSkill()
    {
        playerMovement.increaseSpeedSkill(1.5f);
        yield return new WaitForSeconds(10);
        playerMovement.increaseSpeedSkill(1f);
    }




}
