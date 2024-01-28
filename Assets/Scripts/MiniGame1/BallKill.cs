using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallKill : MonoBehaviour
{
    public float speed = 0.8f;
    [SerializeField]
    float speedMultiplier = 1.05f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    public void SpeedUp()
    {
        speed += 0.075f;
    }
    public void SpeedDown()
    {
        speed = 0.8f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collided object is the player
        if (other.tag == "Player")
        {
            Movement movement = other.transform.GetComponent<Movement>();

            if(movement != null)
            {
                movement.Death();
            }
        }

        if (other.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }
}
