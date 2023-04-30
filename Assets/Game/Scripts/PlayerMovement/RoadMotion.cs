using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMotion : MonoBehaviour
{
    private readonly float DESTROYDIST = 10;
    private SpriteRenderer sprite;

    internal float Height()
    {
        return sprite.bounds.size.y;
    }

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.Conditions == Conditions.start || GameManager.instance.Conditions == Conditions.finish)
        {
            float speed = RoadSpawner.instance.RoadSpeed;
            float destroyDist = RoadSpawner.instance.DestroyDist;
            transform.Translate(Vector2.up * -speed * Time.deltaTime);
            // Destroy once off the bottom of the screen (a specific distance from the spawner)
            if (transform.position.y < RoadSpawner.instance.transform.position.y - destroyDist)
            {
                Destroy(this.gameObject, 0.0f);
            }
            
        }
    }
}
