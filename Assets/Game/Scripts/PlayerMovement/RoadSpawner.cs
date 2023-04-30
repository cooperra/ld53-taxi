using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] private float roadSpeed;
    [SerializeField] private GameObject road;
    [SerializeField] private GameObject finishLine;
    public static RoadSpawner instance;
    private readonly int NEXTSPAWNDIST = 100;
    private RoadMotion mostRecentRoad;

    public float RoadSpeed { get => roadSpeed; set => roadSpeed = value; }

    void SpawnRoad()
    {

        if (mostRecentRoad == null)
        {
            Vector3 pos = transform.position;
            GameObject obj = Instantiate(road, pos, Quaternion.identity);
            RoadMotion roadInst = obj.GetComponent<RoadMotion>();

            mostRecentRoad = roadInst;

        } else if (mostRecentRoad.transform.position.y > transform.position.y + NEXTSPAWNDIST) {
            Vector3 pos = mostRecentRoad.transform.position;
            pos.y -= mostRecentRoad.Height();
            GameObject obj = Instantiate(road, pos, Quaternion.identity);
            RoadMotion roadInst = obj.GetComponent<RoadMotion>();

            mostRecentRoad = roadInst;
        }
        if (GameManager.instance.Conditions == Conditions.finish)
        {
            Instantiate(finishLine, transform.position, Quaternion.identity);
        }
    }

    void Start()
    {
        
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
