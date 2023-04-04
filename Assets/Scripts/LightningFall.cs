using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTimer;

public class LightningFall : MonoBehaviour
{
    public float multiplierAnimation;
    //public GameObject[] Platforms;
    public List<GameObject> Platforms;
    public List<GameObject> TargetPlatforms;
    private int rand;
    private GameObject Plat1;
    private GameObject Plat2;
    private GameObject Plat3;
    private Timer _timer;
    Animator animator1;
    Animator animator2;
    Animator animator3;

    void Start()
    {
        if (_timer != null)
        {
            _timer.Cancel();
        }

        
    }

    public void LightningSpawn()
    {
        rand = Random.Range(0, 5);
        //Platforms = GameObject.FindGameObjectsWithTag("Plateform");

        switch (rand)
        {
            case 0:
                TargetPlatforms.Add(Platforms[2]);
                TargetPlatforms.Add(Platforms[0]);
                TargetPlatforms.Add(Platforms[1]);
                break;
            case 1:
                TargetPlatforms.Add(Platforms[5]);
                TargetPlatforms.Add(Platforms[3]);
                TargetPlatforms.Add(Platforms[4]);
                break;
            case 2:
                TargetPlatforms.Add(Platforms[8]);
                TargetPlatforms.Add(Platforms[6]);
                TargetPlatforms.Add(Platforms[7]);
                break;
            case 3:
                TargetPlatforms.Add(Platforms[8]);
                TargetPlatforms.Add(Platforms[2]);
                TargetPlatforms.Add(Platforms[5]);
                break;
            case 4:
                TargetPlatforms.Add(Platforms[6]);
                TargetPlatforms.Add(Platforms[0]);
                TargetPlatforms.Add(Platforms[3]);
                break;
            case 5:
                TargetPlatforms.Add(Platforms[7]);
                TargetPlatforms.Add(Platforms[1]);
                TargetPlatforms.Add(Platforms[4]);
                break;
        }

        animator1 = TargetPlatforms[0].GetComponent<Animator>();
        animator2 = TargetPlatforms[1].GetComponent<Animator>();
        animator3 = TargetPlatforms[2].GetComponent<Animator>();

        /*while (animator1.GetBool("isFalling")| animator2.GetBool("isFalling") | animator3.GetBool("isFalling"))
        {
            rand = Random.Range(0, 5);

            switch (rand)
            {
                case 0:
                    TargetPlatforms.Add(Platforms[2]);
                    TargetPlatforms.Add(Platforms[0]);
                    TargetPlatforms.Add(Platforms[1]);
                    break;
                case 1:
                    TargetPlatforms.Add(Platforms[5]);
                    TargetPlatforms.Add(Platforms[3]);
                    TargetPlatforms.Add(Platforms[4]);
                    break;
                case 2:
                    TargetPlatforms.Add(Platforms[8]);
                    TargetPlatforms.Add(Platforms[6]);
                    TargetPlatforms.Add(Platforms[7]);
                    break;
                case 3:
                    TargetPlatforms.Add(Platforms[8]);
                    TargetPlatforms.Add(Platforms[2]);
                    TargetPlatforms.Add(Platforms[5]);
                    break;
                case 4:
                    TargetPlatforms.Add(Platforms[6]);
                    TargetPlatforms.Add(Platforms[0]);
                    TargetPlatforms.Add(Platforms[3]);
                    break;
                case 5:
                    TargetPlatforms.Add(Platforms[7]);
                    TargetPlatforms.Add(Platforms[1]);
                    TargetPlatforms.Add(Platforms[4]);
                    break;
            }

            animator1 = TargetPlatforms[0].GetComponent<Animator>();
            animator2 = TargetPlatforms[1].GetComponent<Animator>();
            animator3 = TargetPlatforms[2].GetComponent<Animator>();
        }*/

        if(TargetPlatforms[0]==Platforms[2]| TargetPlatforms[0] == Platforms[5]|TargetPlatforms[1] == Platforms[6])
        {
            animator1.SetBool("IsLightning2", true);
        }
        else animator1.SetBool("IsLightning1", true);

        animator1.SetFloat("AnimationSpeed", multiplierAnimation);
        animator2.SetFloat("AnimationSpeed", multiplierAnimation);
        animator3.SetFloat("AnimationSpeed", multiplierAnimation);

        Plat1 = TargetPlatforms[0].transform.GetChild(1).gameObject;
        Plat2 = TargetPlatforms[1].transform.GetChild(1).gameObject;
        Plat3 = TargetPlatforms[2].transform.GetChild(1).gameObject;

        Plat1.SetActive(true);
        Plat2.SetActive(true);
        Plat3.SetActive(true);

        animator1.SetBool("IsFalling", true);
        animator1.SetBool("IsRising", false);

        _timer = Timer.Register(2.5f / multiplierAnimation, () => {

            Plat1.SetActive(false);
            TargetPlatforms[0].SetActive(false);

            _timer = Timer.Register(3f / multiplierAnimation, () =>
            {
                TargetPlatforms[0].SetActive(true);
                animator1.SetBool("IsLightning1", false);
                animator1.SetBool("IsLightning2", false);
                animator1.SetBool("FirstTimeFall", true);
                animator1.SetBool("IsRising", true);
                animator1.SetBool("IsFalling", false);
            });

        }
        );

        _timer = Timer.Register(1f / multiplierAnimation, () =>
        {

            animator2.SetBool("IsFalling", true);
            animator2.SetBool("IsRising", false);

            _timer = Timer.Register(2.5f / multiplierAnimation, () =>
            {

                Plat2.SetActive(false);
                TargetPlatforms[1].SetActive(false);

                _timer = Timer.Register(3f / multiplierAnimation, () =>
                  {
                      TargetPlatforms[1].SetActive(true);
                      animator2.SetBool("FirstTimeFall", true);
                      animator2.SetBool("IsRising", true);
                      animator2.SetBool("IsFalling", false);
                });
            });
        });

        _timer = Timer.Register(2f / multiplierAnimation, () =>
        {
            animator3.SetBool("IsFalling", true);
            animator3.SetBool("IsRising", false);

            _timer = Timer.Register(2.5f / multiplierAnimation, () =>
            {
                Plat3.SetActive(false);
                TargetPlatforms[2].SetActive(false);

                _timer = Timer.Register(3f / multiplierAnimation, () =>
                {
                    TargetPlatforms[2].SetActive(true);
                    animator3.SetBool("FirstTimeFall", true);
                    animator3.SetBool("IsRising", true);
                    animator3.SetBool("IsFalling", false);

                    Plat1 = TargetPlatforms[0].transform.GetChild(2).gameObject;
                    Plat1.SetActive(false);
                });
            });
        });

        _timer = Timer.Register(15f / multiplierAnimation, () =>
        {
            TargetPlatforms.Clear();
        });
        
    }

}
