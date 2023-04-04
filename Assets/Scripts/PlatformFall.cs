using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTimer;

public class PlatformFall : MonoBehaviour
{
    public float seccondsDelay;
    public float multiplierAnimation;
    private GameObject[] Plateforms;
    private int Rand;
    private int Rand1;
    private int lenghtList;
    private Timer _timer;
    Animator animator;
    Animator animator1;


    // Start is called before the first frame update
    public void platformFall(int nbPlat)
    {
        if(_timer != null)
        {
            _timer.Cancel();
        }


        Plateforms = GameObject.FindGameObjectsWithTag("Plateform");
        lenghtList = Plateforms.Length;

        Debug.Log("Nombre de platform " + nbPlat);

        switch (nbPlat)
        {
            case 0:
                Rand = Random.Range(0, lenghtList - 1);
                animator = Plateforms[Rand].GetComponent<Animator>();

                while (animator.GetBool("IsFalling"))
                {
                    Rand = Random.Range(0, lenghtList - 1);
                    animator = Plateforms[Rand].GetComponent<Animator>();
                }
                
                animator.SetFloat("AnimationSpeed", multiplierAnimation);

                //Debug.Log(GetClipDuration("IsFalling"));

                animator.SetBool("IsFalling", true);
                animator.SetBool("IsRising", false);

                _timer = Timer.Register(2.5f / multiplierAnimation, () => {

                    Plateforms[Rand].SetActive(false);

                    _timer = Timer.Register(seccondsDelay / multiplierAnimation, () =>
                    {
                        Plateforms[Rand].SetActive(true);
                        animator.SetBool("FirstTimeFall", true);
                        animator.SetBool("IsRising", true);
                        animator.SetBool("IsFalling", false);
                    });

                    //Debug.Log("timerCompleted");
                    //Debug.Log(GetClipDuration("PlatFall",animator));
                }
                );
                break;

            case 1:
                Rand = Random.Range(0, lenghtList - 1);
                Rand1 = Random.Range(0, lenghtList - 1);
                animator = Plateforms[Rand].GetComponent<Animator>();

                while (animator.GetBool("IsFalling"))
                {
                    Rand = Random.Range(0, lenghtList - 1);
                    animator = Plateforms[Rand].GetComponent<Animator>();
                }

                while (Rand == Rand1)
                {
                    Rand1 = Random.Range(0, lenghtList - 1);
                }

                animator1 = Plateforms[Rand1].GetComponent<Animator>();

                while (animator1.GetBool("IsFalling"))
                {
                    Rand1 = Random.Range(0, lenghtList - 1);
                    animator1 = Plateforms[Rand].GetComponent<Animator>();
                }

                animator.SetFloat("AnimationSpeed", multiplierAnimation);
                animator1.SetFloat("AnimationSpeed", multiplierAnimation);


                //Debug.Log(GetClipDuration("IsFalling"));

                animator.SetBool("IsFalling", true);
                animator.SetBool("IsRising", false);

                animator1.SetBool("IsFalling", true);
                animator1.SetBool("IsRising", false);

                _timer = Timer.Register(2.5f / multiplierAnimation, () => {

                    Plateforms[Rand].SetActive(false);
                    Plateforms[Rand1].SetActive(false);

                    _timer = Timer.Register(seccondsDelay / multiplierAnimation, () =>
                    {
                        Plateforms[Rand].SetActive(true);
                        Plateforms[Rand1].SetActive(true);
                        animator.SetBool("FirstTimeFall", true);
                        animator1.SetBool("FirstTimeFall", true);
                        animator.SetBool("IsRising", true);
                        animator1.SetBool("IsRising", true);
                        animator.SetBool("IsFalling", false);
                        animator1.SetBool("IsFalling", false);
                    });

                    //Debug.Log("timerCompleted");
                    //Debug.Log(GetClipDuration("PlatFall",animator));
                }
                );
                break;

        }

    }

    public float GetClipDuration(string animName,Animator anim)
    {
        float time=0f;
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
    }

}
