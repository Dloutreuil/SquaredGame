using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTimer;

public class RockFall : MonoBehaviour
{
    public GameObject Rock;
    public GameObject RockGold;
    public GameObject Gold;
    public GameObject[] Plateforms;
    public int chanceGold;
    public float multiplierAnimation;
    private int rand;
    private int rand1;
    private int rand2;
    private int randGold;
    private int listLenght;
    private Timer _timer;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        Plateforms = GameObject.FindGameObjectsWithTag("Plateform");
        if (_timer != null)
        {
            _timer.Cancel();
        }
    }

    public void RockSpawn(int nbRock,float delay)
    {
        Plateforms = GameObject.FindGameObjectsWithTag("Plateform");
        listLenght = Plateforms.Length;

        switch (nbRock)
        {
            case 0:
                
                rand = Random.Range(0, listLenght - 1);
                randGold = Random.Range(0, chanceGold);
                animator = Rock.GetComponent<Animator>();
                //animator.SetFloat("AnimationSpeed", multiplierAnimation);

                if (randGold == 0)
                {
                    GameObject newRockGold = Instantiate(RockGold, Plateforms[rand].transform);
                    _timer = Timer.Register(1.45f /*/ multiplierAnimation*/, () =>
                    {
                        Instantiate(Gold, Plateforms[rand].transform);
                        Debug.Log("Vitesse d'animation de RockFall " + multiplierAnimation);
                        Destroy(newRockGold);
                    });
                }
                else
                {
                    GameObject newRock = Instantiate(Rock, Plateforms[rand].transform);
                    _timer = Timer.Register(1.45f /*/ multiplierAnimation*/, () =>
                    {
                        Destroy(newRock);
                    });
                }
                break;

            case 1:

                rand = Random.Range(0, listLenght - 1);
                rand1 = Random.Range(0, listLenght - 1);
                randGold = Random.Range(0, chanceGold);
                animator = Rock.GetComponent<Animator>();
                //animator.SetFloat("AnimationSpeed", multiplierAnimation);

                while (rand == rand1)
                {
                    rand1 = Random.Range(0, listLenght - 1);
                }

                if (randGold == 0)
                {
                    GameObject newRockGold = Instantiate(RockGold, Plateforms[rand].transform);
                    _timer = Timer.Register(1.45f /*/ multiplierAnimation*/, () =>
                    {
                        Instantiate(Gold, Plateforms[rand].transform);
                        Debug.Log(multiplierAnimation);
                        Destroy(newRockGold);
                    });
                }
                else
                {
                    GameObject newRock = Instantiate(Rock, Plateforms[rand].transform);
                    _timer = Timer.Register(1.45f /*/ multiplierAnimation*/, () =>
                    {
                        Destroy(newRock);
                    });
                }

                _timer = Timer.Register(delay /*/ multiplierAnimation*/, () =>
                {
                    randGold = Random.Range(0, chanceGold);

                    if (randGold == 0)
                    {
                        GameObject newRockGold = Instantiate(RockGold, Plateforms[rand].transform);
                        _timer = Timer.Register(1.45f /*/ multiplierAnimation*/, () =>
                        {
                            Instantiate(Gold, Plateforms[rand1].transform);
                            Debug.Log("Vitesse d'animation de RockFall " + multiplierAnimation);
                            Destroy(newRockGold);
                        });
                    }
                    else
                    {
                        GameObject newRock = Instantiate(Rock, Plateforms[rand1].transform);
                        _timer = Timer.Register(1.45f / multiplierAnimation, () =>
                        {
                            Destroy(newRock);
                        });
                    }
                });
                break;

            case 2:
                rand = Random.Range(0, listLenght - 1);
                rand1 = Random.Range(0, listLenght - 1);
                rand2 = Random.Range(0, listLenght - 1);
                randGold = Random.Range(0, chanceGold);
                animator = Rock.GetComponent<Animator>();
                //animator.SetFloat("AnimationSpeed", multiplierAnimation);

                while (rand == rand1)
                {
                    rand1 = Random.Range(0, listLenght - 1);
                }

                while(rand2==rand | rand2 == rand1)
                {
                    rand2 = Random.Range(0, listLenght - 1);
                }

                if (randGold == 0)
                {
                    GameObject newRockGold = Instantiate(RockGold, Plateforms[rand].transform);
                    _timer = Timer.Register(1.45f /*/ multiplierAnimation*/, () =>
                    {
                        Instantiate(Gold, Plateforms[rand].transform);
                        Debug.Log("Vitesse d'animation de RockFall "+multiplierAnimation);
                        Destroy(newRockGold);
                    });
                }
                else
                {
                    GameObject newRock = Instantiate(Rock, Plateforms[rand].transform);
                    _timer = Timer.Register(1.45f /*/ multiplierAnimation*/, () =>
                    {
                        Destroy(newRock);
                    });
                }

                _timer = Timer.Register(delay /*/ multiplierAnimation*/, () =>
                {
                    randGold = Random.Range(0, chanceGold);

                    if (randGold == 0)
                    {
                        GameObject newRockGold = Instantiate(RockGold, Plateforms[rand].transform);
                        _timer = Timer.Register(1.45f /*/ multiplierAnimation*/, () =>
                        {
                            Instantiate(Gold, Plateforms[rand1].transform);
                            Debug.Log("Vitesse d'animation de RockFall " + multiplierAnimation);
                            Destroy(newRockGold);
                        });
                    }
                    else
                    {
                        GameObject newRock = Instantiate(Rock, Plateforms[rand1].transform);
                        _timer = Timer.Register(1.45f /*/ multiplierAnimation*/, () =>
                        {
                            Destroy(newRock);
                        });
                    }
                });

                _timer = Timer.Register(delay*2 /*/ multiplierAnimation*/, () =>
                {
                    randGold = Random.Range(0, chanceGold);

                    if (randGold == 0)
                    {
                        GameObject newRockGold = Instantiate(RockGold, Plateforms[rand].transform);
                        _timer = Timer.Register(1.45f /*/ multiplierAnimation*/, () =>
                        {
                            Instantiate(Gold, Plateforms[rand2].transform);
                            Debug.Log(multiplierAnimation);
                            Destroy(newRockGold);
                        });
                    }
                    else
                    {
                        GameObject newRock = Instantiate(Rock, Plateforms[rand2].transform);
                        _timer = Timer.Register(1.45f /*/ multiplierAnimation*/, () =>
                        {
                            Destroy(newRock);
                        });
                    }
                });
                break;
        }

        
    }

    /*public float GetClipDuration(string animName, Animator anim)
    {
        float time = 0f;
        AnimationClip clip = null;

        RuntimeAnimatorController ac = anim.runtimeAnimatorController;    //Get Animator controller
        for (int i = 0; i < ac.animationClips.Length; i++)                 //For all animations
        {
            if (ac.animationClips[i].name == animName)        //If it has the same name as your clip
            {
                time = ac.animationClips[i].length;
                clip = ac.animationClips[i];
            }
        }

        if (clip == null)
        {
            Debug.Log("Animation not found");
        }

        return time;
    }*/

}
