using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinFall : MonoBehaviour
{
    public GameObject coin;
    public GameObject[] Plateforms;
    private int rand;
    private Transform target;
    
    
    public void coinSpawn()
    {
        Plateforms = GameObject.FindGameObjectsWithTag("Plateform");
        rand = Random.Range(0, 8);
        target.position = new Vector3(Plateforms[rand].transform.position.x, Plateforms[rand].transform.position.y + 5, Plateforms[rand].transform.position.z);

        Instantiate(coin, target);
    }
}
