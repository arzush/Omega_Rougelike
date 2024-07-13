//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class LimitedEnemySpawner : MonoBehaviour
//{
//    [SerializeField] 
//    private GameObject _enemyPrefab;

//    [SerializeField]
//    private float _minimumSpawnTime;

//    [SerializeField]
//    private float _maximumSpawnTime;

//    private float _timeUntilSpawn;
//    // Start is called before the first frame update
//    void Awake()
//    {
//        SetTimeUntilSpawn();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        _timeUntilSpawn -= Time.deltaTime;
//        if (_timeUntilSpawn <= 0)
//        {
//            Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
//            SetTimeUntilSpawn();
//        }
//    }

//    private void SetTimeUntilSpawn()
//    {
//        _timeUntilSpawn = Random.Range(_minimumSpawnTime, _maximumSpawnTime);
//    }
//}


using UnityEngine;

public class LimitedEnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;

    [SerializeField]
    private float _minimumSpawnTime;

    [SerializeField]
    private float _maximumSpawnTime;

    [SerializeField]
    private int _enemyLimit; // ���� ����� ���� ��� ����������� ���������� ������

    private float _timeUntilSpawn;
    private int _spawnedEnemies; // ������� ��������� ������

    // Start is called before the first frame update
    void Awake()
    {
        SetTimeUntilSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        _timeUntilSpawn -= Time.deltaTime;
        if (_spawnedEnemies < _enemyLimit && _timeUntilSpawn <= 0) // ��������, ��� ���������� ��������� ������ ������ �������������� ������
        {
            Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
            SetTimeUntilSpawn();
            _spawnedEnemies++; // ����������� ������� ��������� ������
        }
    }

    private void SetTimeUntilSpawn()
    {
        _timeUntilSpawn = Random.Range(_minimumSpawnTime, _maximumSpawnTime);
    }
}

