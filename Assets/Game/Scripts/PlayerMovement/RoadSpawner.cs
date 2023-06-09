using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    private bool spawnedFinish = false;
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
            // Shift down just a little to hide the pixel-wide seam
            pos.y -= 0.05f;
            GameObject obj = Instantiate(road, pos, Quaternion.identity);
            RoadMotion roadInst = obj.GetComponent<RoadMotion>();

            mostRecentRoad = roadInst;
        }
        if(GameManager.instance.Conditionnn == Conditions.finish && !spawnedFinish)
        {
            spawnedFinish = true;
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
        if(GameManager.instance.Conditionnn == Conditions.start || GameManager.instance.Conditionnn == Conditions.finish)
        {
            SpawnRoad();
        }
    }
}
