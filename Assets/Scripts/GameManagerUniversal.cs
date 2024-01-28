using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get; private set; }

    protected virtual void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);

        Instance = this as T;
    }

    protected virtual void OnApplicationQuit()
    {
        Instance = null;
        Destroy(gameObject);
    }

    public class GameManagerUniversal : Singleton<GameManagerUniversal>
    {
        public bool player1, player2, player3, player4;
        
        public int pontosP1, pontosP2, pontosP3, pontosP4;

        
    }
}
