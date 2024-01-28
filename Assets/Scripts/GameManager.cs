using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private GameManagerUniversal gameManagerUniversal;

    public static List<int> ranking = new List<int>();

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
        if(Input.GetKeyDown("r"))
        {
            Reset();
        }
    }

    public void PlayerDead()
    {
        deadCount++;
        
        if(isPlayer1Dead)
        {
            ranking.Add(1);
        }
        else if(isPlayer2Dead)
        {
            ranking.Add(2);
        }
        else if(isPlayer3Dead)
        {
            ranking.Add(3);
        }
        else if(isPlayer4Dead)
        {
            ranking.Add(4);
        }

        if(deadCount == 3)
        {
            Time.timeScale = 0;
            spawnManager.StopSpawning();
            spawnManager2.StopSpawning();
            spawnManager3.StopSpawning();
            spawnManager4.StopSpawning();
            Win();
        }
    }
    
    public void Reset()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Win()
    {
        if(!isPlayer1Dead)
        {
            
        }
        else if(!isPlayer2Dead)
        {

        }
        else if(!isPlayer3Dead)
        {

        }
        else if(!isPlayer4Dead)
        {

        }
    }
}
