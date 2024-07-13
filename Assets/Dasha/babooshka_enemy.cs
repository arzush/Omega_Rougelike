using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class babooshka_enemy : MonoBehaviour
{

    public int health = 4;

    private Material matBlink;
    private Material matDefault;
    private SpriteRenderer spriteRend;

    // Start is called before the first frame update
    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();

        matBlink = Resources.Load("EnemyBlink", typeof(Material)) as Material;

        matDefault = spriteRend.material;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            health--;

            spriteRend.material = matBlink;

            if (health <= 0)
            {
                //Kill
                KillEnemy();
            }
            else
            {
                Invoke("ResetMaterial", .2f);
            }
        }
    }


    void ResetMaterial()
    {
        spriteRend.material = matDefault;
    }


    void KillEnemy()
    {
        Destroy(gameObject);
    }


}
