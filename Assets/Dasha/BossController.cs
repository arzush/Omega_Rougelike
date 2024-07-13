using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject leftHand;
    public GameObject rightHand;
    public GameObject[] newPrefabs; // ������ ��������, ������� ����� ����������
    public Transform[] spawnPoints; // ������ ����� ������
    public int maxSpawnCount = 5; // ������������ ���������� ���������� ��������
    public GameObject deathParticlePrefab; // ������ Particle System ��� ����������� �����
    public float particleDuration = 3.0f; // ������������ ������ Particle System

    private bool isLeftHandDestroyed = false;
    private bool isRightHandDestroyed = false;
    private int currentSpawnCount = 0; // ������� ���������� ������������ ��������
    private List<GameObject> spawnedObjects = new List<GameObject>(); // ������ ������������ ��������

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
        // ������� ��� null ������� �� ������
        spawnedObjects.RemoveAll(item => item == null);

        // ���� ��� ������������ ������� ����������
        if (spawnedObjects.Count == 0 && isLeftHandDestroyed && isRightHandDestroyed)
        {
            DestroyBoss();
        }
    }

    private void DestroyBoss()
    {
        // ���������� �����
        Destroy(gameObject);

        // ��������� Particle System
        GameObject particleInstance = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);

        // ���������� Particle System ����� ��������� ������
        Destroy(particleInstance, particleDuration);
    }
}
