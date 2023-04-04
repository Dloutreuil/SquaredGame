using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public float _rockDelay;
    private float difficultyOverTime=1f;
    private int secondPhase2=120;
    private int _nbPlat = 0;
    private int _nbRock = 0;
    private RockFall rockFallScript;
    private PlatformFall platformFallScript;
    private LightningFall lightningFallScript;
    private CoinFall coinFallScript;
    bool isSpwawningRock = false;
    bool isSpwawningPlatform = false;
    bool isSpawningLightning = false;
    bool isSpawningCoin = true;

    private void Awake()
    {
        rockFallScript = GetComponent<RockFall>();
        platformFallScript =GetComponent<PlatformFall>();
        lightningFallScript = GetComponent<LightningFall>();
        coinFallScript = GetComponent<CoinFall>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isSpwawningPlatform)
        {
            StartCoroutine(_platformfall());
        }
        if (!isSpwawningRock)
        {
            StartCoroutine(_rockfall());
        }
        if (!isSpawningLightning)
        {
            StartCoroutine(_lightningfall());
        }
        if (!isSpawningCoin)
        {
            StartCoroutine(_coinfall());
        }

        //Debug.Log(Time.timeSinceLevelLoad);

        if (Time.timeSinceLevelLoad <= 30)
        {
            rockFallScript.multiplierAnimation = 0.25f;
            platformFallScript.multiplierAnimation = 0.75f;
            lightningFallScript.multiplierAnimation = 0.75f;
            difficultyOverTime = 0.5f;
            
            //Debug.Log(difficultyOverTime);
        }
        else if(Time.timeSinceLevelLoad <= 60)
        {
            rockFallScript.multiplierAnimation = 0.5f;
            platformFallScript.multiplierAnimation = 1f;
            lightningFallScript.multiplierAnimation = 1f;
            difficultyOverTime = 1f;
            _nbRock = 1;
        }
        else if (Time.timeSinceLevelLoad <= 120)
        {
            rockFallScript.multiplierAnimation = 1f;
            platformFallScript.multiplierAnimation = 1.25f;
            lightningFallScript.multiplierAnimation = 1.25f;
            difficultyOverTime += 0f;
            _nbPlat = 1;
        }
        else
        {
            if (Time.timeSinceLevelLoad <= secondPhase2)
            {
                rockFallScript.multiplierAnimation +=0.25f;
                platformFallScript.multiplierAnimation += 0.25f;
                lightningFallScript.multiplierAnimation += 0.25f;
                difficultyOverTime += 0.25f;
                secondPhase2 += 60;
            }
        }

        Debug.Log(_nbPlat);

    }

    IEnumerator _platformfall()
    {
        isSpwawningPlatform = true;
        yield return new WaitForSeconds(7 / difficultyOverTime);
        platformFallScript.platformFall(_nbPlat);
        isSpwawningPlatform = false;
    }

    IEnumerator _rockfall()
    {
        isSpwawningRock = true;
        yield return new WaitForSeconds((3+_rockDelay*_nbRock) / difficultyOverTime);
        rockFallScript.RockSpawn(_nbRock,_rockDelay);
        isSpwawningRock = false;
    }

    IEnumerator _lightningfall()
    {
        isSpawningLightning = true;
        yield return new WaitForSeconds(20 / difficultyOverTime);
        lightningFallScript.LightningSpawn();
        isSpawningLightning = false;
    }

    IEnumerator _coinfall()
    {
        isSpawningCoin = true;
        yield return new WaitForSeconds(1);
        coinFallScript.coinSpawn();
        isSpawningCoin = false;
    }
}