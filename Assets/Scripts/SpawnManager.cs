using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject ballContainer;
    public GameObject ballPrefab;
    
    float ballSpawnTime = 5f;
    float canSpeedUp = -1f;
    float speedUpRate = 10f;

    bool stopSpawning = false;
    private BallKill ballScript;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
        ballScript = ballPrefab.GetComponent<BallKill>();
        ballScript.SpeedDown();
    }

    private void Update()
    {
        if(Time.time > canSpeedUp)
        {
            SpeedUp();
        }
    }

    private IEnumerator Spawner()
    {
        while(stopSpawning != true)
        {
            yield return new WaitForSeconds(ballSpawnTime);
            GameObject newBall = Instantiate(ballPrefab, transform.position, Quaternion.identity);
            newBall.transform.parent = ballContainer.transform;
            yield return new WaitForSeconds(ballSpawnTime);
        }
    }

    public void StopSpawning()
    {
        stopSpawning = true;
        ballScript.SpeedDown();
    }
    
    void SpeedUp()
    {
        canSpeedUp = Time.time + speedUpRate;

        ballScript.SpeedUp();
    }
}
