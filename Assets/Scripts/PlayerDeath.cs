using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityTimer;

public class PlayerDeath : MonoBehaviour
{
    [Header("Component")]

    public GameObject gameOverUI;
    public GameObject gameView;
    public GameObject player;

    public SwipeTest playerSwipeTest;

    private Animator playerAnimator;

    private Timer _timer;
    public GameObject FireDeath;


    public void Start()
    {
        if (_timer != null)
        {
            _timer.Cancel();
        }

        playerSwipeTest = GetComponent<SwipeTest>();
        playerAnimator = playerSwipeTest.anim;
    }



    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "DeathZone")
        {
            if (collision.transform.name == "DeathZone")
            {
                playerAnimator.Play("Death_Ecrasement", -1, 0);

                player.GetComponent<SwipeTest>().enabled = false;

                _timer = Timer.Register(3, () =>
                {
                    gameView.SetActive(false);
                    gameOverUI.SetActive(true);

                    player.SetActive(false);

                    player.transform.position = new Vector3(0, 2, 0);

                    playerSwipeTest.desiredPosition = new Vector3(0, 1, 0);
                });
            }
            else
            {
                gameView.SetActive(false);
                gameOverUI.SetActive(true);

                player.SetActive(false);

                player.transform.position = new Vector3(0, 2, 0);

                playerSwipeTest.desiredPosition = new Vector3(0, 1, 0);
            }
        }

        if (collision.transform.tag == "EffectDeathZone")
        {
            FireDeath.SetActive(true);
            AudioManager.instance.FireDeathSource.PlayOneShot(AudioManager.instance.FireDeathSound);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
