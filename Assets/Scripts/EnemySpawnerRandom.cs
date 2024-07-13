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
    /*�������� �������� ����� �������� spawnerRate. �� ����,
     * ���� spawnerRate ����� 1, ����� ���� ����� �����������
     * ������ �������. ���� spawnerRate ����� 2, ����� ���� 
     * ����� ����������� ������ 2 �������, � ��� �����*/

    [SerializeField] private GameObject[] enemyPrefab;

    [SerializeField] private bool canSpawn = true;

    [SerializeField] private int minEnemies = 1;            // ����������� ���������� ������

    [SerializeField] private int maxEnemies = 10;           // ������������ ���������� ������

    private int totalEnemiesToSpawn;                        // ����� ���������� ������, ������� ����� �������
    private int currentEnemies = 0;                         // ������� ���������� ������

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


