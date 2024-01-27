using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallKill : MonoBehaviour
{
    public float speed = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2( speed, transform.position.y);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object is the player
        if (other.tag == "Player")
        {
            // Call a function to kill the player
            //other.SetActive(false);
        }
    }
}
