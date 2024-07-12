using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;

    // Update is called once per frame
    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                Courtier_enemy courtierEnemy = hitInfo.collider.GetComponent<Courtier_enemy>();
                if (courtierEnemy != null)
                {
                    courtierEnemy.TakeDamage(damage);
                }

                Strazha strazha = hitInfo.collider.GetComponent<Strazha>();
                if (strazha != null)
                {
                    strazha.TakeDamage(damage);
                }

                FollowingEnemy followingenemy = hitInfo.collider.GetComponent<FollowingEnemy>();
                if (followingenemy != null)
                {
                    followingenemy.TakeDamage(damage);
                }
            }

            Destroy(gameObject);
        }
        transform.Translate(Vector2.right * speed * Time.deltaTime);

    }
}
