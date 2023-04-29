using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] private float roadTime;
    [SerializeField] private GameObject road;
    [SerializeField] private GameObject finishLine;
    private float roadT;
    void SpawnRoad()
    {

        if (roadT > 0)
        {
            roadT--;

        }
        else
        {
            Vector3 pos = transform.position;
            //pos.y -= road.transform.localScale.y * 0.05f;
            
           
            roadT = roadTime;
            Instantiate(road, pos, Quaternion.identity);
            
        }
        if(GameManager.instance.Conditions == Conditions.finish)
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
