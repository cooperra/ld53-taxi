using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    private bool spawnFinish;
    [SerializeField] private float roadSpeed;
    [SerializeField] private GameObject road;
    [SerializeField] private GameObject finishLine;
    public static RoadSpawner instance;
    [SerializeField] private float nextSpawnDist = 0.5f;
    private RoadMotion mostRecentRoad;
    [SerializeField] private float destroyDist = 15f;

    public float RoadSpeed { get => roadSpeed; set => roadSpeed = value; }
    public float DestroyDist { get => destroyDist; set => destroyDist = value; }

    void SpawnRoad()
    {

        if (mostRecentRoad == null)
        {
            Vector3 pos = transform.position;
            GameObject obj = Instantiate(road, pos, Quaternion.identity);
            RoadMotion roadInst = obj.GetComponent<RoadMotion>();

            mostRecentRoad = roadInst;

        } else if (mostRecentRoad.transform.position.y < transform.position.y - nextSpawnDist) {
            Vector3 pos = mostRecentRoad.transform.position;
            pos.y += mostRecentRoad.Height();
            GameObject obj = Instantiate(road, pos, Quaternion.identity);
            RoadMotion roadInst = obj.GetComponent<RoadMotion>();

            mostRecentRoad = roadInst;
        }
        if(GameManager.instance.Conditions == Conditions.finish)
        {
            spawnFinish = true;
           
        }
        if(spawnFinish)
        {
            spawnFinish = false;
            Instantiate(finishLine, transform.position, Quaternion.identity);
        }
    }

    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.Conditions == Conditions.start || GameManager.instance.Conditions == Conditions.finish)
        {
            SpawnRoad();
        }
    }
}
