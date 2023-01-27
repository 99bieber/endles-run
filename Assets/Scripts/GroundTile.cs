using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    public static int counter = 0;
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        
        SpawnObstacle();
    }

    void Update() {
        obstaclePrefab[0].transform.eulerAngles = new Vector3(0,90,0);
    }

    private void OnTriggerExit(Collider other) 
    {
        groundSpawner.SpawnTile();
        counter += 1;
        Destroy(gameObject, 2);

    }
    public static int GetCounter()
    {
        return counter;
    }
    public static void SetCounter(int _counter)
    {
        counter = _counter;
     }
    public GameObject[] obstaclePrefab;
    void SpawnObstacle()
    {
        
        int obstacleSpawnIndex = Random.Range(2,5);
        int obstacleSpawnObject = Random.Range(0,4);
        int rot;
        int z;
        if(obstacleSpawnObject == 0)
        {
            z = 0;
            rot = 90;
            obstacleSpawnIndex= 2;
        }
        else if(obstacleSpawnObject == 2)
        {
            z = 0;
            rot = 0;
            obstacleSpawnIndex = Random.Range(3,5);
        }
        else if(obstacleSpawnObject == 3)
        {
            z = 3;
            rot = 180;
            obstacleSpawnIndex= 2;
        }
        else
        {
            z = 0;
            rot = 0;
        }
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        Instantiate(obstaclePrefab[obstacleSpawnObject],spawnPoint.position + new Vector3(0,0,z), Quaternion.Euler(new Vector3(0,rot,0)), transform);
    }


}
