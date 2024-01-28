using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    public int[] rankingi;

    public GameObject winUI;
    public RuntimeAnimatorController[] newController;
    public GameObject[] personagemRank;

    public AudioSource audioVitoria, audio;
    public AudioClip vitoria;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
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
        SceneManager.LoadScene("Main");
    }

    public void Win()
    {
        winUI.SetActive(true);
        audio.Stop();
        audioVitoria.PlayOneShot(vitoria, 1f);

        rankingi[0] = ranking[0];
        rankingi[1] = ranking[1];
        rankingi[2] = ranking[2];
        rankingi[3] = ranking[3];
        if(!isPlayer1Dead)
        {
            personagemRank[0].GetComponent<Animator>().runtimeAnimatorController = newController[0] as RuntimeAnimatorController;

            if (ranking[0] == 2)
            {
                personagemRank[3].GetComponent<Animator>().runtimeAnimatorController = newController[1] as RuntimeAnimatorController;
            }
            else if (ranking[1] == 2)
            {
                personagemRank[2].GetComponent<Animator>().runtimeAnimatorController = newController[1] as RuntimeAnimatorController;
            }
            else
            {
                personagemRank[1].GetComponent<Animator>().runtimeAnimatorController = newController[1] as RuntimeAnimatorController;
            }

            if (ranking[0] == 3)
            {
                personagemRank[3].GetComponent<Animator>().runtimeAnimatorController = newController[2] as RuntimeAnimatorController;
            }
            else if (ranking[1] == 3)
            {
                personagemRank[2].GetComponent<Animator>().runtimeAnimatorController = newController[2] as RuntimeAnimatorController;
            }
            else
            {
                personagemRank[1].GetComponent<Animator>().runtimeAnimatorController = newController[2] as RuntimeAnimatorController;
            }

            if (ranking[0] == 4)
            {
                personagemRank[3].GetComponent<Animator>().runtimeAnimatorController = newController[3] as RuntimeAnimatorController;
            }
            else if (ranking[1] == 4)
            {
                personagemRank[2].GetComponent<Animator>().runtimeAnimatorController = newController[3] as RuntimeAnimatorController;
            }
            else
            {
                personagemRank[1].GetComponent<Animator>().runtimeAnimatorController = newController[3] as RuntimeAnimatorController;
            }
        }
        else if(!isPlayer2Dead)
        {
            personagemRank[0].GetComponent<Animator>().runtimeAnimatorController = newController[1] as RuntimeAnimatorController;

            if (ranking[0] == 1)
            {
                personagemRank[3].GetComponent<Animator>().runtimeAnimatorController = newController[0] as RuntimeAnimatorController;
            }
            else if (ranking[1] == 1)
            {
                personagemRank[2].GetComponent<Animator>().runtimeAnimatorController = newController[0] as RuntimeAnimatorController;
            }
            else
            {
                personagemRank[1].GetComponent<Animator>().runtimeAnimatorController = newController[0] as RuntimeAnimatorController;
            }

            if (ranking[0] == 3)
            {
                personagemRank[3].GetComponent<Animator>().runtimeAnimatorController = newController[2] as RuntimeAnimatorController;
            }
            else if (ranking[1] == 3)
            {
                personagemRank[2].GetComponent<Animator>().runtimeAnimatorController = newController[2] as RuntimeAnimatorController;
            }
            else
            {
                personagemRank[1].GetComponent<Animator>().runtimeAnimatorController = newController[2] as RuntimeAnimatorController;
            }

            if (ranking[0] == 4)
            {
                personagemRank[3].GetComponent<Animator>().runtimeAnimatorController = newController[3] as RuntimeAnimatorController;
            }
            else if (ranking[1] == 4)
            {
                personagemRank[2].GetComponent<Animator>().runtimeAnimatorController = newController[3] as RuntimeAnimatorController;
            }
            else
            {
                personagemRank[1].GetComponent<Animator>().runtimeAnimatorController = newController[3] as RuntimeAnimatorController;
            }
        }
        else if(!isPlayer3Dead)
        {
            personagemRank[0].GetComponent<Animator>().runtimeAnimatorController = newController[2] as RuntimeAnimatorController;

            if (ranking[0] == 1)
            {
                personagemRank[3].GetComponent<Animator>().runtimeAnimatorController = newController[0] as RuntimeAnimatorController;
            }
            else if (ranking[1] == 1)
            {
                personagemRank[2].GetComponent<Animator>().runtimeAnimatorController = newController[0] as RuntimeAnimatorController;
            }
            else
            {
                personagemRank[1].GetComponent<Animator>().runtimeAnimatorController = newController[0] as RuntimeAnimatorController;
            }

            if (ranking[0] == 2)
            {
                personagemRank[3].GetComponent<Animator>().runtimeAnimatorController = newController[1] as RuntimeAnimatorController;
            }
            else if (ranking[1] == 2)
            {
                personagemRank[2].GetComponent<Animator>().runtimeAnimatorController = newController[1] as RuntimeAnimatorController;
            }
            else
            {
                personagemRank[1].GetComponent<Animator>().runtimeAnimatorController = newController[1] as RuntimeAnimatorController;
            }

            if (ranking[0] == 4)
            {
                personagemRank[3].GetComponent<Animator>().runtimeAnimatorController = newController[3] as RuntimeAnimatorController;
            }
            else if (ranking[1] == 4)
            {
                personagemRank[2].GetComponent<Animator>().runtimeAnimatorController = newController[3] as RuntimeAnimatorController;
            }
            else
            {
                personagemRank[1].GetComponent<Animator>().runtimeAnimatorController = newController[3] as RuntimeAnimatorController;
            }
        }
        else if(!isPlayer4Dead)
        {
            personagemRank[0].GetComponent<Animator>().runtimeAnimatorController = newController[3] as RuntimeAnimatorController;
            
            if(ranking[0] == 1)
            {
                personagemRank[3].GetComponent<Animator>().runtimeAnimatorController = newController[0] as RuntimeAnimatorController;
            }
            else if(ranking[1] == 1)
            {
                personagemRank[2].GetComponent<Animator>().runtimeAnimatorController = newController[0] as RuntimeAnimatorController;
            }
            else
            {
                personagemRank[1].GetComponent<Animator>().runtimeAnimatorController = newController[0] as RuntimeAnimatorController;
            }

            if (ranking[0] == 2)
            {
                personagemRank[3].GetComponent<Animator>().runtimeAnimatorController = newController[1] as RuntimeAnimatorController;
            }
            else if (ranking[1] == 2)
            {
                personagemRank[2].GetComponent<Animator>().runtimeAnimatorController = newController[1] as RuntimeAnimatorController;
            }
            else
            {
                personagemRank[1].GetComponent<Animator>().runtimeAnimatorController = newController[1] as RuntimeAnimatorController;
            }

            if (ranking[0] == 3)
            {
                personagemRank[3].GetComponent<Animator>().runtimeAnimatorController = newController[2] as RuntimeAnimatorController;
            }
            else if (ranking[1] == 3)
            {
                personagemRank[2].GetComponent<Animator>().runtimeAnimatorController = newController[2] as RuntimeAnimatorController;
            }
            else
            {
                personagemRank[1].GetComponent<Animator>().runtimeAnimatorController = newController[2] as RuntimeAnimatorController;
            }
        }
    }
}
