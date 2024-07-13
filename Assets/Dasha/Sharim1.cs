using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sharim1 : MonoBehaviour
{
    public float speed;
    public int health = 4;
    private float waitTime;
    public float StartWaitTime;
    public Transform[] moveSpots;
    private int randomSpots;
    // Start is called before the first frame update
    void Start()
    {
        waitTime = StartWaitTime;
        randomSpots = Random.Range(0, moveSpots.Length);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpots].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[randomSpots].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpots = Random.Range(0, moveSpots.Length);
                waitTime = StartWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

}
