using System.Collections;
using UnityEngine;

public class EnemySpawnerRandom : MonoBehaviour
{
    [SerializeField] private float spawnerRate = 1f;
    /*¬еличина задержки равна значению spawnerRate. “о есть,
//     * если spawnerRate равно 1, новый враг будет создаватьс€
//     * каждую секунду. ≈сли spawnerRate равно 2, новый враг 
//     * будет создаватьс€ каждые 2 секунды, и так далее*/
    [SerializeField] private GameObject[] enemyPrefab;
    [SerializeField] private int minEnemies = 1;
    [SerializeField] private int maxEnemies = 10;

    private int totalEnemiesToSpawn;
    private int currentEnemies = 0;
    private bool canSpawn = false;

    public void StartSpawning()
    {
        if (!canSpawn)
        {
            canSpawn = true;
            totalEnemiesToSpawn = Random.Range(minEnemies, maxEnemies + 1);
            StartCoroutine(Spawner());
        }
    }

    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnerRate);
        while (currentEnemies < totalEnemiesToSpawn)
        {
            yield return wait;
            int rand = Random.Range(0, enemyPrefab.Length);
            GameObject enemyToSpawn = enemyPrefab[rand];
            Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
            currentEnemies++;
        }
    }
}
