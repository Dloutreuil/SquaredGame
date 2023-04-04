using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDeathZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Coin")
        {
            Destroy(collision.gameObject);
        }
    }
}
