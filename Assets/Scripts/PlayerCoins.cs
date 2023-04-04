using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerCoins : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI runCoinCounter;
    public TextMeshProUGUI gameOverCoinCounter;
    [Header("Counter Settings")]
    public int currentCoins;
    //public GameObject GoldEffect;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Coin")
        {
            currentCoins += 1;
            AudioManager.instance.coinSource.PlayOneShot(AudioManager.instance.coinSound);
            runCoinCounter.text = currentCoins.ToString();
            //GoldEffect.SetActive(true);

            Destroy(collision.gameObject);
        } 
    }
}
