using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AddCoins : MonoBehaviour
{
    [Tooltip("text coin GUI ")] [SerializeField] private TextMeshProUGUI textCoins;
    [SerializeField] private int addCoins;
    private int coins = 0;

    private void Start()
    {
        coins = PlayerPrefs.GetInt("coins");
        textCoins.text = "Coins: " + (++coins);
    }

    public void addCoin()
    {
        textCoins.text = "Coins: " + (coins + addCoins);
    }

}
