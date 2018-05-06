using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldBags : MonoBehaviour
{
    public Transform[] goldBagSpawnPoints;
    public GameObject goldBagPrefab;

    public void AddGoldBagToShip()
    {
        int randomSpawnPoint = Random.Range(0, goldBagSpawnPoints.Length);
        GameObject gold = Instantiate(goldBagPrefab, goldBagSpawnPoints[randomSpawnPoint].transform.position, Quaternion.identity);
        gold.transform.parent = transform;
    }
}
