using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Courtier_enemy : MonoBehaviour
{
    public int health;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    // Method to take damage
    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
