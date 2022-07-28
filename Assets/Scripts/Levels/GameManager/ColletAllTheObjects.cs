using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColletAllTheObjects : MonoBehaviour
{
    [Tooltip("all the garbage/fires in the game in theAllObjects transform.")] [SerializeField] private Transform theAllObjects;
    //[Tooltip("")] [SerializeField] private GameController gameController;
    [Tooltip("Hand of the player")] [SerializeField] private Transform handPlayer;
    [Tooltip("Text coin")] [SerializeField] private TextMeshProUGUI textCoins;
    [Tooltip("next level - name scene")] [SerializeField] private string nextLevel;
    [Tooltip("activate save game")] [SerializeField] private bool saveGame;
    [Tooltip("what happens when you lose/win game.")] [SerializeField] private LoseGame loseGame;
    private bool isNextLevel;
    private int nextSceneIndex;
    void Start()
    {
        nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
    }

    // Update is called once per frame
    void Update()
    {

        if (theAllObjects.childCount == 0 && handPlayer.childCount == 0)
        {
            if (saveGame)
            {
                if (PlayerPrefs.GetInt("levelAt") < nextSceneIndex)
                    PlayerPrefs.SetInt("levelAt", nextSceneIndex);
                int coin = int.Parse(textCoins.text.Substring(7));
                PlayerPrefs.SetInt("coins", coin);
            }
            //gameController.moveEndLevel();
            if (!isNextLevel)
                StartCoroutine(CoolDownRoutine()); 
            
        }
            
            
    }

    IEnumerator CoolDownRoutine()
    {
        isNextLevel = true;
        loseGame.winGame("Won", "Good Job!");
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene(nextLevel);

    }
}
