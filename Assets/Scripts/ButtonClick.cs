using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    
    public int SetValue;
    public Button _button;
    public ShopManager _shopManager;
    private bool buttonClick=false;



    void Start()
    {
        Button btn = _button.GetComponent<Button>();
        //_shopManager = GetComponent<ShopManager>();
        btn.onClick.AddListener(TaskOnClick);

    }

    void TaskOnClick()
    {
        if (buttonClick)
        {
            _shopManager.indexHatList = 0;
            buttonClick = false;
        }
        else
        {
            _shopManager.indexHatList = SetValue;
            buttonClick = true;
        }
    }

}
