using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    float pos;
    public GameObject groundTile;
    public Vector3 nextSpawnPoint;
    public void SpawnTile()
    {
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        if(GroundTile.GetCounter() == Random.Range(3,9) || GroundTile.GetCounter() == 10)
        {
            Debug.Log(GroundTile.counter);
            pos = 3.5f;
            GroundTile.SetCounter(0);
        }
        else
        {
            Debug.Log(GroundTile.counter);
            pos = 0;
        }
        
        nextSpawnPoint = temp.transform.GetChild(1).transform.position + new Vector3(0,0,pos);
    }
    void Start()
    {
        for(int i = 0; i < 20; i++)
        {
            SpawnTile();
        }
    }
}
