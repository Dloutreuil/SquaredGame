using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    
    
    public int indexHatList=0;
    public GameObject parentHat;
    private GameObject Hat;

    public GameObject gameOverUI;
    public GameObject mainMenuUI;
    public PlayerDeath playerdeathScript;

    public int currentHat;
    string hatKey = "currentHat";

    public bool hatIsSaved=false;
    public bool hatIsLoaded;

    private void Start()
    {
        
        Hat = parentHat.transform.GetChild(indexHatList).gameObject;
    }

    void FixedUpdate()
    {
        

        if (indexHatList == 0)
        {
            Hat.SetActive(false);
            Hat = parentHat.transform.GetChild(0).gameObject;
            Hat.SetActive(true);
            SaveHat();
        }
        else
        {
            Hat.SetActive(false);
            Hat = parentHat.transform.GetChild(indexHatList).gameObject;
            Hat.SetActive(true);
            SaveHat();
        }

        /*if (mainMenuUI.activeInHierarchy == true)
        {
            LoadHat();
        }
        if (gameOverUI.activeInHierarchy == true)
        {
            LoadHat();
        }*/

        /*switch (indexHatList)
        {
            case 0:
                Hat.SetActive(false);
                Hat = parentHat.transform.GetChild(0).gameObject;
                Hat.SetActive(true);
                break;

            default:
                Hat.SetActive(false);
                Hat = parentHat.transform.GetChild(indexHatList).gameObject;
                Hat.SetActive(true);
                break;
        }*/



    }
   
    public void SaveHat()
    {
        if (hatIsSaved == false)
        {
            PlayerPrefs.SetInt(hatKey, indexHatList);
            PlayerPrefs.Save();

            Debug.Log(indexHatList);

            hatIsSaved = true;
        }
    }

    public void LoadHat()
    {
        if (hatIsLoaded == false)
        {
            indexHatList = PlayerPrefs.GetInt(hatKey, 0);

            Debug.Log(indexHatList);

            hatIsLoaded = true;
        }
    }
}
