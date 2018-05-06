using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldBags : MonoBehaviour
{

    public Transform[] m_tGoldBagSpawnPoints;
    public GameObject m_gGoldBagPrefab;
    public Queue<GameObject> m_qGoldBagQueue;

    private GameObject gold;

    void Start()
    {
        m_qGoldBagQueue = new Queue<GameObject>();
    }

    public void AddGoldBagToShip()
    {
        int randomSpawnPoint = Random.Range(0, m_tGoldBagSpawnPoints.Length);
        gold = Instantiate(m_gGoldBagPrefab, m_tGoldBagSpawnPoints[randomSpawnPoint].transform.position, Quaternion.identity);
        gold.transform.parent = transform;
        m_qGoldBagQueue.Enqueue(gold);
    }

    public void RemoveGoldBagFromShip()
    {
        // making sure we actually have something in the queue to remove.
        if(m_qGoldBagQueue.Count != 0)
        {
            gold = (GameObject)m_qGoldBagQueue.Dequeue();
            // destroying bag for now
            GameObject.Destroy(gold);
            // can add gold dropping off ship anim here if needed instead of destroying it
        }
    }
}
