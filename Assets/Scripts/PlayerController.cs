using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;
    SpriteRenderer sprite;

    [SerializeField]
    int speed;
    public float HP;

    public TMPro.TextMeshProUGUI scoreText;



    private int counter = 0;

    private float initialHP;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        initialHP = HP;
  
    }
   

    private void Update()
    {

        if (HP <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            HP = initialHP;
        }
    }

    private void FixedUpdate()
    {
        Vector2 newVelocity = rb.velocity;

        // Handle horizontal movement
        if (Input.GetKey(KeyCode.D))
        {
            newVelocity.x = speed;
            sprite.flipX = false;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            newVelocity.x = -speed;
            sprite.flipX = true;
        }
        else
        {
            newVelocity.x = 0;
        }

        // Handle vertical movement
        if (Input.GetKey(KeyCode.W))
        {
            newVelocity.y = speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            newVelocity.y = -speed;
        }
        else
        {
            newVelocity.y = 0;
        }

        rb.velocity = newVelocity;

        // Handle animations
        if (newVelocity.x != 0)
        {
            animator.Play("skrepka_run_bpk");
        }
        else if (newVelocity.y > 0)
        {
            animator.Play("skrepka_run_back");
        }
        else if (newVelocity.y < 0)
        {
            animator.Play("skrepka_run");
        }
        else
        {
            animator.Play("New Animation");
        }


    }
    //здесь не включаем IsTrigger
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            HP -= 10;
        if (collision.gameObject.tag == "Enemy_patron")
        {
            HP -= 7;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Poison")
        {
            HP -= 6;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Hole")
        {
            HP -= 5;
            //Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Thoms")
        {
            HP -= 8;
            //Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Health")
        {
            HP += 10;
            Destroy(collision.gameObject);
        }
    }

    //здесь включаем IsTrigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        int level = SceneManager.GetActiveScene().buildIndex;

        if (other.gameObject.CompareTag("Money"))
        {
            counter++;
            Destroy(other.gameObject);
            scoreText.text = "Respect: " + counter;
        }
        else if (other.gameObject.CompareTag("Chest"))
        {
            counter += 5;
            Destroy(other.gameObject);
            scoreText.text = "Respect: " + counter;
        }

        switch (level)
        {
            case 2:
                int savedCounter1 = PlayerPrefs.GetInt("Level1", 0);
                if (counter > savedCounter1)
                {
                    PlayerPrefs.SetInt("Level1", counter);
                }
                break;
            case 3:
                int savedCounter2 = PlayerPrefs.GetInt("Level2", 0);
                if (counter > savedCounter2)
                {
                    PlayerPrefs.SetInt("Level2", counter);
                }
                break;
            case 4:
                int savedCounter3 = PlayerPrefs.GetInt("Level3", 0);
                if (counter > savedCounter3)
                {
                    PlayerPrefs.SetInt("Level3", counter);
                }
                break;
            // добавьте больше уровней, если нужно
            default:
                Debug.LogWarning("Неизвестный уровень: " + level);
                break;
        }
    }

}