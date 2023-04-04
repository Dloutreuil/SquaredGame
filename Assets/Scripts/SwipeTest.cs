using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeTest : MonoBehaviour
{
    public Swipe swipeControls;
    public Transform player;
    public Vector3 desiredPosition;
    public float Speed;
    public Animator anim;
    private bool isMooving=false;

    private void Start()
    {
        //anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (swipeControls.SwipeLeft & isMooving==false)
        {
            isMooving = true;
            desiredPosition += Vector3.left * 2;
            transform.eulerAngles = new Vector3(0, 90, 0);
            anim.Play("Jump_nomo",-1,0f);
        }
        if (swipeControls.SwipeRight & isMooving == false)
        {
            isMooving = true;
            desiredPosition += Vector3.right * 2;
            transform.eulerAngles = new Vector3(0, 270, 0);
            anim.Play("Jump_nomo", -1, 0f);
        }
        if (swipeControls.SwipeUp & isMooving == false)
        {
            isMooving = true;
            desiredPosition += Vector3.forward*2;
            transform.eulerAngles = new Vector3(0, 180, 0);
            anim.Play("Jump_nomo", -1, 0f);
        }
        if (swipeControls.SwipeDown & isMooving == false)
        {
            isMooving = true;
            desiredPosition += Vector3.back*2;
            transform.eulerAngles = new Vector3(0, 0, 0);
            anim.Play("Jump_nomo", -1, 0f);
        }

        player.transform.position = Vector3.MoveTowards(player.transform.position, desiredPosition, Speed * Time.deltaTime);

        if (player.transform.position == desiredPosition)
        {
            isMooving = false;
        }
    }
}
