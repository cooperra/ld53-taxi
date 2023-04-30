using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMotion : MonoBehaviour
{
    private readonly float DESTROYDIST = 30;
    private Sprite sprite;
    private Vector3 startPos;

    internal float Height()
    {
        return sprite.bounds.size.y;
    }

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<Sprite>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.Conditions == Conditions.start || GameManager.instance.Conditions == Conditions.finish)
        {
            float speed = RoadSpawner.instance.RoadSpeed;
            transform.Translate(Vector2.up * -speed * Time.deltaTime);
            // Destroy once off the bottom of the screen
            if (transform.position.y > startPos.y + DESTROYDIST)
            {
                Destroy(this.gameObject, 0.0f);
            }
            
        }
    }
}
