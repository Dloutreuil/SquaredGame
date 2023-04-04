using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject gameView;
    
    private bool isDraging = false;

    // Update is called once per frame
    private void Update()
    {
        #region Mobile Input

        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                
                isDraging = true;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDraging = false;
                Reset();
            }
        }
        #endregion

        if (isDraging == true)
        {
            mainMenu.SetActive(false);
            gameView.SetActive(true);
        }
        if (isDraging == false)
        {
            mainMenu.SetActive(true);
            gameView.SetActive(false);
        }
    }
    private void Reset()
    {
        
        isDraging = false;
    }
}
