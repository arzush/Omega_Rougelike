using UnityEngine;

public class EnemySpawnTrigger : MonoBehaviour
{
    [SerializeField] private EnemySpawnerRandom enemySpawner;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger");
            enemySpawner.StartSpawning();
            Destroy(gameObject); 
        }
    }
}