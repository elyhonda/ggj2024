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
    
    float ballSpawnTime = 10f;
    float gameStartTime = 5f;
    float canSpeedUp = 2f;
    float speedUpRate = 10f;

    bool stopSpawning = false;
    private BallKill ballScript;

    public AudioSource audio;
    public AudioClip canhao;

    public Animator animator;
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
        yield return new WaitForSeconds(gameStartTime);
        while (stopSpawning != true)
        {
            if (audio != null)
            {
                audio.PlayOneShot(canhao);
            }
            animator.SetTrigger("canhao");
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
