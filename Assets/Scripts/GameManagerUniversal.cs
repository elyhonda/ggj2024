using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManagerUniversal : MonoBehaviour
{
    private static GameManagerUniversal instance;

    public int pointsP1, pointsP2, pointsP3, pointsP4;
    // Public property to access the singleton instance
    public static GameManagerUniversal Instance
    {
        get
        {
            // If the instance hasn't been set yet, find it in the scene
            if (instance == null)
            {
                instance = FindObjectOfType<GameManagerUniversal>();

                // If it's still null, create a new instance
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(GameManagerUniversal).Name);
                    instance = singletonObject.AddComponent<GameManagerUniversal>();
                }
            }
            return instance;
        }
    }

    // Optional: Other methods and variables can be added here

    private void Awake()
    {
        // Ensure there's only one instance
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            // Optional: Ensure the singleton persists between scenes
            DontDestroyOnLoad(gameObject);
        }
    }

    public void AddPoints(int rank1, int rank2, int rank3, int rank4)
    {
        switch(rank1)
        {
            case 1:  
            pointsP1 += 4;
            break;
            case 2:  
            pointsP2 += 4;
            break;
            case 3:  
            pointsP3 += 4;
            break;
            case 4:  
            pointsP4 += 4;
            break;
        }

        switch(rank2)
        {
            case 1:  
            pointsP1 += 3;
            break;
            case 2:  
            pointsP2 += 3;
            break;
            case 3:  
            pointsP3 += 3;
            break;
            case 4:  
            pointsP4 += 3;
            break;
        }

        switch(rank3)
        {
            case 1:  
            pointsP1 += 2;
            break;
            case 2:  
            pointsP2 += 2;
            break;
            case 3:  
            pointsP3 += 2;
            break;
            case 4:  
            pointsP4 += 2;
            break;
        }

        switch(rank4)
        {
            case 1:  
            pointsP1 += 1;
            break;
            case 2:  
            pointsP2 += 1;
            break;
            case 3:  
            pointsP3 += 1;
            break;
            case 4:  
            pointsP4 += 1;
            break;
        }
    }
}
