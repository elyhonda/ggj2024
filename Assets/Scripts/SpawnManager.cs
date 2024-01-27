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

    bool stopSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        while(stopSpawning != true)
        {
            GameObject newBall = Instantiate(ballPrefab, transform.position, Quaternion.identity);
            newBall.transform.parent = ballContainer.transform;
            yield return new WaitForSeconds(ballSpawnTime);
        }
    }
}
