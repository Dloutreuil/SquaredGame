using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI mainTotalCoinCounter;
    public TextMeshProUGUI runCoinCounter;
    public TextMeshProUGUI gameOverCoinCounter;
    public TextMeshProUGUI totalCoinCounter;
    public GameObject gameOverUI;
    public GameObject MainMenuUI;
    
    [SerializeField]
    GameObject player;

    PlayerCoins playerCoins;




    [Header("Counter Settings")]
    public int currentCoins;
    public int totalCoins;
    public int DelayAmount;
    string totalCoinsKey = "TotalCoins";

    public bool coinsAdded;
    public bool coinsAreSaved;
    public bool coinsAreLoaded;


    protected float Timer;

    private void Awake()
    {
        playerCoins = player.GetComponent<PlayerCoins>();
    }

    

    // Update is called once per frame
    void Update()
    {
        #region Load coins on Main Screen

        if (MainMenuUI.activeInHierarchy)
        {
            LoadTotalCoins();
            mainTotalCoinCounter.text = totalCoins.ToString();
        }

        #endregion

        #region Game Over coins count, load & save

        currentCoins = playerCoins.currentCoins;
        
        if (gameOverUI.activeInHierarchy && currentCoins > 0)
        {
            gameOverCoinCounter.text = currentCoins.ToString("+ 0");
            AddCoinsToTotal();
            SaveTotalCoins();
        }
        
        if (gameOverUI.activeInHierarchy && currentCoins == 0)
        {
            gameOverCoinCounter.text = currentCoins.ToString("0");
            LoadTotalCoins();
        }
        
        totalCoinCounter.text = totalCoins.ToString();

        #endregion
    }


    public void AddCoinsToTotal()
    {
        if (coinsAdded == false)
        totalCoins += currentCoins;
        coinsAdded = true;
    }    

    public void SaveTotalCoins()
    {
        if (coinsAreSaved == false)
        {
            PlayerPrefs.SetInt(totalCoinsKey, totalCoins);
            PlayerPrefs.Save();
            
            coinsAreSaved = true;
        }
    }

    public void LoadTotalCoins()
    {
        if(coinsAreLoaded == false)
        {
            totalCoins = PlayerPrefs.GetInt(totalCoinsKey, 0);
            
            coinsAreLoaded = true;
        }
    }



    private void GameOver()
    {

    }
}
