using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] private float carSpawnTime;
    [SerializeField] private float obstacleSpawnTime;
    [SerializeField] private GameObject car;
    [SerializeField] private GameObject obstacle;

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
            carT = carSpawnTime;
            Instantiate(car, transform.position, Quaternion.identity);
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
            obstacleT = obstacleSpawnTime;
            Instantiate(obstacle, transform.position, Quaternion.identity);
        }
    }

    private void Update()
    {
        SpawnObstacle();
        SpawnCar();
    }
}
