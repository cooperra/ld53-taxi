using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] private float carSpawnTime;
    [SerializeField] private float obstacleSpawnTime;
    [SerializeField] private GameObject car;
    [SerializeField] private GameObject obstacle;
    [SerializeField] private float carRandom;
    [SerializeField] private float obstacleRandom;
    [SerializeField] private float obstacleOffset;
    [SerializeField] private float carOffset;
    private float carT;
    private float obstacleT;

    void SpawnCar()
    {

        if (carT > 0)
        {
            carT--;

        }
        else
        {
            Vector3 pos = transform.position;
            pos.x += Random.Range(-obstacleOffset, obstacleOffset);
            carT = Random.Range( carSpawnTime,carRandom);
            Instantiate(car, pos, Quaternion.identity);
        }
    }

    void SpawnObstacle()
    {
        
        
        if (obstacleT > 0)
        {
            obstacleT--;
           
        }
        else
        {
            Vector3 pos = transform.position;
            pos.x += Random.Range(-obstacleOffset, obstacleOffset);
            obstacleT = Random.Range(obstacleSpawnTime, obstacleRandom);
            Instantiate(obstacle, pos, Quaternion.identity);
        }
    }

    private void Update()
    {
        SpawnObstacle();
        SpawnCar();
    }
}
