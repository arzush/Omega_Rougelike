//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class EnemySpawnerRandom : MonoBehaviour
//{
//    [SerializeField] private float spawnerRate = 1f;

//    [SerializeField] private GameObject[] enemyPrefab;

//    [SerializeField] private bool canSpawn = true;

//    private void Start()
//    {
//        StartCoroutine(Spawner());
//    }

//    private IEnumerator Spawner()
//    {
//        WaitForSeconds wait = new WaitForSeconds(spawnerRate);
//        while (true)
//        {
//            yield return wait;
//            int rand = Random.Range(0, enemyPrefab.Length);
//            GameObject enemyToSpawn = enemyPrefab[rand];
//            Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
//        }
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerRandom : MonoBehaviour
{
    [SerializeField] private float spawnerRate = 3f;
    /*¬еличина задержки равна значению spawnerRate. “о есть,
     * если spawnerRate равно 1, новый враг будет создаватьс€
     * каждую секунду. ≈сли spawnerRate равно 2, новый враг 
     * будет создаватьс€ каждые 2 секунды, и так далее*/

    [SerializeField] private GameObject[] enemyPrefab;

    [SerializeField] private bool canSpawn = true;

    [SerializeField] private int minEnemies = 1;            // ћинимальное количество врагов

    [SerializeField] private int maxEnemies = 10;           // ћаксимальное количество врагов

    private int totalEnemiesToSpawn;                        // ќбщее количество врагов, которые нужно создать
    private int currentEnemies = 0;                         // “екущее количество врагов

    private void Start()
    {
        if (canSpawn)
        {
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


