using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : EnemyCarLogic
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.Conditionnn = Conditions.win;
        }
    }
}
