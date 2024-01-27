using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public bool isPlayer1Dead = false;
    public bool isPlayer2Dead = false;
    public bool isPlayer3Dead = false;
    public bool isPlayer4Dead = false;

    public float deadCount = 0;

    private Movement movement;

    // Start is called before the first frame update
    void Start()
    {
        
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
            //colocar os sprites de final de jogo aqui
        }
    }

}
