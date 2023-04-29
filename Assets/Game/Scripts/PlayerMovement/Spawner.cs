using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] private float carSpawnTime;
    [SerializeField] private float obstacleSpawnTime;
    [SerializeField] private GameObject car;
     private GameObject obstacle;
    [SerializeField] private float carRandom;
    [SerializeField] private float obstacleRandom;
    [SerializeField] private float obstacleOffset;
    [SerializeField] private float carOffset;
    [SerializeField] private List<GameObject> obstacles;
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
            if (pos.x < 3.8f || pos.y > -3.8f)
            {
                carT = Random.Range(carSpawnTime, carRandom);
                Instantiate(car, pos, Quaternion.identity);
            }
        }
    }

    void SpawnObstacle()
    {
        obstacle = obstacles[(int)Mathf.FloorToInt(Random.Range(0, obstacles.Count))];

        if (obstacleT > 0)
        {
            obstacleT--;

        }
        else
        {
            Vector3 pos = transform.position;
            pos.x += Random.Range(-obstacleOffset, obstacleOffset);
            if (pos.x < 3.8f || pos.y > -3.8f)
            {
                obstacleT = Random.Range(obstacleSpawnTime, obstacleRandom);
                Instantiate(obstacle, pos, Quaternion.identity);
            }
        }
    }

    private void Update()
    {
        if (GameManager.instance.Conditions == Conditions.start || GameManager.instance.Conditions == Conditions.finish)
        {
            SpawnObstacle();
            SpawnCar();
        }
    }
}
