using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseGame : MonoBehaviour
{
    [Tooltip("Text title (lose or win)")] [SerializeField] private TextMeshProUGUI happenGameText;
    [Tooltip("string the next scene because winning level")] [SerializeField] private string nameWinScene;
    [Tooltip("string the main scene because losing level")] [SerializeField] private string nameLoseScene;
    [Tooltip("Main Camera")] [SerializeField] private Camera MainCamera;
    [Tooltip("Text explanation what happen if losing or winning")] [SerializeField] private TextMeshProUGUI explanationHappenGame;
    [Tooltip("Audio Manager")] [SerializeField] private AudioManager audioManager;
    private Camera cam;
    private GameObject player;
    private bool isHappen;
    private bool isWin;
    // Start is called before the first frame update
    void Start()
    {
        isHappen = false;
        happenGameText.gameObject.SetActive(false);
        explanationHappenGame.gameObject.SetActive(false);
        player = GameObject.FindWithTag("Player");
        cam = transform.GetChild(0).GetComponent<Camera>();
        cam.transform.gameObject.SetActive(false);
    }

    IEnumerator CoolDownRoutine(string textLose)
    {
        if(!isHappen)
        {
            isHappen = true;
            explanationHappenGame.text = textLose;
            happenGameText.gameObject.SetActive(true);
            explanationHappenGame.gameObject.SetActive(true);
            cam.transform.gameObject.SetActive(true);
            player.SetActive(false);
            if(isWin && audioManager != null)
                audioManager.winGame();

            yield return new WaitForSeconds(5.0f);
            happenGameText.gameObject.SetActive(false);
            explanationHappenGame.gameObject.SetActive(false);
            if (!isWin)
                SceneManager.LoadScene(nameLoseScene);
            else
                SceneManager.LoadScene(nameWinScene);
        }
    }

    public void loseGame(string titleText, string textLose)
    {
        isWin = false;
        StartCoroutine(CoolDownRoutine(textLose));
    }

    public void winGame(string titleText, string textLose)
    {
        happenGameText.text = titleText;
        isWin = true;
        StartCoroutine(CoolDownRoutine(textLose));
    }


}
