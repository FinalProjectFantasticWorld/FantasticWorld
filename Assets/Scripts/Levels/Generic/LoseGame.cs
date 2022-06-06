using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseGame : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI loseGameText;
    [SerializeField] private string nameScene;
    [SerializeField] private Camera MainCamera;
    [SerializeField] private TextMeshProUGUI explanationLoseGame;
    private Camera cam;
    private GameObject player;
    private bool isLose;
    // Start is called before the first frame update
    void Start()
    {
        isLose = false;
        loseGameText.gameObject.SetActive(false);
        explanationLoseGame.gameObject.SetActive(false);
        player = GameObject.FindWithTag("Player");
        cam = transform.GetChild(0).GetComponent<Camera>();
        cam.transform.gameObject.SetActive(false);
    }

    IEnumerator CoolDownRoutine(string textLose)
    {
        if(!isLose)
        {
            isLose = true;
            explanationLoseGame.text = textLose;
            loseGameText.gameObject.SetActive(true);
            explanationLoseGame.gameObject.SetActive(true);
            cam.transform.gameObject.SetActive(true);
            player.SetActive(false);
            yield return new WaitForSeconds(5.0f);
            loseGameText.gameObject.SetActive(false);
            explanationLoseGame.gameObject.SetActive(false);
            SceneManager.LoadScene(nameScene);
        }
    }

    public void loseGame(string textLose)
    {
        StartCoroutine(CoolDownRoutine(textLose));
    }
}
