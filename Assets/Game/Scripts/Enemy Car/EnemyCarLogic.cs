using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCarLogic : MonoBehaviour
{
    //Enemy Car Logic is also applied to Obstacles
    //Car moves in a straight line that is all!
    //Car Obstacle is set to speed 5
    [SerializeField] private float speed;
    [SerializeField] private float destroyTime;

    private void Update()
    {
        if (GameManager.instance.Conditionnn == Conditions.start || GameManager.instance.Conditionnn == Conditions.finish)
        {


            transform.Translate(Vector2.up * -speed * Time.deltaTime);
            Destroy(this.gameObject, destroyTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
       if(other.CompareTag("Player"))
        {
           
        }
    }

}