using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CoinUI : MonoBehaviour
{
    Player player;
    public Text coinCountTxt;
    int coinCount;

    void Start()
    {
        player = FindObjectOfType<Player>();

        player.OnCoinCollected += AddCoin;
    }

    void Update()
    {
        coinCountTxt.text = "Coins: " + coinCount.ToString();
    }

    public void AddCoin()
    {
        coinCount++;
    }
}
