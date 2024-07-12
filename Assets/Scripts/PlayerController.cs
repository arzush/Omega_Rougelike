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
    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
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
        if (collision.gameObject.tag == "Poison")
        {
            HP -= 5;
            Destroy(collision.gameObject);
        }
            
        if (collision.gameObject.tag == "Hole")
        {
            HP -= 7;
            Destroy(collision.gameObject);
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
        if (other.gameObject.CompareTag("Money"))
        {
            counter++;
            Destroy(other.gameObject);
            Debug.Log($"Монет: {counter}");
            scoreText.text = "Money: " + counter;
        }
        if (other.gameObject.CompareTag("Chest"))
        {
            counter += 5;
            Destroy(other.gameObject);
            //Debug.Log($"Монет: {counter}");
            scoreText.text = "Money: " + counter;
        }
    }

}




//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerController : MonoBehaviour
//{
//    Animator animator;
//    Rigidbody2D rb;
//    SpriteRenderer sprite;

//    [SerializeField]
//    int speed;

//    private void Start()
//    {
//        animator = GetComponent<Animator>();
//        rb = GetComponent<Rigidbody2D>();
//        sprite = GetComponent<SpriteRenderer>();
//    }



//    private void FixedUpdate()
//    {
//        if (Input.GetKey(KeyCode.D))
//        {
//            rb.velocity = new Vector2(speed, rb.velocity.y);
//            animator.Play("skrepka_run_bpk");
//            sprite.flipX = false;
//        }
//        else if (Input.GetKey(KeyCode.A))
//        {
//            rb.velocity = new Vector2(-speed, rb.velocity.y);
//            animator.Play("skrepka_run_bpk");
//            sprite.flipX = true;
//        }
//        else
//        {
//            rb.velocity = new Vector2(0, 0);
//            animator.Play("New Animation");
//        }

//        if (Input.GetKey(KeyCode.W))
//        {
//            rb.velocity = new Vector2(rb.velocity.x, speed);
//            animator.Play("skrepka_run_back");

//        }
//        else if (Input.GetKey(KeyCode.S))
//        {
//            rb.velocity = new Vector2(rb.velocity.x, -speed);
//            animator.Play("skrepka_run");
//        }



//    }



//}


//private Rigidbody2D rb;
//public float speed = 0.9f;
//private Vector2 moveVector;

//void Awake()
//{
//    rb = GetComponent<Rigidbody2D>();
//}

//void Update()
//{
//    moveVector.x = Input.GetAxis("Horizontal");
//    moveVector.y = Input.GetAxis("Vertical");
//    rb.MovePosition(rb.position + moveVector * speed * Time.deltaTime);
//}