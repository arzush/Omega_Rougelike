using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnceSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] InventoryPrefab;

    private void Start()
    {
        SpawnInventory();
    }

    private void SpawnInventory()
    {
        int rand = Random.Range(0, InventoryPrefab.Length);
        GameObject objectToSpawn = InventoryPrefab[rand];
        Instantiate(objectToSpawn, transform.position, Quaternion.identity);
    }
}
