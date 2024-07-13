using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject leftHand;
    public GameObject rightHand;
    public GameObject[] newPrefabs; // Массив префабов, которые нужно заспавнить
    public Transform[] spawnPoints; // Массив точек спавна
    public int maxSpawnCount = 5; // Максимальное количество спавненных объектов
    public GameObject deathParticlePrefab; // Префаб Particle System для уничтожения босса
    public float particleDuration = 3.0f; // Длительность работы Particle System

    private bool isLeftHandDestroyed = false;
    private bool isRightHandDestroyed = false;
    private int currentSpawnCount = 0; // Текущее количество заспавненных объектов
    private List<GameObject> spawnedObjects = new List<GameObject>(); // Список заспавненных объектов

    void Update()
    {
        CheckHandsStatus();
        CheckSpawnedObjectsStatus();
    }

    private void CheckHandsStatus()
    {
        if (leftHand == null && !isLeftHandDestroyed)
        {
            isLeftHandDestroyed = true;
        }

        if (rightHand == null && !isRightHandDestroyed)
        {
            isRightHandDestroyed = true;
        }

        if (isLeftHandDestroyed && isRightHandDestroyed && currentSpawnCount < maxSpawnCount)
        {
            SpawnNewPrefabs();
        }
    }

    private void SpawnNewPrefabs()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            if (currentSpawnCount >= maxSpawnCount)
                break;

            foreach (GameObject prefab in newPrefabs)
            {
                if (currentSpawnCount >= maxSpawnCount)
                    break;

                GameObject spawnedObject = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
                spawnedObjects.Add(spawnedObject);
                currentSpawnCount++;
            }
        }
    }

    private void CheckSpawnedObjectsStatus()
    {
        // Удаляем все null объекты из списка
        spawnedObjects.RemoveAll(item => item == null);

        // Если все заспавненные объекты уничтожены
        if (spawnedObjects.Count == 0 && isLeftHandDestroyed && isRightHandDestroyed)
        {
            DestroyBoss();
        }
    }

    private void DestroyBoss()
    {
        // Уничтожаем босса
        Destroy(gameObject);

        // Запускаем Particle System
        GameObject particleInstance = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);

        // Уничтожаем Particle System после окончания работы
        Destroy(particleInstance, particleDuration);
    }
}
