using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public bool isPlayer1Dead = false;
    public bool isPlayer2Dead = false;
    public bool isPlayer3Dead = false;
    public bool isPlayer4Dead = false;

    public float deadCount = 0;

    private Movement movement;

    private SpawnManager spawnManager;
    private SpawnManager spawnManager2;
    private SpawnManager spawnManager3;
    private SpawnManager spawnManager4;

    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("Spawner").GetComponent<SpawnManager>();
        spawnManager2 = GameObject.Find("Spawner_2").GetComponent<SpawnManager>();
        spawnManager3 = GameObject.Find("Spawner_3").GetComponent<SpawnManager>();
        spawnManager4 = GameObject.Find("Spawner_4").GetComponent<SpawnManager>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayerDead()
    {
        deadCount++;

        if(deadCount == 3)
        {
            spawnManager.StopSpawning();
            spawnManager2.StopSpawning();
            spawnManager3.StopSpawning();
            spawnManager4.StopSpawning();
        }
    }

}
